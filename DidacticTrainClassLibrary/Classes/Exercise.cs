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
        public int UserCorrectAnswersCount { get; set; } = 0;
    }
    public class ExerciseAnagram : Exercise
    {
    }
    public class ExerciseMath : Exercise
    {
    }
}
