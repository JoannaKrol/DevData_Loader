using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace DevData_Loader
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text.Length == 0)
            {
                MessageBox.Show("Login jest pusty");
                tbLogin.Focus();
            }
            else if (pwPassword.Password.Length == 0)
            {
                MessageBox.Show("Hasło jest pusty");
                pwPassword.Focus();
            }
            else
            {
                string dataBase = "DevData";
                string serverName = @"";
                string login = tbLogin.Text;
                string password = pwPassword.Password;

                //SqlConnection con = new SqlConnection($"Data Source={serverName};Initial Catalog={dataBase};User id={login};Password={password}");
                SqlConnection con = new SqlConnection($"Data Source={serverName};Initial Catalog={dataBase};Integrated Security=True");

                try
                {
                    con.Open();
                    btnLoadData.IsEnabled = true;
                    MessageBox.Show($"Nawiązano połączanie z bazą daneych {dataBase}");
                }
                catch (Exception ex)
                {
                    btnLoadData.IsEnabled = false;
                    MessageBox.Show($"Nie udało się połączuć z bazą danych {dataBase}. Powód: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            string dataBase = "DevData";
            string serverName = @"LAPTOP-HT1B4DTO\LOCALDB";

            string sqlCommand = "select * from DevData.INFORMATION_SCHEMA.COLUMNS where DATA_TYPE = 'int'";
            //string sqlCommand = "select * from DevData.INFORMATION_SCHEMA.COLUMNS";

            DataRowCollection dr;

            using (SqlConnection con = new SqlConnection($"Data Source={serverName};Initial Catalog={dataBase};Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.CommandType = CommandType.Text;
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                dr = dataSet.Tables[0].Rows;
            }
        }
    }
}
