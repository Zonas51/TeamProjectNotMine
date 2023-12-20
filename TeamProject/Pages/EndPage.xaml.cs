using DidacticTrainClassLibrary;
using System.Windows;
using System.Windows.Controls;

namespace TeamProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        Exercise exercise;
        IUser user;
        ISaver Saver = new ExcelSaver();
        public EndPage(Exercise ex)
        {
            exercise = ex;
            InitializeComponent();
        }
        
        private void AptButtonClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Group.Text == "" || Age.Text == "" ||
                Name.Text.Length > 40 || Group.Text.Length > 20 || StringIsDigits(Age.Text) == false ||
                Age.Text.Length > 100)
            {
                messagePopup.Visibility = Visibility.Visible;
                return;
            }
            user = new User(Name.Text,Group.Text,Age.Text, exercise);
            Saver.Save(user);
            Application.Current.Shutdown();
        }
        bool StringIsDigits(string s)
        {
            foreach (var item in s)
            {
                if (!char.IsDigit(item))
                    return false; 
            }
            return true;
        }
    }
}
