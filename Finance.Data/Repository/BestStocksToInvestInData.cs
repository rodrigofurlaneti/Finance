using Finance.Data.Interface;
using Finance.Domain;
using System.Data;

namespace Finance.Data.Repository
{
    public class BestStocksToInvestInData : IBestStocksToInvestInData
    {
        private readonly IDbConnectionWrapper _connection;

        public BestStocksToInvestInData(IDbConnectionWrapper connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<BestStocksToInvestIn>> GetAllBestStocksToInvestInAsync()
        {
            List<BestStocksToInvestIn> listBestStocksToInvestIn = new List<BestStocksToInvestIn>();

            string storedProcedureName = "Finance_Procedure_BestStocksToInvestIn_GetAll";

            using (var command = _connection.CreateCommand())
            {
                command.SetCommandText(storedProcedureName);
                command.SetCommandType(CommandType.StoredProcedure);

                _connection.Open();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        BestStocksToInvestIn bestStocksToInvestIn = new BestStocksToInvestIn
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Details = reader.GetString(reader.GetOrdinal("Details")),
                            UpdatedAt = reader.GetString(reader.GetOrdinal("Updated_at"))
                        };
                        listBestStocksToInvestIn.Add(bestStocksToInvestIn);
                    }
                }
            }

            return listBestStocksToInvestIn;
        }
    }
}
