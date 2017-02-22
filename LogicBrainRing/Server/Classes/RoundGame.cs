using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DbBrainRing;
using DbBrainRing.Enums;
using DbBrainRing.Models;
using LogicBrainRing.Server.HelperClasses;
using System.Reflection;

namespace LogicBrainRing.Server.Classes
{
    /// <summary>
    /// This is round of current game
    /// </summary>
    public class RoundGame : INotifyPropertyChanged
    {
        #region реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        public GameViewModel Game { get; set; }

        public ObservableCollection<QuestionGame> Questions { get; set; }
        private int _question;
        private int _questionsCount;
        private int _maxQuestionsCount;
        public ObservableCollection<string> Types { get; set; }
        private string _type;
        private int _time;

        public RoundGame()
        {
        }

        public RoundGame(RoundGame roundGame)
        {
            Game = roundGame.Game;
            Questions = roundGame.Questions;
            _question = roundGame.Question;
            _questionsCount = roundGame.QuestionsCount;
            _maxQuestionsCount = roundGame.MaxQuestionsCount;
            Types = roundGame.Types;
            //Types = myEnumDisplay;
            _type = roundGame.Type;
            _time = roundGame.Time;
        }

        #region Get, Set - Observables

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
        public int QuestionsCount
        {
            get { return _questionsCount; }
            set
            {
                if (value == _questionsCount || value > _maxQuestionsCount ) return;
                _questionsCount = ViewModelHelper.ResizeQuestions(this, value);
                OnPropertyChanged();
            }
        }
        public int MaxQuestionsCount
        {
            get { return _maxQuestionsCount; }
            set
            {
                if (value == _maxQuestionsCount) return;
                _maxQuestionsCount = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                //foreach (var r in Game.Rounds)
                //{
                //    if (value == r.Type) return;
                //}
                if (Questions != null)
                    ViewModelHelper.ChangeRoundType(this, value);
                _type = value;
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
                foreach (var q in Questions)
                {
                    q.Time = _time;
                }
                OnPropertyChanged();
            }
        }

        #endregion

        

        //var myEnumDisplay = from RoundType rt in Enum.GetValues(typeof(RoundType))
        //                    select new { ID = (int)rt, Name = Enumerations.GetEnumDisplay(rt) };
    }
}
