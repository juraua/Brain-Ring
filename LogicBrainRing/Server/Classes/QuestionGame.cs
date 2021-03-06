﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DbBrainRing.Models;
using DbBrainRing;
using LogicBrainRing.Server.HelperClasses;
using System.Collections.Generic;

namespace LogicBrainRing.Server.Classes
{
    public class QuestionGame : INotifyPropertyChanged
    {
        #region реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public RoundGame Round { get; set; }
        public ObservableCollection<Theme> Themes { get; set; }
        private int _theme;

        public Question Question { get; set; }
        private int _answerId;

        private int _time;

        
        #region Конструкторы

        public QuestionGame()
        {
        }

        public QuestionGame(RoundGame model, Question question)
        {
            Round = model;
            Question = question;
            _answerId = -1;
            _time = (int)question.Round == 2 ? 1 : 3;
        }

        #endregion

        #region Get, Set
        public int Answer
        {
            get { return _answerId; }
            set
            {
                if (value == _answerId) return;
                _answerId = value;
                OnPropertyChanged();
            }
        }
        public int Time
        {
            get { return _time; }
            set
            {
                if (value == _time) return;
                _time = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}
