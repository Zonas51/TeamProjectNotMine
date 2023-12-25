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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void BtnAnagramClick(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new AnagramQuestionPage(5));
            }
            catch (Exception)
            {

                messagePopup.Visibility = Visibility.Visible;
            }
            
        }

        private void BtnMathClick(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new QuestionPageMath(5));
            }
            catch (Exception)
            {

                messagePopup.Visibility = Visibility.Visible;
            }
        }

        private void ButtonExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
