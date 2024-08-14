using Finance.Data.Interface;
using Finance.Domain;
using System.Data;

namespace Finance.Data.Repository
{
    public class AllStockExchangeData : IAllStockExchangeData
    {
        private readonly IDbConnectionWrapper _connection;

        public AllStockExchangeData(IDbConnectionWrapper connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Active>> GetAllActiveAsync()
        {
            List<Active> listActive = new List<Active>();

            string storedProcedureName = "Finance_Procedure_Active_GetAll";

            using (var command = _connection.CreateCommand())
            {
                command.SetCommandText(storedProcedureName);
                command.SetCommandType(CommandType.StoredProcedure);

                _connection.Open();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Active active = new Active
                        {
                            IdActive = reader.GetInt32(reader.GetOrdinal("IdActive")),
                            Kind = reader.GetString(reader.GetOrdinal("Kind")),
                            Symbol = reader.GetString(reader.GetOrdinal("Symbol")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            CompanyName = reader.GetString(reader.GetOrdinal("Company_name")),
                            Document = reader.GetString(reader.GetOrdinal("Document")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Website = reader.GetString(reader.GetOrdinal("Website")),
                            Sector = reader.GetString(reader.GetOrdinal("Sector")),
                            Region = reader.GetString(reader.GetOrdinal("Region")),
                            Currency = reader.GetString(reader.GetOrdinal("Currency")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            ChangePrice = reader.GetDecimal(reader.GetOrdinal("Change_price")),
                            ChangePercent = reader.GetDecimal(reader.GetOrdinal("Change_percent")),
                            MarketCap = reader.GetDecimal(reader.GetOrdinal("MarketCap")),
                            Financials = new Financials
                            {
                                Equity = reader.GetInt64(reader.GetOrdinal("Equity")),
                                Equity_per_share = reader.GetDecimal(reader.GetOrdinal("Equity_per_share")),
                                Price_to_book_ratio = reader.GetDecimal(reader.GetOrdinal("Price_to_book_ratio")),
                                Quota_count = reader.GetInt64(reader.GetOrdinal("Quota_count")),
                                Dividends = new Dividends
                                {
                                    Yield_12m = reader.GetDecimal(reader.GetOrdinal("Yield_12m")),
                                    Yield_12m_sum = reader.GetDecimal(reader.GetOrdinal("Yield_12m_sum"))
                                }
                            },
                            MarketTime = new MarketTime
                            {
                                OpenTime = reader.GetString(reader.GetOrdinal("OpenTime")),
                                CloseTime = reader.GetString(reader.GetOrdinal("CloseTime")),
                                Timezone = reader.GetInt32(reader.GetOrdinal("Timezone"))
                            },
                            Logo = new Logo
                            {
                                Small = reader.GetString(reader.GetOrdinal("Small")),
                                Big = reader.GetString(reader.GetOrdinal("Big"))
                            },
                            UpdatedAt = reader.GetString(reader.GetOrdinal("Updated_at"))
                        };
                        listActive.Add(active);
                    }
                }
            }

            return listActive;
        }

        public IEnumerable<Active> GetAllActive()
        {
            List<Active> listActive = new List<Active>();

            string storedProcedureName = "Finance_Procedure_Active_GetAll";

            using (var command = _connection.CreateCommand())
            {
                command.SetCommandText(storedProcedureName);

                command.SetCommandType(CommandType.StoredProcedure);

                _connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Active active = new Active
                        {
                            IdActive = reader.GetInt32(reader.GetOrdinal("IdActive")),
                            Kind = reader.GetString(reader.GetOrdinal("Kind")),
                            Symbol = reader.GetString(reader.GetOrdinal("Symbol")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            CompanyName = reader.GetString(reader.GetOrdinal("Company_name")),
                            Document = reader.GetString(reader.GetOrdinal("Document")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            Website = reader.GetString(reader.GetOrdinal("Website")),
                            Sector = reader.GetString(reader.GetOrdinal("Sector")),
                            Region = reader.GetString(reader.GetOrdinal("Region")),
                            Currency = reader.GetString(reader.GetOrdinal("Currency")),
                            Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                            ChangePrice = reader.GetDecimal(reader.GetOrdinal("Change_price")),
                            ChangePercent = reader.GetDecimal(reader.GetOrdinal("Change_percent")),
                            MarketCap = reader.GetDecimal(reader.GetOrdinal("MarketCap")),
                            Financials = new Financials
                            {
                                Equity = reader.GetInt64(reader.GetOrdinal("Equity")),
                                Equity_per_share = reader.GetDecimal(reader.GetOrdinal("Equity_per_share")),
                                Price_to_book_ratio = reader.GetDecimal(reader.GetOrdinal("Price_to_book_ratio")),
                                Quota_count = reader.GetInt64(reader.GetOrdinal("Quota_count")),
                                Dividends = new Dividends
                                {
                                    Yield_12m = reader.GetDecimal(reader.GetOrdinal("Yield_12m")),
                                    Yield_12m_sum = reader.GetDecimal(reader.GetOrdinal("Yield_12m_sum"))
                                }
                            },
                            MarketTime = new MarketTime
                            {
                                OpenTime = reader.GetString(reader.GetOrdinal("OpenTime")),
                                CloseTime = reader.GetString(reader.GetOrdinal("CloseTime")),
                                Timezone = reader.GetInt32(reader.GetOrdinal("Timezone"))
                            },
                            Logo = new Logo
                            {
                                Small = reader.GetString(reader.GetOrdinal("Small")),
                                Big = reader.GetString(reader.GetOrdinal("Big"))
                            },
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
