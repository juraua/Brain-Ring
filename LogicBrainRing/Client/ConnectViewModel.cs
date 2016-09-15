using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicBrainRing.Client
{
    public class ConnectViewModel
    {
        public String Theme { get; set; }
        public List<int> AmountQuestionsInRounds { get; set; }
        public int AmountTeams { get; set; }
        public int SumPoints { get; set; }
        public List<String>  TeamNames { get; set; }
    }
}
