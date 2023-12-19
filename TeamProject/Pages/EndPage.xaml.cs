using System.Windows;
using System.Windows.Controls;

namespace TeamProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        IExercise exercise;
        IUser user;
        public EndPage(IExercise ex)
        {
            exercise = ex;
            InitializeComponent();
        }

        private void AptButtonClick(object sender, RoutedEventArgs e)
        {
            user = new User(Name.Text,Group.Text,Age.Text, exercise);
            ExcelSaver ex = new ExcelSaver();
            ex.Save(user);
            Application.Current.Shutdown();
        }
    }
}
