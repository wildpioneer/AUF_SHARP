using System;
using NUnit.Framework;
using PageObject.Services;

namespace PageObject
{
    public class SQLTest
    {
        [Test]
        public void ConnectionTest()
        {
            SimpleSqlService1.OpenConnection();
            SimpleSqlService1.DropTable("users");
            SimpleSqlService1.CreateUsersTable();
            
            var results = SimpleSqlService1.ExecuteSQL("select * from users;");
            while (results.Read())
            {
                Console.Out.WriteLine("{0} {1} {2}", results.GetInt32(0), results.GetString(1), results.GetString(2));
            }
            
            SimpleSqlService1.CloseConnection();
        }
    }
}