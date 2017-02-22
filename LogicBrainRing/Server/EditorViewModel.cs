using DbBrainRing;
using DbBrainRing.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DbBrainRing.Enums;

namespace LogicBrainRing.Server
{
    public class EditorViewModel : INotifyPropertyChanged
    {
        #region реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        //модель базы данных
        private readonly BrainRingContext _model;
        public ObservableCollection<Team> Teams { get; private set; }
        private int _team;
        public ObservableCollection<Theme> Themes { get; private set; }
        private int _theme;
        public ObservableCollection<Question> Questions { get; private set; }
        private int _question;
        public ObservableCollection<Answer> Answers { get; private set; }
        private int _answer;
        private int _round;
        private int _category;
        public ObservableCollection<Category> Categories { get; private set; }

        #region Constructors

        public EditorViewModel()
            : this(new BrainRingContext())
        {
        }

        public EditorViewModel(BrainRingContext model)
        {
            _model = model;
            Teams = new ObservableCollection<Team>(_model.Teams);
            Themes = new ObservableCollection<Theme>(_model.Themes);
            Questions = new ObservableCollection<Question>(_model.Questions);
            Categories = new ObservableCollection<Category>(_model.Categories);
        }
        #endregion

        #region Get, Set

        public int Question
        {
            get { return _question; }
            set
            {
                if (value == _question) return;
                _question = value;
                OnPropertyChanged();
            }
        }
        public int Theme
        {
            get { return _theme; }
            set
            {
                if (value == _theme) return;
                _theme = value;
                OnPropertyChanged();
            }
        }
        public int Category
        {
            get { return _category; }
            set
            {
                if (value == _category) return;
                _category = value;
                OnPropertyChanged();
            }
        }
        public int Team
        {
            get { return _team; }
            set
            {
                if (value == _team) return;
                _team = value;
                OnPropertyChanged();
            }
        }
        public int Round
        {
            get { return _round; }
            set
            {
                if (value == _round) return;
                _round = value;
                OnPropertyChanged();
            }
        }
        public int Answer
        {
            get { return _answer; }
            set
            {
                if (value == _answer) return;
                _answer = value;
                OnPropertyChanged();
            }
        }

        public string TeamName
        {
            get { return Teams[Team].Name; }
            set
            {
                if (value == Teams[Team].Name) return;
                Teams[Team].Name = value;
                OnPropertyChanged();
            }
        }
        public string TeamCaptain
        {
            get { return Teams[Team].Captain; }
            set
            {
                if (value == Teams[Team].Captain) return;
                Teams[Team].Captain = value;
                OnPropertyChanged();
            }
        }
        public string TeamDescription
        {
            get { return Teams[Team].Description; }
            set
            {
                if (value == Teams[Team].Description) return;
                Teams[Team].Description = value;
                OnPropertyChanged();
            }
        }

        public string ThemeName
        {
            get { return Themes[Theme].Name; }
            set
            {
                if (value == Themes[Theme].Name) return;
                Themes[Theme].Name = value;
                OnPropertyChanged();
            }
        }
        public string ThemeDescription
        {
            get { return Themes[Theme].Description; }
            set
            {
                if (value == Themes[Theme].Description) return;
                Themes[Theme].Description = value;
                OnPropertyChanged();
            }
        }

        public string CategoryName
        {
            get { return Categories[Category].Name; }
            set
            {
                if (value == Categories[Category].Name) return;
                Categories[Category].Name = value;
                OnPropertyChanged();
            }
        }
        public string CategoryDescription
        {
            get { return Categories[Category].Description; }
            set
            {
                if (value == Categories[Category].Description) return;
                Categories[Category].Description = value;
                OnPropertyChanged();
            }
        }
        /*public int QuestionCategory
        {
            get { return Questions[Question].Id; }
            set
            {
                if (value == Questions[Question].Id) return;
                Questions[Question].Id = value;
                OnPropertyChanged();
            }
        }*/

        public string QuestionContent
        {
            get { return Questions[Question].Content; }
            set
            {
                if (value == Questions[Question].Content) return;
                Questions[Question].Content = value;
                OnPropertyChanged();
            }
        }
        public int QuestionRound
        {
            get { return (int)Questions[Question].Round; }
            set
            {
                if (value == (int)Questions[Question].Round) return;
                Questions[Question].Round = (RoundType)value;
                OnPropertyChanged();
            }
        }
        public int QuestionType
        {
            get { return (int)Questions[Question].QuestionType; }
            set
            {
                if (value == (int)Questions[Question].QuestionType) return;
                Questions[Question].QuestionType = (QuestionType)value;
                OnPropertyChanged();
            }
        }
        public int QuestionPoints
        {
            get { return Questions[Question].Points; }
            set
            {
                if (value == Questions[Question].Points) return;
                Questions[Question].Points = value;
                OnPropertyChanged();
            }
        }

