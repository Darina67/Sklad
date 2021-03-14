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
    /// Логика взаимодействия для AssortmentPage.xaml
    /// </summary>
    public partial class AssortmentPage : Page
    {
        public AssortmentPage()
        {
            InitializeComponent();
            //  DGAssortment.ItemsSource = SkladEntities.GetContext().Assortments.ToList();
        }

        private void BtnEditAssortment_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditAssortmentPage((sender as Button).DataContext as Assortment));

        }

        private void BtnAddAssort_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditAssortmentPage(null));
        }

        
        private void BtnDelAssort_Click(object sender, RoutedEventArgs e)
        {
            var AssortForRemoving = DGAssortment.SelectedItems.Cast<Assortment>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {AssortForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    SkladEntities.GetContext().Assortments.RemoveRange(AssortForRemoving);
                    SkladEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGAssortment.ItemsSource = SkladEntities.GetContext().Assortments.ToList();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SkladEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGAssortment.ItemsSource = SkladEntities.GetContext().Assortments.ToList();
        }
    }
}
