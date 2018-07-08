using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Npgsql;

namespace ESP.Standard.Data.PostgreSql
{
    public class BaseRepository
    {
        protected string connectionString;

        public BaseRepository(string instanceName)
        {
            connectionString = ConnectionStringInitializer.GetConnectionString(instanceName);
        }

        private IDbConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        protected void Execute(string sql)
        {
            using(var dbConnection = GetConnection())
            {
                dbConnection.Open();
                dbConnection.Execute(sql);
            }
        }

        protected void Execute(string sql, object param)
        {
            using (var dbConnection = GetConnection())
            {
                dbConnection.Open();
                dbConnection.Execute(sql, param);
            }
        }

        protected List<T> Query<T>(string sql)
        {
            var result = new List<T>();
            using (var dbConnection = GetConnection())
            {
                dbConnection.Open();
                result = dbConnection.Query<T>(sql).ToList();
            }
            return result;
        }

        protected List<T> Query<T>(string sql, object param)
        {
            var result = new List<T>();
            using (var dbConnection = GetConnection())
            {
                dbConnection.Open();
                result = dbConnection.Query<T>(sql, param).ToList();
            }
            return result;
        }
    }
}
