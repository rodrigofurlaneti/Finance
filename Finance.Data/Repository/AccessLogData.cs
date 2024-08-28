using Finance.Data.Interface;
using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Finance.Data.Repository
{
    public class AccessLogData : IAccessLogData
    {
        private readonly IDbConnectionWrapper _connection;
        private readonly string _connectionString;

        public AccessLogData(IDbConnectionWrapper connection, IConfiguration configuration)
        {
            _connection = connection;
            _connectionString = configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
        }

        public async Task<IEnumerable<AccessLog>> GetAsync()
        {
            List<AccessLog> list = new List<AccessLog>();

            string storedProcedureName = "Finance_Procedure_Order_GetAll";

            try
            {
                using (var command = _connection.CreateCommand())
                {
                    command.SetCommandText(storedProcedureName);

                    command.SetCommandType(CommandType.StoredProcedure);

                    _connection.Open();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            AccessLog accessLog = new AccessLog
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Latitude = reader.GetString(reader.GetOrdinal("Latitude")),
                                Longitude = reader.GetString(reader.GetOrdinal("Longitude")),
                                InternetProtocol = reader.GetString(reader.GetOrdinal("InternetProtocol")),
                                UserAgent = reader.GetString(reader.GetOrdinal("UserAgent"))
                            };
                            
                            list.Add(accessLog);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"Erro de SQL: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erro: {ex.Message}");
                throw;
            }

            return list;
        }

        public async Task PostAsync(AccessLog accessLog)
        {
            string storedProcedureName = "Finance_Procedure_AccessLog_Insert";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Latitude", accessLog.Latitude);
                        command.Parameters.AddWithValue("@Longitude", accessLog.Longitude);
                        command.Parameters.AddWithValue("@UserAgent", accessLog.UserAgent);
                        command.Parameters.AddWithValue("@InternetProtocol", accessLog.InternetProtocol);

                        await connection.OpenAsync();

                        await command.ExecuteScalarAsync();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"Erro de SQL: {sqlEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erro: {ex.Message}");
                throw;
            }
        }


    }
}
