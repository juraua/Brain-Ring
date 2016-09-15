using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DbBrainRing;
using DbBrainRing.Models;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace LogicBrainRing.Server
{
    public class StatisticsViewModel
    {
        public ObservableCollection<Game> Games { get; set; }
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<Points> Points { get; set; }
    }
}
