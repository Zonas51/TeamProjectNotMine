using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

namespace DidacticTrainClassLibrary
{
    public abstract class ExerciseQuestionGetter : IGetter
    {
        internal virtual List<string> ReadListFromFile(string filename, string foldername)
        {
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
        internal override List<string> ReadListFromFile(string filename, string foldername)
        {
            string filepath = AppContext.BaseDirectory + "..\\..\\" + foldername + "\\" + filename;
            List<string> AnList = new List<string>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                string[] input = sr.ReadToEnd().Replace("\r", "").Split('\n');
                foreach (string item in input)
                {
                    AnList.Add(item);
                }
            }
            return AnList;
        }
    }
}
