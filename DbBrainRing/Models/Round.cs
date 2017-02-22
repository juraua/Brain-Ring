using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbBrainRing.Enums;

namespace DbBrainRing.Models
{
    public class Round
    {
        public int Id { get; set; }
        public RoundType RoundType { get; set; }
        public int QuestionCount { get; set; }
        public int AllPoints { get; set; }
    }
}
