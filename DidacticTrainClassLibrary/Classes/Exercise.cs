using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidacticTrainClassLibrary
{
    public abstract class Exercise
    {
        public List<string> QuestionList { get; set; } = new List<string>();
        public List<string> AnswerList { get; set; } = new List<string>();
        public readonly string Name;
    }
    public class ExerciseAnagram : Exercise
    {
        public readonly new string Name = "Анаграммы";
    }
    public class ExerciseMath : Exercise
    {
        public readonly new string Name = "Математика";
    }
}
