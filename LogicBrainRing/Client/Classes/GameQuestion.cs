using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicBrainRing.Client.Classes
{
    public class GameQuestion
    {
        public String Text { get; set; }
        public String Answer { get; set; }
        public int Points { get; set; }
        public List<String>  Variants { get; set; }
    }
}
