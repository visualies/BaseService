using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace BaseService.Data.Repositories
{
    internal abstract class RepositoryBase
    {
        private readonly IDbTransaction _transaction;
        private IDbConnection Connection => _transaction.Connection;

        protected RepositoryBase(IDbTransaction transaction)
        {
            this._transaction = transaction;
        }

        protected async Task<IEnumerable<T>> QueryFilteredAsync<T>(string table, object param)
        {
            var sql = $"SELECT * FROM {table} WHERE ";
            var statements = new List<string>();

            foreach (PropertyInfo prop in param.GetType().GetProperties())
            {
                if (prop.GetValue(param) == null) continue;
                statements.Add($"{prop.Name} = @{prop.Name}");
            }

            sql += string.Join(" AND ", statements);
            return await Connection.QueryAsync<T>(sql, param, _transaction);
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            return await Connection.QueryAsync<T>(sql, param, _transaction);
        }

        protected async Task ExecuteAsync(string sql, object param)
        {
            await Connection.ExecuteAsync(sql, param, _transaction);
        }

        protected void Execute(string sql)
        {
            Connection.Execute(sql, _transaction);
        }
    }
}
