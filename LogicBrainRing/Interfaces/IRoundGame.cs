using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBrainRing.Enums;

namespace LogicBrainRing.Interfaces
{
    public interface IRoundGame
    {
        int Id { get; set; }
        RoundType RoundType { get; set; }
        int QuestionCount { get; set; }
        int AllPoints { get; set; }
    }
}
