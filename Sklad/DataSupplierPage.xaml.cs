using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для DataSupplierPage.xaml
    /// </summary>
    public partial class DataSupplierPage : Page
    {
  

      
       
        public DataSupplierPage()
        {
            InitializeComponent();

            //DGDataSupplier.ItemsSource = SkladEntities.GetContext().Users.ToList();

        }







    private void BtnShowData_Click(object sender, RoutedEventArgs e )
        {

         //   fiobox.Text = _currentuser.FIO;
            //string source = @"data source=get-out-pc;initial catalog=sklad;integrated security=true";
            //SqlConnection connection = new SqlConnection(source);
            //SqlCommand cmd = new SqlCommand
            //{
            // CommandText = "select FIO, City, Adress, Phone, Email from Users where Id=@Id"
            //};

            //MessageBox.Show("db connection!");
            //cmd.Connection = connection;
            //connection.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            // fiobox.Text = dr["FIO"].ToString();
            // citybox.Text = dr["City"].ToString();
            // Adressbox.Text = dr["Adress"].ToString();
            // Emailbox.Text = dr["Email"].ToString();
            // Phonebox.Text = dr["Phone"].ToString();
            //}
            //connection.Close();
        }

        private void BtnEditSupplier_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }

