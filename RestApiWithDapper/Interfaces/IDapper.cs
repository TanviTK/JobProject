using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiWithDapper.Interfaces
{
    public interface IDapper : IDisposable
    {
        DbConnection GetDbConnection();
        T Get<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string storeprocedure, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
