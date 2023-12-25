using DidacticTrainClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidacticTrainClassLibrary.Classes
{
    public class Statistics : IStatistics
    {
        public IUser User { get; set; }
        public int UserCorrectAnswersCount { get; set; }
        public int AllAnswersCount { get; set; }
        public string ExName { get; set; }
    }
}
