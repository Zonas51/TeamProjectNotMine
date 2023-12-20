using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidacticTrainClassLibrary.Interfaces
{
    public interface IGetter
    {
        List<string> GetQuestions(string filename);
        List<string> GetAnswers(string filename);
    }
}
