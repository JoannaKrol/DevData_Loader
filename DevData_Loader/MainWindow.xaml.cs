using System.Data;
using System.Windows;
using DevData_Loader.Adapters;

namespace DevData_Loader
{
    public partial class MainWindow : Window
    {
        private readonly ConfigurationAdapter configAdapter = new ConfigurationAdapter();
        private readonly DataBaseAdapter dataBaseAdapter;
        
        public MainWindow()
        {
            configAdapter.GetConfiguration("../../../ConfigurationAdapter.json");
            dataBaseAdapter = new DataBaseAdapter(configAdapter.Config);

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
                if (dataBaseAdapter.TestConnectionByUser(tbLogin.Text, pwPassword.Password, out string mess))
                {
                    btnLoadData.IsEnabled = true;
                    MessageBox.Show(mess, "Nawiązano połączenie", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    btnLoadData.IsEnabled = false;
                    MessageBox.Show(mess, "Nieudane logowanie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnLoadData_Click(object sender, RoutedEventArgs e)
        {
            dgData.DataContext = new DataTable();

            string sqlCommand = "select * from DevData.INFORMATION_SCHEMA.COLUMNS";
            
            var dt = dataBaseAdapter.GetSqlResult(tbLogin.Text, pwPassword.Password, sqlCommand, out string err);

            if (err.Equals(""))
            {
                var intTypeColumns = dt.AsEnumerable().Where(r => r.Field<string>("DATA_TYPE") == "int");

                dgData.DataContext = intTypeColumns.CopyToDataTable();
            }
            else
            {
                MessageBox.Show(err, "Nieudane wykonanie zapytania", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
