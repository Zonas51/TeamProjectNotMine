using DidacticTrainClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public interface IUser
    {
        string Name { get; set; }
        string Group { get; set; }
        string Age {  get; set; }
        Exercise Exercise { get; set; }
    }
    public interface  IGetter
    {
        List<string> GetQuestions(string filename);
        List<string> GetAnswers(string filename);
    }
    public interface ISaver
    {
        void Save(IUser usr);
    }
}
