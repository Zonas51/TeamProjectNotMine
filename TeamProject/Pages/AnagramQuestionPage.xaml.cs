using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TeamProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionPage1.xaml
    /// </summary>
    public partial class AnagramQuestionPage : Page
    {
        private int QuestionCount;
        private List<string> AllQuestionList;
        private List<string> AllAnswerList;
        private ExerciseAnagram exercise = new ExerciseAnagram();
        private Random Random = new Random();
        public string QuestionText { get; set; }
        private int question;


        public AnagramQuestionPage(int questionCount)
        {
            QuestionCount = questionCount;
            MathQuestionGetter ag = new MathQuestionGetter();
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
            question = Random.Next(AllAnswerList.Count);
            QuestionText = AllQuestionList[question];
            Question.Text = QuestionText;
            InputBox.Text = "";
        }
    }
}
