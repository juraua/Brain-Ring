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
using DbBrainRing.Enums;

namespace LogicBrainRing.Server
{
    public class GameViewModel : INotifyPropertyChanged
    {
        #region реализация интерфейса INotifyPropertyChanged

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
        public Game Game { get; set; }
        public ObservableCollection<String> Categories { get; set; }
        private int _category;
        public ObservableCollection<RoundGame> Rounds { get; set; }
        private int _round;
        private int _roundsIndex;
        public ObservableCollection<Team> Teams { get; set; }
        private int _team;
        private int _teamsIndex;
        public ObservableCollection<Points> Points { get; set; }


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
        public int Category
        {
            get { return _category; }
            set
            {
                if (value == _category) return;
                if (Rounds != null && Rounds.Count != 0)
                {
                    foreach (var r in Rounds)
                    {
                        ViewModelHelper.SetQuestions(r, value);
                    }
                }
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

        #endregion

        private void testContent()
        {
            Category category = new Category { Name = "Тема1" };
            Categories = new ObservableCollection<String>{
                category.Name, "Тема2","Тема3"
            };
            foreach (var r in Rounds)
            {
                r.Questions = new ObservableCollection<QuestionGame>
                {
                    new QuestionGame
                    {
                        Question = new Question
                        {
                            Content = "Вопрос1",
                            Category = category,
                            Answers = new List<Answer>
                            {
                                new Answer()
                                {
                                    Content = "Ответ1",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    Content = "Ответ2",
                                    IsCorrect = false
                                },
                                new Answer()
                                {
                                    Content = "Ответ3",
                                    IsCorrect = true
                                },
                                new Answer()
                                {
                                    Content = "Ответ4",
                                    IsCorrect = false
                                },
                            },
                            Points = 3,
                            QuestionType = QuestionType.Варианты,
                            Round = RoundType.Общее
                        }
                    }
                };
            }
        }
    }
}
