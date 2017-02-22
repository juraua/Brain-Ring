using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DbBrainRing;
using DbBrainRing.Enums;
using DbBrainRing.Models;
using LogicBrainRing.Server.Classes;
using System.Reflection;

namespace LogicBrainRing.Server.HelperClasses
{
    public static class ViewModelHelper
    {

#region Statistics

        /// <summary>
        /// Создание обекта StatisticsViewModel
        /// </summary>
        public static StatisticsViewModel GetStatisticsViewModel(int tab)
        {
            var model = new StatisticsViewModel();
            using (var context1 = new BrainRingContext())
            {
                //Переключение между вкладками в окне Статистика
                switch (tab)
                {
                        //Вкладка "Рейтинг команд"
                    case 1:
                        model.Games = new ObservableCollection<Game>(context1.Games.OrderByDescending(e => (e.Date)));
                        model.Points = new ObservableCollection<Points>(context1.Points);
                        break;
                        //Вкладка "Попередні ігри"
                    case 2:
                        model.Teams = new ObservableCollection<Team>(context1.Teams.OrderByDescending(e => e.AllPoints));
                        foreach (var team in model.Teams)
                        {
                            //количество сыгранных игр командой (из списка игр, в которых она принимала участие)
                            team.GamesCount = context1.Games.SelectMany(x => x.Teams).Count(e => e.Id == team.Id);
                            //Не проще по завершению каждой игры записывать в поле GamesCount автоинкремент count++ ??? При этом поле GamesCount добавить в БД.
                        }
                        break;
                }
            }
            return model;
        }

        /// <summary>
        /// Получение очков команды за игру
        /// </summary>
        public static int GetPointsGame(Game g, Team t)
        {
            using (var context = new BrainRingContext())
            {
                return context.Points.Single(e => (e.Game.Id == g.Id && e.Team.Id == t.Id)).ValueCurrent;
            }
        }
#endregion

#region Game
        /// <summary>
        /// Создание обекта GameViewModel
        /// </summary>
        public static GameViewModel GetGameViewModel()
        {
            GameViewModel model = new GameViewModel();
            model.Game = new Game();
            model.Game.Date = new DateTime();
            using (var context = new BrainRingContext())
            {
                model.Themes = new ObservableCollection<Theme>(context.Themes); //<String> context1.Themes.Select(e=> e.Name)
            }
            model.Theme = 0;
            model.Rounds = new ObservableCollection<RoundGame>();
            //Выбранный индекс в выпадающем списке
            model.Round = 0;
            //Кол-во раундов
            model.RoundsIndex = 3;
            model.Teams = new ObservableCollection<DictionaryItem>();
            model.Team = 0;
            model.TeamsIndex = 0;
            model.Points = new ObservableCollection<Points>();
            return model;
        }

        #region Функции создания игры
        /// <summary>
        /// Изменение количества раундов игры
        /// </summary>
        public static void ResizeRoundsGame(GameViewModel model, int value) //value - выбранное кол-во раундов перед началом игры
        {
            int typeRound = 0;
            //заполнение
            if (model.Rounds.Count == 0)
            {
                for (int i = 0; i < value; i++)
                {
                    if (i == value - 1)
                        typeRound = 4;
                    model.Rounds.Add(GetRoundGame(model, typeRound));
                    typeRound++;
                }
            }
            //удаление
            else if (value < model.RoundsIndex + 2)//RoundsIndex начинается с 0, раундов не может быть меньше 2 (поэтому 0+2)
            {
                for (int i = model.RoundsIndex+2; i > value; i--)
                {
                    model.Rounds.RemoveAt(i-1);
                }
            }
            //добавление
            else if (value > model.RoundsIndex+2)
            {
                //Список выбранных типов раундов (Общий, Спринт и т.д)
                List<int> listTypsRound = new List<int>();
                foreach (var r in model.Rounds)
                {
                    listTypsRound.Add(r.Type);
                }

                //Все типы раундов из БД
                List<RoundType> types = Enum.GetValues(typeof(RoundType)).Cast<RoundType>().ToList();

                //Типы раундов, которые не включены в игру (что бы не слетели настройки раундов при добавлении новых)
                List<int> selected = types.Select(x => (int)x).Except(listTypsRound.Select(w => w)).ToList();
                
                //Добавление нового раунда из списка не включенных
                for (int i = model.RoundsIndex+2; i < value; i++)
                {
                    if (selected.Count > 0)
                    {
                        typeRound = selected[0];
                        model.Rounds.Add(GetRoundGame(model, typeRound));
                        selected.RemoveAt(0);
                    }
                }
            }
        }

