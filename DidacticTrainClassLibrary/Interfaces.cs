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
        IExercise Exercise { get; set; }
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
    public interface IExercise
    {
        List<string> QuestionList { get; set; }
        List<string> AnswerList { get; set; }
        int UserCorrectAnswersCount { get; set; }

        int GetUserCorrectAnswersCount();
    }
}
