using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using NLog;
using Npgsql;

namespace PageObject.Services
{
    public class SimpleSqlService
    {
        private static NpgsqlConnection _connection;
        private static NpgsqlCommand _cmd;

        public static void OpenSqlConnection()
        {
            var logger = LogManager.GetCurrentClassLogger();

            if (_connection == null)
            {
                string connectionString = GetConnectionString();
                //_connection = new NpgsqlConnection(connectionString)
                //using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                _connection = new NpgsqlConnection(connectionString);
                _connection.Open();
                logger.Info("ServerVersion: {0}", _connection.ServerVersion);
                logger.Info("State: {0}", _connection.State);

                var sql = "SELECT version()";
                _cmd = new NpgsqlCommand(sql, _connection);

                var version = ExecuteSQL(sql);
                logger.Info($"PostgreSQL version: {version}");
            }
        }

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file, using the
            // System.Configuration.ConfigurationManager.ConnectionStrings property
            return "Host=localhost;" +
                   "Username=aleksandr.trostyanko;" +
                   "Password=;" +
                   "Database=postgres;" +
                   "Port=5433;";
        }

        public static string ExecuteSQL(string sql)
        {
            using var cmd = new NpgsqlCommand(sql, _connection);
            return cmd.ExecuteScalar().ToString();
        }

        public static void DropTable(string tableName)
        {
            string sql = $"drop table if exists {tableName} cascade;";
            using var cmd = new NpgsqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();
        }

        public static void CreateUsersTable()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var file = Path.Combine(basePath, "TestData", "SQL", "users.sql");
            var sql = File.ReadAllText(file);
            using var cmd = new NpgsqlCommand(sql, _connection);
            cmd.ExecuteNonQuery();
        }

        public static void CloseConnection()
        {
            _connection.Close();
            _connection = null;
        }
    }
}