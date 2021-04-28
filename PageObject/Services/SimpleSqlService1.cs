using System;
using System.IO;
using System.Reflection;
using Npgsql;

namespace PageObject.Services
{
    public class SimpleSqlService1
    {
        private static NpgsqlConnection _connection; 
        private static NpgsqlCommand _cmd;
        
        public static void OpenConnection()
        {
            if (_connection == null)
            {
                string connectionString = GetConnectionString();
                _connection = new NpgsqlConnection(connectionString);
                _connection.Open();
                Console.Out.WriteLine("ServerVersion: {0}", _connection.ServerVersion);
                Console.Out.WriteLine("State: {0}", _connection.State);
            }
        }

        public static void CloseConnection()
        {
            _connection.Close();
            Console.Out.WriteLine("State: {0}", _connection.State);
        }
        
        private static string GetConnectionString()
        {
            return "Host=localhost;" +
                   "Username=aleksandr.trostyanko;" +
                   "Password=;" +
                   "Database=postgres;" +
                   "Port=5433;";
        }

        public static NpgsqlDataReader ExecuteSQL(string sql)
        {
            using var cmd = new NpgsqlCommand(sql, _connection);
            return cmd.ExecuteReader();
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
    }
}