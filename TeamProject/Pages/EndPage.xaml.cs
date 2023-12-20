using DidacticTrainClassLibrary;
using DidacticTrainClassLibrary.Interfaces;
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
                Name.Text.Length > 40 || Group.Text.Length > 20 || Age.Text.Length > 100 ||
                StringIsDigits(Age.Text) == false )
            {
                messagePopup.Visibility = Visibility.Visible;
                Name.Text = "";
                Group.Text = "";
                Age.Text = "";
                return;
            }
            user = new User(Name.Text,Group.Text,Age.Text, exercise);
            Saver.Save(user);
            Application.Current.Shutdown();
        }
        private bool StringIsDigits(string s)
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
