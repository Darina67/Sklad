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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private User _currentUser = new User();
        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = _currentUser;
        }


        static string HashPassword(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }




        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Password.Text = HashPassword(Password.Text);
            _currentUser.Password = Password.Text;

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentUser.FIO))
                errors.AppendLine("Введите Ф.И.О");
            if (string.IsNullOrWhiteSpace(_currentUser.City))
                errors.AppendLine("Введите город");
            if (string.IsNullOrWhiteSpace(_currentUser.Adress))
                errors.AppendLine("Введите адрес");
            if (string.IsNullOrWhiteSpace(_currentUser.Phone))
                errors.AppendLine("Введите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentUser.Email))
                errors.AppendLine("Введите email");
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
            {
                SkladEntities.GetContext().Users.Add(_currentUser);


                {
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


    }
}

