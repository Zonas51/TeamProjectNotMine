using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    interface IUser
    {
        string Name { get; set; }
        string Group { get; set; }
        string Age {  get; set; }
        List<String> Answers { get; set; }
    }
    interface IGetter
    {
        List<string> GetExercise(string filename);
        List<string> GetAnswers(string filename);
    }
}
