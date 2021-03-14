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
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public SupplierPage()
        {
            InitializeComponent();

        }

        private void BtnDataSupplier_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DataSupplierPage());
        }

        private void BtnAssortment_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AssortmentPage());
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
