using System;
using System.Collections.Generic;
using System.IO;
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
    public static class Controller
    {
        static int i { get; set; } = 0;
        
    }
    public class AnagramGetter : IGetter
    {
        List<string> ReadListFromFile(string filename, string foldername)
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
        public List<string> GetAnswers(string filename)
        {
            return ReadListFromFile(filename, "Answers");
        }

        public List<string> GetExercise(string filename)
        {
            return ReadListFromFile(filename, "Questions");
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
