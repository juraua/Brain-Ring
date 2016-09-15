using LogicBrainRing.Client.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicBrainRing.Client
{
    public class GameViewModel
    {
        public List<GameRound> Rounds { get; set; }
        public List<GameTeam> Teams { get; set; }
    }
}
