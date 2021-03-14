using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace Sklad
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();
        public AuthorizationPage()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Ticktimer);
            timer.Interval = new TimeSpan(0, 0, 10);
        }


        int count_attempt = 3;

        private void Ticktimer(object sender, EventArgs e)
        {

            MessageBox.Show("Время истекло. Можете попробовать ввести данные заново!");
            count_attempt = 3;
            timer.Stop();
        }
        enum Role { Supplier, Admin, Сustomer, Failed }

        static Role GetRole(string login, string password)
        {
            Role role = Role.Failed;
            using (var connection = new SqlConnection("server=GET-OUT-PC;Trusted_Connection=Yes;Database=Sklad;"))
            {
                connection.Open();
                var command = new SqlCommand("Select [Role] From Users WHERE login=@Login AND password=@Password", connection);

                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", HashPassword(password));

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        switch ((int)dataReader["Role"])
                        {
                            case 1: role = Role.Admin; break;
                            case 0: role = Role.Сustomer; break;
                            case 2: role = Role.Supplier; break;

                        }
                        connection.Close();
                    }
                }
            }

            return role;

        }


        // кодировка паролей
        public static string HashPassword(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }


        //

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                pwdTextBox.Text = PassBox.Password; // скопируем в TextBox из PasswordBox
                pwdTextBox.Visibility = Visibility.Visible; // TextBox - отобразить
                PassBox.Visibility = Visibility.Hidden; // PasswordBox - скрыть
            }
            else
            {
                PassBox.Password = pwdTextBox.Text; // скопируем в PasswordBox из TextBox 
                pwdTextBox.Visibility = Visibility.Hidden; // TextBox - скрыть
                PassBox.Visibility = Visibility.Visible; // PasswordBox - отобразить
            }
        }





        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            Role role = GetRole(LoginBox.Text, PassBox.Password);
            if (role == Role.Failed)
            {
                MessageBox.Show("Логин или пароль введен неверно!");
                count_attempt--;
            }

            if (count_attempt < 0)
            {
                MessageBox.Show("Лимит попыток исчерпан. Подождите 10 сек до новой попытки");
                timer.Start();
            }
            if (count_attempt > 0 && role == Role.Admin)
            {
                Manager.MainFrame.Navigate(new AdminPage());

            }
            if (count_attempt > 0 && role == Role.Supplier)
            {
                Manager.MainFrame.Navigate(new SupplierPage());
            }
            if (count_attempt > 0 && role == Role.Сustomer)
            {
                Manager.MainFrame.Navigate(new CustomerPage());
            }
            LoginBox.Text = null;
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());
        }
    }
}
