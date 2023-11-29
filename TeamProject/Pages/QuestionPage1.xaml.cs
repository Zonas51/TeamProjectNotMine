using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int QuestionCount;
        private List<string> AllQuestionList;
        private List<string> AllAnswerList;
        private ExerciseAnagram exercise = new ExerciseAnagram();
        private Random Random = new Random();
        public string QuestionText { get; set; }
        private int question;


        public QuestionPage1(int questionCount)
        {
            QuestionCount = questionCount;
            AnagramQuestionGetter ag = new AnagramQuestionGetter();
            AllQuestionList = ag.GetQuestions("AnagramQuestions.txt");
            AllAnswerList = ag.GetAnswers("AnagramAnswers.txt");

            question = Random.Next(AllAnswerList.Count);
            QuestionText = AllQuestionList[question];
            DataContext = this;
            InitializeComponent();
        }


        private void AcceptBtnClick(object sender, RoutedEventArgs e)
        {
            exercise.QuestionList.Add(AllQuestionList[question]);
            exercise.AnswerList.Add(AllAnswerList[question]);
            QuestionCount--;
            if (InputBox.Text == AllAnswerList[question])
            {
                exercise.UserCorrectAnswersCount++;
            }

            if (QuestionCount == 0)
            {
                NavigationService.Navigate(new EndPage(exercise));
            }
            else
            {
                question = Random.Next(AllAnswerList.Count);
                QuestionText = AllQuestionList[question];
                Question.Text = QuestionText;
                InputBox.Text = "";
            }
        }
    }
}