        public string AnswerContent
        {
            get { return Answers[Answer].Content; }
            set
            {
                if (value == Answers[Answer].Content) return;
                Answers[Answer].Content = value;
                OnPropertyChanged();
            }
        }
        public bool AnswerIsCorrect
        {
            get { return Answers[Answer].IsCorrect; }
            set
            {
                if (value == Answers[Answer].IsCorrect) return;
                Answers[Answer].IsCorrect = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Create functions
        public void CreateTeam()
        {
            Teams.Add(new Team());
            _team = Teams.Count - 1;
        }
        public void CreateTheme()
        {
            Themes.Add(new Theme());
            _theme = Themes.Count - 1;
        }
        public void CreateCategory()
        {
            Categories.Add(new Category());
            _category = Categories.Count - 1;
        }
        public void CreateQuestion()
        {
            Questions.Add(new Question());
            _question = Questions.Count - 1;
        }
        public void CreateAnswer()
        {
            Answers.Add(new Answer());
            _answer = Answers.Count - 1;
        }
        #endregion

        #region Add functions for Db

        public void AddTeamDb()
        {
            _model.Teams.Add(Teams[Team]);
        }
        public void AddThemeDb()
        {
            _model.Themes.Add(Themes[Theme]);
        }
        public void AddCategoryDb()
        {
            _model.Categories.Add(Categories[Category]);
        }
        public void AddQuestionDb()
        {
            _model.Questions.Add(Questions[Question]);
        }
        public void AddAnswerDb()
        {
            _model.Answers.Add(Answers[Answer]);
        }
        #endregion

        #region Change functions for Db
        //------------Зміна команди????-------------
        public void ChangeTeamDb()
        {
            var team = _model.Teams.ElementAt(Teams[Team].Id);
            team.Captain = Teams[Team].Captain;
            team.Description = Teams[Team].Description;
            team.Name = Teams[Team].Name;
        }
        public void ChangeThemeDb()
        {
            var theme = _model.Themes.ElementAt(Themes[Theme].Id);
            theme.Name = Themes[Theme].Name;
            theme.Description = Themes[Theme].Description;
        }
        public void ChangeCategoryDb()
        {
            var cathegory = _model.Categories.ElementAt(Categories[Category].Id);
            cathegory.Name = Categories[Category].Name;
            cathegory.Description = Categories[Category].Description;
        }
        public void ChangeQuestionDb()
        {
            var question = _model.Questions.ElementAt(Questions[Question].Id);
            question.Content = Questions[Question].Content;
            question.Id = Questions[Question].Id;
            question.Id = Questions[Question].Id;
            question.Points = Questions[Question].Points;
            question.QuestionType = Questions[Question].QuestionType;
            question.Round = Questions[Question].Round;
            question.Category = Questions[Question].Category;
        }
        public void ChangeAnswerDb()
        {
            var answer = _model.Answers.ElementAt(Answers[Answer].Id);
            answer.Content = Answers[Answer].Content;
            answer.Id = Answers[Answer].Id;
        }
        #endregion

        #region Remove functions for Db

        public void RemoveTeamDb()
        {
            _model.Teams.Remove(Teams[Team]);
        }
        public void RemoveThemeDb()
        {
            _model.Themes.Remove(Themes[Theme]);
        }
        public void RemoveCategoryDb()
        {
            _model.Categories.Remove(Categories[Category]);
        }
        public void RemoveQuestionDb()
        {
            _model.Questions.Remove(Questions[Question]);
        }
        public void RemoveAnswerDb()
        {
            _model.Answers.Remove(Answers[Answer]);
        }
        #endregion

        #region ResetUpdate functions
        public void ResetUpdateTeams()
        {
            Teams = new ObservableCollection<Team>(_model.Teams);
        }
        public void ResetUpdateCategory()
        {
            Categories = new ObservableCollection<Category>(_model.Categories);
        }
        public void ResetUpdateThemes()
        {
            Themes = new ObservableCollection<Theme>(_model.Themes);
        }
        public void ResetUpdateQuestions()
        {
            Questions = new ObservableCollection<Question>(_model.Questions);
        }
        public void ResetUpdateAnswers()
        {
            Answers = new ObservableCollection<Answer>(_model.Answers);
        }

        #endregion

       //загрузка данных
        public void LoadData()
        {
            _model.Teams.Load();
            _model.Themes.Load();
            _model.Questions.Load();
            _model.Answers.Load();
            _model.Categories.Load();
        }
        //сохранение данных
        private void SaveChanges()
        {
            _model.SaveChanges();
        }
    }
}
