using Finance.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Finance.Change.Data
{
    public class ActiveData
    {
        string connectionString = "Server=rodrigofurlaneti3108_Finance.sqlserver.dbaas.com.br;Database=Finance;User Id=rodrigofurlaneti3108_Finance;Password=_;";

        public List<Active> GetActive()
        {
            List<Active> list = new List<Active>();

            string storedProcedureName = "SP_Get_All_Active";

            SqlDataReader sqlDataReader = null;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    Int32 rowsAffected;

                    cmd.CommandText = storedProcedureName;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();

                    rowsAffected = cmd.ExecuteNonQuery();

                    sqlDataReader = cmd.ExecuteReader();
                }
            }

            return list;
        }

        public void PostActive(Active active)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string storedProcedureName = "SP_Post_Active";

            SqlCommand sqlCommand = new SqlCommand(storedProcedureName, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add("@Document", SqlDbType.Int).Value = active.Document;

            sqlCommand.Parameters.Add("@Change_percent", SqlDbType.NVarChar, 50).Value = active.Change_percent;
            
            sqlCommand.Parameters.Add("@Change_price", SqlDbType.NVarChar, 30).Value = active.Change_price;
            
            sqlCommand.Parameters.Add("@Currency", SqlDbType.NVarChar, 20).Value = active.Currency;

            sqlCommand.Parameters.Add("@Company_name", SqlDbType.NVarChar, 50).Value = active.Company_name;

            sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = active.Description;

            sqlCommand.Parameters.Add("@Financials", SqlDbType.NVarChar, 50).Value = active.Financials;

            sqlCommand.Parameters.Add("@Kind", SqlDbType.NVarChar, 50).Value = active.Kind;

            sqlCommand.Parameters.Add("@Price", SqlDbType.Float, 50).Value = active.Price;

            sqlCommand.Parameters.Add("@Logo", SqlDbType.NVarChar, 50).Value = active.Logo;

            sqlCommand.Parameters.Add("@Market_cap", SqlDbType.NVarChar, 50).Value = active.Market_cap;

            sqlCommand.Parameters.Add("@Market_time", SqlDbType.NVarChar, 50).Value = active.Market_time;

            sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = active.Name;

            sqlCommand.Parameters.Add("@Price", SqlDbType.NVarChar, 50).Value = active.Price;

            sqlCommand.Parameters.Add("@Region", SqlDbType.NVarChar, 50).Value = active.Region;

            sqlCommand.Parameters.Add("@Sector", SqlDbType.NVarChar, 50).Value = active.Sector;

            sqlCommand.Parameters.Add("@Symbol", SqlDbType.NVarChar, 50).Value = active.Symbol;

            sqlCommand.Parameters.Add("@Updated_at", SqlDbType.NVarChar, 50).Value = active.Updated_at;

            sqlCommand.Parameters.Add("@Website", SqlDbType.NVarChar, 50).Value = active.Website;

            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();
        }

        public async Task<Active> GetActiveApiAsync(string active)
        {
            Active list = new Active();

            string key = "6c0850e0";

            string route = "https://api.hgbrasil.com/finance/stock_price?key=" + key + "&symbol=" + active;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(route);

            client.DefaultRequestHeaders.Accept.Add(

            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = await response.Content.ReadAsStringAsync();

                list = JsonSerializer.Deserialize<Active>(dataObjects);
            }

            client.Dispose();

            return list;
        }
    }
}
