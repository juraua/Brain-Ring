using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicBrainRing.Client.Classes
{
    public class GameRound
    {
        public String Type { get; set; }
        public List<GameQuestion> Questions { get; set; }
        public int Timer { get; set; }

    }
}
