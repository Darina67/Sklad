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
    /// Логика взаимодействия для EditAssortmentPage.xaml
    /// </summary>
    public partial class EditAssortmentPage : Page
    {
        private Assortment _currentAssort = new Assortment();
        public EditAssortmentPage(Assortment selectedAssort)

        {
            if (selectedAssort != null)
                _currentAssort = selectedAssort;
            DataContext = _currentAssort;
            InitializeComponent();
            ComboCategory.ItemsSource = SkladEntities.GetContext().Categories.ToList();
            ComboManufacturer.ItemsSource = SkladEntities.GetContext().Manufacturers.ToList();
        }

        private void BtnSaveAssort_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentAssort.Name))
                errors.AppendLine("Введите название товара");
            if (_currentAssort.Category1 == null)
                errors.AppendLine("Выберите категорию товара");
            if (string.IsNullOrWhiteSpace(_currentAssort.Remains))
                errors.AppendLine("Укажите остатки товара");
            if (_currentAssort.Price == null)
                errors.AppendLine("Укажите стоимость за 100 товаров - 1ой и 2ой категории и за 10 товаров 3-ей категории");
            if (_currentAssort.Manufacturer1 == null)
                errors.AppendLine("Выберите производителя");
            if (string.IsNullOrWhiteSpace(_currentAssort.Descriprion))
                errors.AppendLine("Введите описание товара");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentAssort.Id == 0)
                SkladEntities.GetContext().Assortments.Add(_currentAssort);

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
