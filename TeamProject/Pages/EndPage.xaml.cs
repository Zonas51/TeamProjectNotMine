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
        IStatistics statistics;
        ISaver Saver = new ExcelSaver();
        public EndPage(IStatistics _statistics)
        {
            statistics = _statistics;
            InitializeComponent();
        }
        
        private void AptButtonClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Group.Text == "" || Age.Text == "" ||
                Name.Text.Length > 40 || Group.Text.Length > 20 || StringIsDigits(Age.Text) == false || 
                int.Parse(Age.Text) > 100 || int.Parse(Age.Text) < 0)
            {
                messagePopup.Visibility = Visibility.Visible;
                Name.Text = "";
                Group.Text = "";
                Age.Text = "";
                return;
            }
            statistics.User = new User(Name.Text,Group.Text,Age.Text);
            Saver.Save(statistics);
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
