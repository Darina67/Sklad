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
    /// Логика взаимодействия для AllUsersPageAdmin.xaml
    /// </summary>
    public partial class AllUsersPageAdmin : Page
    {
        public AllUsersPageAdmin()
        {
            InitializeComponent();
            DGDataAllUsers.ItemsSource = SkladEntities.GetContext().Users.ToList();
        }

        private void BtnEditDataUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditDataUserAdminPage((sender as Button).DataContext as User));

        }

        private void BtnAddDataUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditDataUserAdminPage(null));
        }

        private void BtnDelDataUser_Click(object sender, RoutedEventArgs e)
        {
            var UserForRemoving = DGDataAllUsers.SelectedItems.Cast<User>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {UserForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    SkladEntities.GetContext().Users.RemoveRange(UserForRemoving);
                    SkladEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                   DGDataAllUsers.ItemsSource = SkladEntities.GetContext().Users.ToList();


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
           DGDataAllUsers.ItemsSource = SkladEntities.GetContext().Users.ToList();
        }
    }
}
