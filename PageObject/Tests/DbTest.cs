using NUnit.Framework;
using PageObject.Services;

namespace PageObject
{
    public class DbTest
    {
        [Test]
        public void dbTest1()
        {
            SimpleSqlService.OpenSqlConnection();
            SimpleSqlService.DropTable("users");
            SimpleSqlService.CreateUsersTable();
            SimpleSqlService.CloseConnection(); 
        }
    }
}