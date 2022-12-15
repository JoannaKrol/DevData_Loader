using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using DevData_Loader.Adapters;

namespace DevData_Loader
{
    public partial class MainWindow : Window
    {
        private readonly ConfigurationAdapter configAdapter = new ConfigurationAdapter();
        
        public MainWindow()
        {
            configAdapter.GetConfiguration("../../../ConfigurationAdapter.json");

            InitializeComponent();
        }

        private void DisabledLoadBtn()
        {
            if(btnLoadData.IsEnabled)
            {
                btnLoadData.IsEnabled = false;
                dgData.DataContext = new DataTable();
                MessageBox.Show("Zmieniono dane do logowania. Sprwdź ponownie połączenie z bazą danych", "Zmieniono dane", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            dgData.DataContext = new DataTable();

            if (tbLogin.Text.Length == 0)
            {
                MessageBox.Show("Login nie może być pusty", "Błędne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                tbLogin.Focus();
            }
            else if (pwPassword.Password.Length == 0)
            {
                MessageBox.Show("Hasło nie może być puste", "Błędne dane", MessageBoxButton.OK, MessageBoxImage.Error);
                pwPassword.Focus();
            }
            else
            {
                string serverName = configAdapter.Config.ServerName;
                string dataBase = configAdapter.Config.DataBaseName;
                string login = tbLogin.Text;
                string password = pwPassword.Password;

                SqlConnection con = new SqlConnection($"Data Source={serverName};Initial Catalog={dataBase};User id={login};Password={password}");

                try
                {
                    con.Open();
                    btnLoadData.IsEnabled = true;
                    MessageBox.Show($"Nawiązano połączanie z bazą daneych {dataBase}", "Nawiązano połączenie", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    btnLoadData.IsEnabled = false;
                    MessageBox.Show($"Nie udało się połączuć z bazą danych {dataBase}. Powód: {ex.Message}", "Nieudane logowanie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void BtnLoadData_Click(object sender, RoutedEventArgs e)
        {
            dgData.DataContext = new DataTable();

            string serverName = configAdapter.Config.ServerName;
            string dataBase = configAdapter.Config.DataBaseName;
            string login = tbLogin.Text;
            string password = pwPassword.Password;

            string sqlCommand = "select * from DevData.INFORMATION_SCHEMA.COLUMNS where DATA_TYPE = 'int'";

            DataTable dt;

            using (SqlConnection con = new SqlConnection($"Data Source={serverName};Initial Catalog={dataBase};User id={login};Password={password}"))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.CommandType = CommandType.Text;
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                dt = dataSet.Tables[0];
            }

            dgData.DataContext = dt.DefaultView;
        }

        private void TbLogin_Change(object sender, RoutedEventArgs e)
        {
            DisabledLoadBtn();
        }
        private void PwPassword_Change(object sender, RoutedEventArgs e)
        {
            DisabledLoadBtn();
        }
    }
        
}
