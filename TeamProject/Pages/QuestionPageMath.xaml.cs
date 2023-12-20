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
    /// Логика взаимодействия для QuestionPageMath.xaml
    /// </summary>
    public partial class QuestionPageMath : Page
    {
        private int QuestionCount;
        private List<string> AllQuestionList;
        private List<string> AllAnswerList;
        private ExerciseMath exercise = new ExerciseMath();
        public string QuestionText { get; set; }
        private int question;
        public QuestionPageMath(int questionCount)
        {
            QuestionCount = questionCount;
            MathQuestionGetter mg = new MathQuestionGetter();
            AllQuestionList = mg.GetQuestions("MathQuestions.txt");
            AllAnswerList = mg.GetAnswers("MathAnswers.txt");
            Random r = new Random();
            question = r.Next(AllAnswerList.Count);
            QuestionText = AllQuestionList[question];
            DataContext = this;
            InitializeComponent();
        }
        private void AcceptBtnClick(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text == "" || InputBox.Text.Length > 20)
            {
                messagePopup.Visibility = Visibility.Visible;
                return;
            }
            exercise.QuestionList.Add(AllQuestionList[question]);
            exercise.AnswerList.Add(AllAnswerList[question]);
            QuestionCount--;
            messagePopup.Visibility = Visibility.Collapsed;
            if (InputBox.Text.ToLower() == AllAnswerList[question])
            {
                exercise.UserCorrectAnswersCount++;
            }

            if (QuestionCount == 0)
            {
                NavigationService.Navigate(new EndPage(exercise));
            }
            else
            {
                NextQuestion();
            }
        }
        private void NextQuestion()
        {
            Random r = new Random();
            question = r.Next(AllAnswerList.Count);
            QuestionText = AllQuestionList[question];
            Question.Text = QuestionText;
            InputBox.Text = "";
        }
    }
}
