using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RestApiWithDapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithDapper.Models
{
    public class EmployeeAction : IDapper
    {
        private readonly IConfiguration Config;
        private string ConnectionString = "DefaultConnection";
        public EmployeeAction(IConfiguration config)
        {
            Config = config;
        }
        public void Dispose()
        {
           
        }

        public int Execute(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(ConnectionString)))
            {
                return dbConnection.Execute(storeprocedure, parameters, commandType: commandType);
            }
        }

        public T Get<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(ConnectionString)))
            {
                return dbConnection.Query<T>(storeprocedure, parameters, commandType: commandType).FirstOrDefault();
            }
        }

        public List<T> GetAll<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(ConnectionString)))
            {
                return dbConnection.Query<T>(storeprocedure, parameters, commandType: commandType).ToList();
            }
        }

        public DbConnection GetDbConnection()
        {
            return new SqlConnection(Config.GetConnectionString(ConnectionString));
        }

        public T Insert<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(ConnectionString)))
            {
                T result;
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                try
                {
                    result = dbConnection.Query<T>(storeprocedure, parameters, commandType: commandType).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
                return result;
            }
        }

        public T Update<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(ConnectionString)))
            {
                T result;
                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                
                    try
                    {
                        result = dbConnection.Query<T>(storeprocedure, parameters, commandType: commandType).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                }
                return result;
            }
        }
    }
}
