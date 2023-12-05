using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spire.Xls;

namespace TeamProject
{
    public class User : IUser
    {
        public User(string name, string group, string age, IExercise exercise) 
        {
            Name = name;
            Group = group;
            Age = age;
            Exercise = exercise;
        }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Age { get; set; }
        public IExercise Exercise { get; set; }
    }
    public class ExerciseAnagram : IExercise
    {
        public List<string> QuestionList { get; set; } = new List<string>();
        public List<string> AnswerList { get; set; } = new List<string>();
        public int UserCorrectAnswersCount { get; set; } = 0;

        public int GetUserCorrectAnswersCount()
        {
            return UserCorrectAnswersCount;
        }
    }
    public abstract class ExerciseQuestionGetter : IGetter
    {
        internal static List<string> ReadListFromFile(string filename, string foldername)
        {
            //TODO: make it read each line individually
            string filepath = AppContext.BaseDirectory + "..\\..\\" + foldername + "\\" + filename;
            List<string> AnList = new List<string>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                string[] input = sr.ReadToEnd().Split();
                foreach (string item in input)
                {
                    AnList.Add(item);
                }
            }
            return AnList;
        }
        public virtual List<string> GetAnswers(string filename)
        {
            return ReadListFromFile(filename, "Answers");
        }
        public virtual List<string> GetQuestions(string filename)
        {
            return ReadListFromFile(filename, "Questions");
        }
    }
    public class AnagramQuestionGetter : ExerciseQuestionGetter
    {
        public override List<string> GetQuestions(string filename)
        {

            List<string> list = ReadListFromFile(filename, "Questions");
            for (int i = 0; i < list.Count(); i++)
            {
                list[i] = Scramble(list[i]);
            }
            return list;
        }
        private string Scramble(string input)
        {
            char[] array = input.ToCharArray();
            do
            {
                Random rng = new Random();
                int n = array.Length;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    char temp = array[k];
                    array[k] = array[n];
                    array[n] = temp;
                }
            } while (array.ToString() == input);
            return new string(array);
        }
    }
    public class MathQuestionGetter : ExerciseQuestionGetter
    {
        public override List<string> GetAnswers(string filename)
        {
            throw new NotImplementedException(); //TODO: make
        }

        public List<string> GetExercise(string filename)
        {
            throw new NotImplementedException(); //TODO: make
        }
    }

    public class ExcelSaver : ISaver
    {
        public void Save(IUser usr)
        {
            Workbook workbook = new Workbook();
            if (File.Exists("Results.xlsx"))
            {
                workbook.LoadTemplateFromFile("Results.xlsx");
            }
            Worksheet worksheet = workbook.Worksheets[0];

            worksheet.InsertRow(1);
            worksheet[1, 1].Text = $"{usr.Name}";
            worksheet[1, 2].Text = $"{usr.Group}";
            worksheet[1, 3].Text = $"{usr.Age}";
            worksheet[1, 4].Text = $"{usr.Exercise.UserCorrectAnswersCount}/{usr.Exercise.AnswerList.Count}";

            workbook.SaveToFile("Results.xlsx", ExcelVersion.Version2016);
        }
    }
}
