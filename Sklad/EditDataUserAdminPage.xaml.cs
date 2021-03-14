using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для EditDataUserAdminPage.xaml
    /// </summary>
    public partial class EditDataUserAdminPage : Page
    {
        private User _currentUser = new User();

        public EditDataUserAdminPage(User selectedUser)
        {
            if (selectedUser != null)
                _currentUser = selectedUser;
            DataContext = _currentUser;
            InitializeComponent();
            ComboRole.ItemsSource = SkladEntities.GetContext().Roles.ToList();
        }

       
        

        public static string HashPassword(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
      

        private void BtnSaveDataUser_Click(object sender, RoutedEventArgs e)
        {
            PasswordUser.Text = HashPassword(PasswordUser.Text);
            _currentUser.Password = PasswordUser.Text;
            StringBuilder errors = new StringBuilder();
            if (_currentUser.Role1 == null)
                errors.AppendLine("Выберите роль пользователя");
            if (string.IsNullOrWhiteSpace(_currentUser.FIO))
                errors.AppendLine("Введите ФИО");
            if (string.IsNullOrWhiteSpace(_currentUser.City))
                errors.AppendLine("Введите город");
            if (string.IsNullOrWhiteSpace(_currentUser.Adress))
                errors.AppendLine("Укажите остатки товара");
            if (string.IsNullOrWhiteSpace(_currentUser.Phone))
                errors.AppendLine("Введите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentUser.Email))
                errors.AppendLine("Введите почту");
            if (string.IsNullOrWhiteSpace(_currentUser.Login))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
                errors.AppendLine("Введите пароль");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentUser.Id == 0)
                SkladEntities.GetContext().Users.Add(_currentUser);

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
