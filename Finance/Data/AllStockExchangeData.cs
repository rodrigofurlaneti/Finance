﻿using Finance.Models;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Finance.Web.Data
{
    public static class AllStockExchangeData
    {
        static string connectionString = "Server=rodrigofurlaneti3108_Finance.sqlserver.dbaas.com.br,1433;Database=rodrigofurlaneti3108_Finance;User Id=rodrigofurlaneti3108_Finance;Password=Digo310884@";

        public static List<Active> GetAllActive()
        {
            List<Active> listActive = new List<Active>();

            string storedProcedureName = "Finance_Procedure_Active_GetAll";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Active active = new Active();
                            active.IdActive = reader.GetInt32(reader.GetOrdinal("IdActive"));
                            active.Kind = reader.GetString(reader.GetOrdinal("Kind"));
                            active.Symbol = reader.GetString(reader.GetOrdinal("Symbol"));
                            active.Name = reader.GetString(reader.GetOrdinal("Name"));
                            active.CompanyName = reader.GetString(reader.GetOrdinal("Company_name"));
                            active.Document = reader.GetString(reader.GetOrdinal("Document"));
                            active.Description = reader.GetString(reader.GetOrdinal("Description"));
                            active.Website = reader.GetString(reader.GetOrdinal("Website"));
                            active.Sector = reader.GetString(reader.GetOrdinal("Sector"));
                            active.Region = reader.GetString(reader.GetOrdinal("Region"));
                            active.Currency = reader.GetString(reader.GetOrdinal("Currency"));
                            active.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                            active.ChangePrice = reader.GetDecimal(reader.GetOrdinal("Change_price"));
                            active.ChangePercent = reader.GetDecimal(reader.GetOrdinal("Change_percent"));
                            active.MarketCap = reader.GetDecimal(reader.GetOrdinal("MarketCap"));
                            active.Financials = new Financials();
                            active.Financials.Equity = reader.GetDecimal(reader.GetOrdinal("Equity"));
                            active.Financials.Equity_per_share = reader.GetDecimal(reader.GetOrdinal("Equity_per_share"));
                            active.Financials.Price_to_book_ratio = reader.GetDecimal(reader.GetOrdinal("Price_to_book_ratio"));
                            active.Financials.Quota_count = reader.GetDecimal(reader.GetOrdinal("Quota_count"));
                            active.Financials.Dividends = new Dividends();
                            active.Financials.Dividends.Yield_12m = reader.GetDecimal(reader.GetOrdinal("Yield_12m"));
                            active.Financials.Dividends.Yield_12m_sum = reader.GetDecimal(reader.GetOrdinal("Yield_12m_sum"));
                            active.MarketTime = new MarketTime();
                            active.MarketTime.OpenTime = reader.GetString(reader.GetOrdinal("OpenTime"));
                            active.MarketTime.CloseTime = reader.GetString(reader.GetOrdinal("CloseTime"));
                            active.MarketTime.Timezone = reader.GetInt32(reader.GetOrdinal("Timezone"));
                            active.Logo = new Logo();
                            active.Logo.Small = reader.GetString(reader.GetOrdinal("Small"));
                            active.Logo.Big = reader.GetString(reader.GetOrdinal("Big"));
                            active.UpdatedAt = reader.GetString(reader.GetOrdinal("Updated_at"));
                            listActive.Add(active);
                        }
                    }
                }
            }

            return listActive;
        }
    }
}
