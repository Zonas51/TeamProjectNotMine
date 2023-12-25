using DidacticTrainClassLibrary;
using DidacticTrainClassLibrary.Classes;
using DidacticTrainClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace TeamProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionPage1.xaml
    /// </summary>
    public partial class AnagramQuestionPage : Page
    {
        IStatistics stat = new Statistics();

        private int QuestionCount;
        private List<string> AllQuestionList;
        private List<string> AllAnswerList;
        private ExerciseAnagram exercise = new ExerciseAnagram();
        public string QuestionText { get; set; }
        private int question;


        public AnagramQuestionPage(int questionCount)
        {
            QuestionCount = questionCount;
            AnagramQuestionGetter ag = new AnagramQuestionGetter();
            AllQuestionList = ag.GetQuestions("AnagramQuestions.txt");
            AllAnswerList = ag.GetAnswers("AnagramAnswers.txt");
            Random r = new Random();
            question = r.Next(AllAnswerList.Count);
            QuestionText = AllQuestionList[question];
            DataContext = this;
            stat.ExName = exercise.Name;
            InitializeComponent();
        }


        private void AcceptBtnClick(object sender, RoutedEventArgs e)
        {
            if (InputBox.Text == "" || InputBox.Text.Length > 20)
            {
                messagePopup.Visibility = Visibility.Visible;
                InputBox.Text = "";
                return;
            }
            exercise.QuestionList.Add(AllQuestionList[question]);
            exercise.AnswerList.Add(AllAnswerList[question]);
            QuestionCount--;
            messagePopup.Visibility = Visibility.Collapsed;
            if (InputBox.Text.ToLower().Trim() == AllAnswerList[question])
            {
                stat.UserCorrectAnswersCount++;
            }
            stat.AllAnswersCount++;
            if (QuestionCount == 0)
            {
                NavigationService.Navigate(new EndPage(stat));
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
