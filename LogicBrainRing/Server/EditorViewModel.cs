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
        public ObservableCollection<Category> Categories { get; private set; }
        private int _category;
        public ObservableCollection<Question> Questions { get; private set; }
        private int _question;
        public ObservableCollection<Answer> Answers { get; private set; }
        private int _answer;

        private int _round;

        #region Конструкторы

        public EditorViewModel()
            : this(new BrainRingContext())
        {
        }

        public EditorViewModel(BrainRingContext model)
        {
            _model = model;
            Teams = new ObservableCollection<Team>(_model.Teams);
            Categories = new ObservableCollection<Category>(_model.Categories);
            Questions = new ObservableCollection<Question>(_model.Questions);

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
        public string TeamInformation
        {
            get { return Teams[Team].Information; }
            set
            {
                if (value == Teams[Team].Information) return;
                Teams[Team].Information = value;
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
        public int QuestionCategory
        {
            get { return Questions[Question].Id; }
            set
            {
                if (value == Questions[Question].Id) return;
                Questions[Question].Id = value;
                OnPropertyChanged();
            }
        }
        public string QuestionSubcategory
        {
            get { return Questions[Question].Subcategory; }
            set
            {
                if (value == Questions[Question].Subcategory) return;
                Questions[Question].Subcategory = value;
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

        #endregion


        public void NewTeam()
        {
            Teams.Add(new Team());
            _team = Teams.Count - 1;
        }
        public void NewCategory()
        {
            Categories.Add(new Category());
            _category = Categories.Count - 1;
        }
        public void NewQuestion()
        {
            Questions.Add(new Question());
            _question = Questions.Count - 1;
        }
        public void NewAnswer()
        {
            Answers.Add(new Answer());
            _answer = Answers.Count - 1;
        }


        #region функции для работы с БД

        public void AddTeamDb()
        {
            _model.Teams.Add(Teams[Team]);
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

        public void ChangeTeamDb()
        {
            var team = _model.Teams.ElementAt(Teams[Team].Id);
            team.Captain = Teams[Team].Captain;
            team.Information = Teams[Team].Information;
            team.Name = Teams[Team].Name;
        }
        public void ChangeCategoryDb()
        {
            var category = _model.Categories.ElementAt(Categories[Category].Id);
            category.Name = Categories[Category].Name;
            category.Description = Categories[Category].Description;
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
            question.Subcategory = Questions[Question].Subcategory;
        }
        public void ChangeAnswerDb()
        {
            var answer = _model.Answers.ElementAt(Answers[Answer].Id);
            answer.Content = Answers[Answer].Content;
            answer.Id = Answers[Answer].Id;
        }

        public void RemoveTeamDb()
        {
            _model.Teams.Remove(Teams[Team]);
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

        public void RessetUpdateTeams()
        {
            Teams = new ObservableCollection<Team>(_model.Teams);
        }
        public void RessetUpdateCategories()
        {
            Categories = new ObservableCollection<Category>(_model.Categories);
        }
        public void RessetUpdateQuestions()
        {
            Questions = new ObservableCollection<Question>(_model.Questions);
        }
        public void RessetUpdateAnswers()
        {
            Answers = new ObservableCollection<Answer>(_model.Answers);
        }

        #endregion

        //загрузка данных
        public void LoadData()
        {
            _model.Teams.Load();
            _model.Categories.Load();
            _model.Questions.Load();
            _model.Answers.Load();
        }
        //сохранение данных
        private void SaveChanges()
        {
            _model.SaveChanges();
        }
    }
}
