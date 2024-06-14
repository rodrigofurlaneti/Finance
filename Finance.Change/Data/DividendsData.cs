using Finance.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Finance.Change.Data
{
    public class DividendsData
    {
        string connectionString = "Server=rodrigofurlaneti3108_Finance.sqlserver.dbaas.com.br;Database=Finance;User Id=rodrigofurlaneti3108_Finance;Password=Digo310884@;";

        public List<Dividends> GetDividends()
        {
            List<Dividends> list = new List<Dividends>();

            string storedProcedureName = "SP_Get_All_Dividends";

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

        public void PostDividends(Dividends dividends)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string storedProcedureName = "SP_Post_Dividends";

            SqlCommand sqlCommand = new SqlCommand(storedProcedureName, sqlConnection);

            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add("@Yield_12m", SqlDbType.Float).Value = dividends.Yield_12m;

            sqlCommand.Parameters.Add("@Yield_12m_sum", SqlDbType.Float).Value = dividends.Yield_12m_sum;

            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();
        }

        public async Task<Dividends> GetDividendsApiAsync(string dividends)
        {
            Dividends list = new Dividends();

            string key = "6c0850e0";

            string route = "https://api.hgbrasil.com/finance/stock_price?key=" + key + "&symbol=" + dividends;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(route);

            client.DefaultRequestHeaders.Accept.Add(

            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                var dataObjects = await response.Content.ReadAsStringAsync();

                list = JsonSerializer.Deserialize<Dividends>(dataObjects);
            }

            client.Dispose();

            return list;
        }
    }
}
