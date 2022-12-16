using DevData_Loader.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DevData_Loader.Adapters
{
    public class DataBaseAdapter
    {
        public string ServerName { get; set; }
        public string DataBaseName { get; set; }

        public DataBaseAdapter(ConfigurationModel model)
        {
            ServerName = model.ServerName;
            DataBaseName = model.DataBaseName;
        }

        public bool TestConnectionByUser(string login, string password, out string mess)
        {
            bool result;

            SqlConnection con = new SqlConnection($"Data Source={ServerName};Initial Catalog={DataBaseName};User id={login};Password={password}");

            try
            {
                con.Open();
                result = true;
                mess = $"Nawiązano połączanie z bazą daneych {DataBaseName}";
            }
            catch (Exception ex)
            {
                result = false;
                mess = $"Nie udało się połączuć z bazą danych {DataBaseName}. Powód: {ex.Message}";
            }
            finally
            {
                con.Close();
            }

            return result;
        }

        public DataTable GetSqlResult(string login, string password, string query)
        {
            DataTable dt;

            using (SqlConnection con = new SqlConnection($"Data Source={ServerName};Initial Catalog={DataBaseName};User id={login};Password={password}"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                dt = dataSet.Tables[0];
            }

            return dt;
        }
    }
}