        /// <summary>
        /// Добавление команды в БД
        /// </summary>
        public static Team GetTeam()
        {
            TeamViewModel teamViewModel = new TeamViewModel();
            using (var context = new BrainRingContext())
            {
                teamViewModel.Teams = new ObservableCollection<Team>(context.Teams);
                var team = new Team()
                {
                    Id = teamViewModel.TeamsIndex,
                    Name = teamViewModel.TeamName,
                    Captain = teamViewModel.CaptainName,
                    Description = teamViewModel.Description,
                    GamesCount = teamViewModel.GamesCount,
                    AllPoints = teamViewModel.AllPoints
                };
                return team;
            }
            
        }

        #endregion

        #region Функции создания раудов

        /// <summary>
        /// Создание обекта RoundGame
        /// </summary>
        public static RoundGame GetRoundGame(GameViewModel game, string typeRound)
        {
            RoundGame model = new RoundGame();
            model.Game = game;
            //Выгрузка всех типов раундов из Enumerable
            model.Types = new ObservableCollection<string>(Enum.GetValues(typeof(RoundType)).Cast<RoundType>().Select(x => x.GetEnumDisplay()));
            //Макс. кол-во вопросов по выбранному типу ранда
            model.MaxQuestionsCount = GetAllQuestionsDb(typeRound).Count;
            //Настройка кол-ва вопросов по умолчанию для каждого типа раундов (если в БД вопросов меньше, берется значение MaxQuestionsCount)
            switch (typeRound)
            {
                case RoundType.Cathegories.GetEnumDisplay():
                    model.QuestionsCount = model.MaxQuestionsCount > 15 ? 15 : model.MaxQuestionsCount;
                    break;
                case 1:
                    model.QuestionsCount = model.MaxQuestionsCount > 20 ? 20 : model.MaxQuestionsCount;
                    break;
                case 2:
                case 4:
                    model.QuestionsCount = model.MaxQuestionsCount > 4 ? 4 : model.MaxQuestionsCount;
                    break;
                case 3:
                    model.QuestionsCount = model.MaxQuestionsCount > 10 ? 10 : model.MaxQuestionsCount;
                    break;
            }
            //Заполнение раунда вопросами
            SetQuestions(model, game.Theme);
            //Индекс текущего вопроса
            model.Question = 0;
            //Тип раунда
            model.Type = typeRound;
            //Время на вопрос по умолчанию
            model.Time = typeRound == 1 ? 1 : 3;

            return model;
        }

        /// <summary>
        /// Изменение вопросов игры по выбранной тематике
        /// </summary>
        public static void SetQuestions(RoundGame model, int themeQuestion)
        {
            model.Questions = new ObservableCollection<QuestionGame>();
            //Выгрузка всех вопросов из БД по выбранной тематике и выбранному раунду
            List<Question> allQuestions = GetAllQuestionsDb(model.Type, themeQuestion);
            //allQuestions.Shuffle();

            //Если в БД меньше вопросов чем выбрано, устанавливается кол-во вопросов из БД
            if (model.QuestionsCount > allQuestions.Count)
                model.QuestionsCount = allQuestions.Count;
            //Добавляем в раунд набор вопросов (из БД записываются по порядку, можно сделать добавление вопросов с конца)
            for (int i = 0; i < model.QuestionsCount; i++)
            {
                model.Questions.Add(new QuestionGame(model, allQuestions[i]));
            }
        }

