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
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        public EndPage()
        {
            InitializeComponent();
        }

        private void AptButtonClick(object sender, RoutedEventArgs e)
        {
            User user = new User(Name.Text,Group.Text,Age.Text, MainWindow.GetAnswerList());
            ExcelSaver ex = new ExcelSaver();
            ex.Save(user);
            Application.Current.Shutdown();
        }
    }
}
