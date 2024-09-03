using Finance.Data.Interface;
using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Data.Repository
{
    public class AnalyzeIndicatorsData : IAnalyzeIndicatorsData
    {
        private readonly IDbConnectionWrapper _connection;

        public AnalyzeIndicatorsData(IDbConnectionWrapper connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<Indicators>> GetAllAnalyzeIndicatorsAsync()
        {
            List<Indicators> listActive = new List<Indicators>();

            string storedProcedureName = "Finance_Procedure_Active_Valuation_Indicators_GetAll";

            using (var command = _connection.CreateCommand())
            {
                command.SetCommandText(storedProcedureName);

                command.SetCommandType(CommandType.StoredProcedure);

                _connection.Open();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Indicators active = new Indicators
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Symbol = reader.GetString(reader.GetOrdinal("Symbol")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            DividendYield = reader.GetDecimal(reader.GetOrdinal("DividendYield")),
                            PriceProfit = reader.GetDecimal(reader.GetOrdinal("PriceProfit")),
                            PriceOverAssetValue = reader.GetDecimal(reader.GetOrdinal("PriceOverAssetValue")),
                            ReturnOnEquity = reader.GetDecimal(reader.GetOrdinal("ReturnOnEquity")),
                            UpdatedAt = reader.GetString(reader.GetOrdinal("Updated_at"))
                        };
                        listActive.Add(active);
                    }
                }
            }

            return listActive;
        }
    }
}
