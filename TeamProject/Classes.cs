using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using TeamProject.Pages;
using Spire.Xls;
using Spire.Xls.Core;
using System.Security.RightsManagement;

namespace TeamProject
{
    public class User : IUser
    {
        public User(string name, string group, string age, List<string> answers) 
        {
            Name = name;
            Group = group;
            Age = age;
            Answers = answers;
        }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Age { get; set; }
        public List<string> Answers { get; set; }
    }
    public static class ExerciseController
    {
        public static int i { get; set; } = 0;

        private static int GetRandPageType() { return 0; } //TODO: make random
        public static void NavigateQuestion(NavigationService nav)
        {
            if (i > 0)
            {
                i--;
                switch (GetRandPageType())
                {
                    case 0:
                        nav.Navigate(new QuestionPage1());
                        break;
                }
            }
            else
            {
                nav.Navigate(new EndPage());
            }
        }
    }
    public abstract class ExerciseGetter : IGetter
    {
        internal List<string> ReadListFromFile(string filename, string foldername)
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
        public virtual List<string> GetExercise(string filename)
        {
            return ReadListFromFile(filename, "Questions");
        }
    }
    public class AnagramGetter : ExerciseGetter
    {
        public override List<string> GetExercise(string filename)
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
            worksheet.Range[1, 1].Value = $"{usr.Name}";
            worksheet.Range[1, 2].Value = $"{usr.Group}";
            worksheet.Range[1, 3].Value = $"{usr.Age}";

            workbook.SaveToFile("Results.xlsx", ExcelVersion.Version2016);
        }
    }
}
