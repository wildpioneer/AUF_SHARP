using System;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;

namespace PageObject
{
    public class LinqTest
    {
        [Test]
        public void LinqTest1()
        {
            string[] teams = new[] {"Иван", "Петр", "Сергей"};

            var user = from s in teams
                where s.ToUpper().StartsWith("И")
                orderby s
                select s;

            var user1 = teams.Where(t => t.ToUpper().StartsWith("П")).OrderBy(t => t);
            
            
            foreach (var use in user)
            {
                Console.Out.WriteLine(use);
            }

            foreach (var use in user1)
            {
                Console.Out.WriteLine(use);
            }
        }
    }
}