        /// <summary>
        /// Изменение типа раунда (если нужно изменить порядок раундов)
        /// </summary>
        internal static void ChangeRoundType(RoundGame roundGame, string value)
        {
            //Если выбрано 5 раундов, они меняются местами
            if (roundGame.Game.Rounds.Count == 5)
            {
                int r1 = -1, r2 = -1;
                for (int i = 0; i < roundGame.Game.Rounds.Count; i++)
                {
                    if (roundGame.Game.Rounds[i] == roundGame)
                    {
                        r1 = i;
                    }
                    else if (roundGame.Game.Rounds[i].Type == value)
                    {
                        r2 = i;
                    }
                }
                if (r1 != -1 && r2 != -1)
                {
                    RoundGame r = new RoundGame(roundGame.Game.Rounds[r1]);
                    roundGame.Game.Rounds[r1] = roundGame.Game.Rounds.ElementAt(r2);
                    roundGame.Game.Rounds[r2] = r;
                }
            }
            //Если выбрано меньше 5-ти раундов
            else if (roundGame.Game.Rounds.Contains(roundGame))
            {
                RoundGame r = roundGame.Game.Rounds.SingleOrDefault(e => (e.Type == value));
                //Если тип уже используется, то устанавливаем существующий раунд этого типа, а на его место устанавливается раунд с типом, который еще не использовался
                if (r != null)
                {
                    roundGame = new RoundGame(r);
                    string i = roundGame.Types.Select(e => (string) e).Except(roundGame.Game.Rounds.Select(e => e.Type)).First();
                    roundGame.Game.Rounds[roundGame.Game.Rounds.IndexOf(r)] = GetRoundGame(r.Game, i);
                }
                //Если выбранны тип не используется, то создает новый раунд с выбранным типом
                else
                {
                    roundGame = GetRoundGame(roundGame.Game, value);
                }
            }
        }

        /// <summary>
        /// Изменение количества вопросов раунда игры
        /// </summary>
        public static int ResizeQuestions(RoundGame model, int questionsCount)
        {
            if (model.QuestionsCount == questionsCount) return questionsCount;
            //удаление
            if (model.QuestionsCount > questionsCount)
            {
                for (int i = model.QuestionsCount-1; i >= questionsCount; i--)
                {
                    model.Questions.RemoveAt(i);
                }
            }
            //добавление
            else if (model.QuestionsCount < questionsCount)
            {
                //получить все вопросы выбранной тематики для текущего раунда из БД
                List<Question> allQuestions = GetAllQuestionsDb(model.Type, model.Game.Theme);
                //перемешивание вопросов
                foreach (var e in allQuestions)
                {
                    e.RandomNumber = new Random().Next();
                }
                allQuestions = allQuestions.OrderBy(e => e.RandomNumber).ToList();
                //при нехватки вопроссов выбранной тематики в БД, добавить вопросы других тематик
                /*if (allQuestions.Count < questionsCount)
                {
                    //получить все вопросы из БД
                    List<Question> allQuestions2 = GetAllQuestionsDb(model.Type, 0);
                    //перемешивание вопросов
                    //foreach (var e in allQuestions2)
                    //{
                    //    e.RandomNumber = new Random().Next();
                    //}
                    //allQuestions2 = allQuestions2.OrderBy(e => e.RandomNumber).ToList();
                    ////при нехватки вопроссов в БД, изменить количество вопросов для данного раунда
                    //if (allQuestions2.Count < questionsCount)
                    //{
                    //    questionsCount = allQuestions2.Count;
                    //}
                    //allQuestions = questionsCount == allQuestions2.Count ? allQuestions2 
                    //    : allQuestions.Concat(allQuestions2.Where(e => e.Id != model.Game.Theme)).ToList();
                }*/
                //добавление необходимого количества вопросов
                if (model.Questions != null)
                {
                    allQuestions = allQuestions.Except(model.Questions.Select(e => e.Question)).ToList();
                    foreach (var newQ in allQuestions)
                    {
                        if (model.Questions.Count == questionsCount) return questionsCount;
                        model.Questions.Add(new QuestionGame(model, newQ));
                    }
                }
            }
            return questionsCount;
        }

