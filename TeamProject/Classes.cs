using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class User : IUser
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Age { get; set; }
        public List<string> Answers { get; set; }
    }
    public class Controller
    {
        
    }
    public class AnagramGetter : IGetter
    {
        public List<string> GetAnswers(string filename)
        {
            throw new NotImplementedException(); //TODO: make
        }

        public List<string> GetExercise(string filename)
        {
            throw new NotImplementedException(); //TODO: make
        }
    }
    public class MathGetter : IGetter
    {
        public List<string> GetAnswers(string filename)
        {
            throw new NotImplementedException(); //TODO: make
        }

        public List<string> GetExercise(string filename)
        {
            throw new NotImplementedException(); //TODO: make
        }
    }
}
