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
    /// Логика взаимодействия для MakeOrderPage.xaml
    /// </summary>
    public partial class MakeOrderPage : Page
    {
        private ordercomposition _currentodercomposition = new ordercomposition();
        public MakeOrderPage(ordercomposition selectedordercomposition)
        {
            if (selectedordercomposition != null)
                _currentodercomposition = selectedordercomposition;
            DataContext = _currentodercomposition;
            InitializeComponent();
            ComboAssortment.ItemsSource = SkladEntities.GetContext().Assortments.ToList();
        }

        private void InfoAssortment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentodercomposition.Count == null || _currentodercomposition.Count < 10)
                errors.AppendLine("Укажите количество - минимальное количество от 100шт; для категории - сладкое - от 10шт.");
            if (_currentodercomposition.Assortment.Name == null)
                errors.AppendLine("выберите товар со склада");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentodercomposition.Id == 0)
                SkladEntities.GetContext().ordercompositions.Add(_currentodercomposition);

            try
            {
                SkladEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