        /// <summary>
        ///Получение вопросов из БД для выбранного типа раунда
        /// </summary>
        private static List<Question> GetAllQuestionsDb(string round)
        {
            return GetAllQuestionsDb(round, 0);
        }

        /// <summary>        
        ///Получение вопросов из БД для выбранного типа раунда (которые относятся к выбранной тематике)
        /// </summary>
        private static List<Question> GetAllQuestionsDb(string round, int theme)
        {
            List<Question> allQuestions;
            using (var context1 = new BrainRingContext())
            {
                allQuestions = theme == 0
                    ? new List<Question>(context1.Questions.Where(e => (e.Round.GetEnumDisplay() == round)))
                    : new List<Question>(
                        context1.Questions.Where(e => (e.Theme.Id == theme) && (e.Round.GetEnumDisplay() == round)));
            }
            return allQuestions;
        }
        
        #endregion
        
        #region Функции процесса игры



        #endregion
#endregion

#region Editor
        /// <summary>
        /// Создание обекта TeamViewModel
        /// </summary>
        public static TeamViewModel GetTeamViewModel()
        {
            TeamViewModel model =  new TeamViewModel();
            model.Teams = new ObservableCollection<Team>();
            model.Team = 0;
            model.TeamsIndex = 0;
            model.AllPoints = 0;
            model.Points = new ObservableCollection<Points>();
            model.ValueCurrent = 0;
            return model;
        }
#endregion

#region Client

        #region Функции окна подключения

        /// <summary>
        /// Создание обекта ConnectViewModel для отправки клиенту
        /// </summary>
        public static Client.ConnectViewModel GetClientConnectViewModel(GameViewModel game)
        {
            List<String> teams = new List<string>();
            using (var context = new BrainRingContext())
            {
                teams = context.Teams.Select(e => e.Name).ToList();
            }
            return new Client.ConnectViewModel
            {
                Theme = game.Themes[game.Theme],
                AmountQuestionsInRounds = game.Rounds.Select(e => e.QuestionsCount).ToList(),
                AmountTeams = game.TeamsIndex + 2,
                SumPoints = game.Rounds.Select(e => e.Questions.Select(a => a.Question).Sum(s => s.Points)).Sum(e => e),
                TeamNames = teams
            };
        }

        #endregion

        #region Функции окна игры

        /// <summary>
        /// Создание обекта ConnectViewModel для отправки клиенту
        /// </summary>
        public static Client.GameViewModel GetClientGameViewModel(GameViewModel game)
        {
            return new Client.GameViewModel
            {
                Rounds = game.Rounds.Select(GetClientGameRound).ToList(),
                Teams = game.Teams.Select(GetClientGameTeam).ToList()
            };
        }

        private static Client.Classes.GameTeam GetClientGameTeam(DictionaryItem team)
        {
            return new Client.Classes.GameTeam
            {
                Name = team.Name,
                Points = 0
            };
        }

        private static Client.Classes.GameRound GetClientGameRound(RoundGame round)
        {
            return new Client.Classes.GameRound
            {
                Type = round.Types.First(x => x == round.Type),
                Timer = round.Time,
                Questions = round.Questions.Select(GetClientGameQuestion).ToList()
            };
        }

        private static Client.Classes.GameQuestion GetClientGameQuestion(QuestionGame question)
        {
            throw new NotImplementedException();
        }

        #endregion
#endregion
        
    }
}