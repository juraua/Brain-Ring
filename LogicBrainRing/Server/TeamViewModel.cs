using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DbBrainRing.Models;
using JetBrains.Annotations;

namespace LogicBrainRing.Server
{
    public class TeamViewModel:INotifyPropertyChanged
    {
        public ObservableCollection<Team> Teams { get; set; }
        private int _team;
        private int _teamsIndex;
        private int _allPoints;
        private string _teamName;
        private string _captainName;
        private string _description;
        public ObservableCollection<Points> Points { get; set; }
        private int _valueCurrent;
        private int _gamesCount;

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Get, Set

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

        public string TeamName
        {
            get { return _teamName; }
            set
            {
                if (value == _teamName) return;
                _teamName = value;
                OnPropertyChanged();
            }
        }

        public string CaptainName
        {
            get { return _captainName; }
            set
            {
                if (value == _captainName) return;
                _captainName = value;
                OnPropertyChanged();
            }
        }
        //В БД - Information
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        //В БД - Points
        public int AllPoints
        {
            get { return _allPoints; }
            set
            {
                if (value == _allPoints) return;
                _allPoints = value;
                OnPropertyChanged();
            }
        }

        //Бали, набрані в поточній грі
        public int ValueCurrent
        {
            get { return _valueCurrent; }
            set
            {
                if (value == _valueCurrent) return;
                _valueCurrent = value;
                OnPropertyChanged();
            }
        }
        //Всього набрано балів за всі ігри
        public int GamesCount
        {
            get { return _gamesCount; }
            set
            {
                if (value == _gamesCount) return;
                _gamesCount = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
