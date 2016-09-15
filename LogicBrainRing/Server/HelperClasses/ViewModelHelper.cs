using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DbBrainRing;
using DbBrainRing.Enums;
using DbBrainRing.Models;
using LogicBrainRing.Server.Classes;

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
                switch (tab)
                {
                    case 1:
                        model.Games = new ObservableCollection<Game>(context1.Games.OrderByDescending(e => (e.Date)));
                        model.Points = new ObservableCollection<Points>(context1.Points);
                        break;
                    case 2:
                        model.Teams = new ObservableCollection<Team>(context1.Teams.OrderByDescending(e => e.Points));
                        foreach (var team in model.Teams)
                        {
                            //количество сыгранных игр командой
                            team.Games = context1.Games.SelectMany(x => x.Teams).Count(e => e.Id == team.Id);
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
                return context.Points.Single(e => (e.GameId == g.Id && e.TeamId == t.Id)).Value;
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
            using (var context1 = new BrainRingContext())
            {
                model.Categories = new ObservableCollection<String>(context1.Categories.Select(e=> e.Name));
            }
            model.Category = 0;
            model.Rounds = new ObservableCollection<RoundGame>();
            model.Round = 0;
            model.RoundsIndex = 3;
            model.Teams = new ObservableCollection<Team>();
            model.Team = 0;
            model.TeamsIndex = 0;
            model.Points = new ObservableCollection<Points>();
            return model;
        }

        #region Функции создания игры
        /// <summary>
        /// Изменение количества раундов игры
        /// </summary>
        public static void ResizeRoundsGame(GameViewModel model, int value)
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
            else if (value < model.RoundsIndex+2)
            {
                for (int i = model.RoundsIndex+2; i > value; i--)
                {
                    model.Rounds.RemoveAt(i-1);
                }
            }
            //добавление
            else if (value > model.RoundsIndex+2)
            {
                List<int> listTypsRound = new List<int>();
                foreach (var r in model.Rounds)
                {
                    listTypsRound.Add(r.Type);
                }
                List<RoundType> types = Enum.GetValues(typeof(RoundType)).Cast<RoundType>().ToList();
                List<int> selected = types.Select(x => (int)x).Except(listTypsRound.Select(w => w)).ToList();
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
        #endregion

        #region Функции создания раудов

        /// <summary>
        /// Создание обекта RoundGame
        /// </summary>
        public static RoundGame GetRoundGame(GameViewModel game, int typeRound)
        {
            RoundGame model = new RoundGame();
            model.Game = game;
            model.Types = new ObservableCollection<RoundType>(Enum.GetValues(typeof(RoundType)).Cast<RoundType>());
            model.MaxQuestionsCount = GetAllQuestionsDb(typeRound).Count;
            switch (typeRound)
            {
                case 0:
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
            SetQuestions(model, game.Category);
            model.Question = 0;
            model.Type = typeRound;
            model.Time = typeRound == 1 ? 1 : 3;

            return model;
        }

        /// <summary>
        /// Изменение категории вопросов игры
        /// </summary>
        public static void SetQuestions(RoundGame model, int сategoryQuestion)
        {
            model.Questions = new ObservableCollection<QuestionGame>();
            List<Question> allQuestions = GetAllQuestionsDb(model.Type, сategoryQuestion);
            //allQuestions.Shuffle();
            if (model.QuestionsCount > allQuestions.Count)
                model.QuestionsCount = allQuestions.Count;

            for (int i = 0; i < model.QuestionsCount; i++)
            {
                model.Questions.Add(new QuestionGame(model, allQuestions[i]));
            }
        }

        /// <summary>
        /// Изменение типа раунда
        /// </summary>
        internal static void ChangeRoundType(RoundGame roundGame, int value)
        {
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
            else if (roundGame.Game.Rounds.Contains(roundGame))
            {
                RoundGame r = roundGame.Game.Rounds.SingleOrDefault(e => (e.Type == value));
                if (r != null)
                {
                    roundGame = new RoundGame(r);
                    int i = roundGame.Types.Select(e => (int) e).Except(roundGame.Game.Rounds.Select(e => e.Type)).First();
                    roundGame.Game.Rounds[roundGame.Game.Rounds.IndexOf(r)] = GetRoundGame(r.Game, i);
                }
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
                //получить все вопросы выбранной категории из БД
                List<Question> allQuestions = GetAllQuestionsDb(model.Type, model.Game.Category);
                //перемешивание вопросов
                foreach (var e in allQuestions)
                {
                    e.RandomNumber = new Random().Next();
                }
                allQuestions = allQuestions.OrderBy(e => e.RandomNumber).ToList();
                //при нехватки вопроссов выбранной категории в БД, добавить вопросы других категорий
                if (allQuestions.Count < questionsCount)
                {
                    //получить все вопросы из БД
                    List<Question> allQuestions2 = GetAllQuestionsDb(model.Type, 0);
                    //перемешивание вопросов
                    foreach (var e in allQuestions2)
                    {
                        e.RandomNumber = new Random().Next();
                    }
                    allQuestions2 = allQuestions2.OrderBy(e => e.RandomNumber).ToList();
                    //при нехватки вопроссов в БД, изменить количество вопросов для данного раунда
                    if (allQuestions2.Count < questionsCount)
                    {
                        questionsCount = allQuestions2.Count;
                    }
                    allQuestions = questionsCount == allQuestions2.Count ? allQuestions2 
                        : allQuestions.Concat(allQuestions2.Where(e => e.Id != model.Game.Category)).ToList();
                }
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


        /*Получение вопросов из БД*/
        private static List<Question> GetAllQuestionsDb(int round)
        {
            return GetAllQuestionsDb(round, 0);
        }
        private static List<Question> GetAllQuestionsDb(int round, int сategory)
        {
            List<Question> allQuestions;
            using (var context1 = new BrainRingContext())
            {
                allQuestions = сategory == 0
                    ? new List<Question>(context1.Questions.Where(e => ((int)e.Round == round)))
                    : new List<Question>(
                        context1.Questions.Where(e => (e.Category.Id == сategory) && ((int)e.Round == round)));
            }
            return allQuestions;
        }
        
        #endregion

        
        #region Функции процесса игры



        #endregion
#endregion

#region Editor



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
                Theme = game.Categories[game.Category],
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

        private static Client.Classes.GameTeam GetClientGameTeam(Team team)
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
                Type = round.Types[round.Type].ToString(),
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