using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DbBrainRing.Models;

namespace LogicBrainRing.Client
{
    public class ConnectViewModel
    {
        public Theme Theme { get; set; }// String
        public List<int> AmountQuestionsInRounds { get; set; }
        public int AmountTeams { get; set; }
        public int SumPoints { get; set; }
        public List<String>  TeamNames { get; set; }
    }
}
