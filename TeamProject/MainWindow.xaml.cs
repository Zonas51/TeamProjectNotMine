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
        public static List<string> QuestionList = new List<string>();
        public static List<string> AnswerList = new List<string>();
        public static List<string> UserAnswerList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        public static List<string> GetQuestionList()
        {
            return QuestionList;
        }
        public static void SetQuestionList()
        {
            throw new NotImplementedException(); //TODO:!!!
        }
        public static List<string> GetAnswerList()
        {
            return QuestionList;
        }
        public static void SetAnswerList()
        {
            throw new NotImplementedException(); //TODO:!!!
        }
        public static List<string> GetUserAnswerList()
        {
            return QuestionList;
        }
        public static void AddUserAnswer()
        {
            throw new NotImplementedException(); //TODO:!!!
        }
    }
}
