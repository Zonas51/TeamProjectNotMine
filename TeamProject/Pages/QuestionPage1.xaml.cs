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

namespace TeamProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionPage1.xaml
    /// </summary>
    public partial class QuestionPage1 : Page
    {
        private static AnagramGetter Ag = new AnagramGetter();
        public static string QuestionText { get; set; } = "text";
        private static List<string> QuestionList = Ag.GetExercise("AnagramQuestions.txt");
        private static List<string> AnswerList = Ag.GetAnswers("AnagramAnswers.txt");
        private string UserAnswer;
        private int question;

        public QuestionPage1()
        {
            question = MainWindow.rand.Next(AnswerList.Count);
            QuestionText = QuestionList[question];
            DataContext = this;
            InitializeComponent();
        }


        private void AcceptBtnClick(object sender, RoutedEventArgs e)
        {
            UserAnswer = InputBox.Text;
            MainWindow.AddAnswer(QuestionList[question], AnswerList[question], UserAnswer);
            ExerciseController.NavigateQuestion(this.NavigationService);
        }
    }
}
