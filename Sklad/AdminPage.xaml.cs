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

namespace Sklad
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void DataAllUsers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AllUsersPageAdmin());
        }

        private void DataAllAssortment_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AssortmentPage());
            
        }
    }
}
