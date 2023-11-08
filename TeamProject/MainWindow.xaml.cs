using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeamProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random rand = new Random();
        private static List<string> QuestionList = new List<string>();
        private static List<string> AnswerList = new List<string>(); //TODO: сделать 1 лист для ответа пользователя (bool)
        private static List<string> UserAnswerList = new List<string>();
        public static int QuestionNumber { get; set; } = 5;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Pages.StartPage();
        }
        public static List<string> GetQuestionList()
        {
            return QuestionList;
        }
        public static List<string> GetAnswerList()
        {
            return AnswerList;
        }
        public static List<string> GetUserAnswerList()
        {
            return UserAnswerList;
        }

        public static void AddAnswer(string question, string answer, string userAnswer)
        {
            QuestionList.Add(question);
            AnswerList.Add(answer);
            UserAnswerList.Add(userAnswer);
        }
    }
}
