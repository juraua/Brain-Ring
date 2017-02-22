using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using DbBrainRing.Models;
using LogicBrainRing.Server.Classes;
using LogicBrainRing.Server.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using DbBrainRing;
using DbBrainRing.Enums;

namespace LogicBrainRing.Server
{
    public class GameViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        /// <summary>
        /// This is game
        /// </summary>
        private readonly BrainRingContext _context;
        public Game Game { get; set; }
        //---------чому Themes - String ????????----------------- 
        public ObservableCollection<Theme> Themes { get; set; }
        private int _theme;
        public ObservableCollection<RoundGame> Rounds { get; set; }
        private int _round;
        private int _roundsIndex;
        public ObservableCollection<DictionaryItem> Teams { get; set; }
        private int _team;
        private int _teamsIndex;
        public ObservableCollection<Points> Points { get; set; }
        //public ObservableCollection<Category> Categories { get; set; }

        #region Constructors

        public GameViewModel()
        {
            
        }

        public GameViewModel(BrainRingContext contex)
        {
            //_context = contex;
            ////Game = game;
            //Themes = new ObservableCollection<Theme>(_context.Themes.OrderBy(x=> x));
            //Teams = new ObservableCollection<DictionaryItem>(_context.Teams.Select(x => new DictionaryItem{Id = x.Id, Name = x.Name}));
            //Points = new ObservableCollection<Points>(_context.Points);
            ////Cathegories = new ObservableCollection<Cathegory>(_context.Cathegories);
            ////-----------Добавить RoundGame в БД???----------
            //Rounds = new ObservableCollection<RoundGame>(_context.);
        }

        #endregion

        #region Get, Set - Observables

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
        public int RoundsIndex
        {
            get { return _roundsIndex; }
            set
            {
                if (value == _roundsIndex) return;
                ViewModelHelper.ResizeRoundsGame(this, value+2);
                _roundsIndex = value;
                OnPropertyChanged();
            }
        }
        public int Theme
        {
            get { return _theme; }
            set
            {
                if (value == _theme) return;
                if (Rounds != null && Rounds.Count != 0)
                {
                    foreach (var round in Rounds)
                    {
                        ViewModelHelper.SetQuestions(round, value);
                    }
                }
                _theme = value;
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
        public int TeamsIndex
        {
            get { return _teamsIndex; }
            set
            {
                if (value == _teamsIndex) return;
                _teamsIndex = value;
                OnPropertyChanged();
            }
        }

        //public int Category { get; set; }

        #endregion

        public class RoundTypeCheckItem
        {
            public bool Checked { get; set; }
            public string Name { get; set; }
            public RoundType RoundName { get; set; }
        }
        //private void testContent()
        //{
        //    Theme theme = new Theme { Name = "Тема1" };
        //    Themes = new ObservableCollection<Theme>{
        //        theme.Name, "Тема2","Тема3"
        //    };
        //    foreach (var r in Rounds)
        //    {
        //        r.Questions = new ObservableCollection<QuestionGame>
        //        {
        //            new QuestionGame
        //            {
        //                Question = new Question
        //                {
        //                    Content = "Вопрос1",
        //                    Theme = theme,
        //                    Answers = new List<Answer>
        //                    {
        //                        new Answer()
        //                        {
        //                            Content = "Ответ1",
        //                            IsCorrect = false
        //                        },
        //                        new Answer()
        //                        {
        //                            Content = "Ответ2",
        //                            IsCorrect = false
        //                        },
        //                        new Answer()
        //                        {
        //                            Content = "Ответ3",
        //                            IsCorrect = true
        //                        },
        //                        new Answer()
        //                        {
        //                            Content = "Ответ4",
        //                            IsCorrect = false
        //                        },
        //                    },
        //                    Points = 3,
        //                    QuestionType = QuestionType.CheckBox,
        //                    Round = RoundType.Main
        //                }
        //            }
        //        };
        //    }
        //}
    }
}
