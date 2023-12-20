using DidacticTrainClassLibrary.Interfaces;

namespace DidacticTrainClassLibrary
{
    public class User : IUser
    {
        public User(string name, string group, string age, Exercise exercise)
        {
            Name = name;
            Group = group;
            Age = age;
            Exercise = exercise;
        }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Age { get; set; }
        public Exercise Exercise { get; set; }
    }
}
