using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidacticTrainClassLibrary.Interfaces
{
    public interface IStatistics
    {
        IUser User { get; set; }
        int UserCorrectAnswersCount { get; set; }
        int AllAnswersCount { get; set; }
        string ExName { get; set; }
    }
}
