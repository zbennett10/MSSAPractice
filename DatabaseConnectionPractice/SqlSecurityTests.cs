using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;


namespace Baseball.Data.Sql.IntegrationTests
{
    public class SqlSecurityTests
    {
        private const string connectionString = "Server=DESKTOP-DB1S6AO\\SQLZACH;Database=Baseball;Integrated Security=true;";

        [Test]
        public void WhenUserDoesNotExist_ThrowsException()
        {
            var security = new SqlSecurity(connectionString);
            Assert.Throws<InvalidOperationException>(() =>
            {
                security.Authenticate("FAKEUSERNAME", "FAKEPASSWORD");
            });
        }

        [Test]
        public void WhenPasswordIsWrong_ThrowException()
        {
            var security = new SqlSecurity(connectionString);
            Assert.Throws<InvalidOperationException>(() => 
            {
                security.Authenticate("Bravo", "FAKEPASSWORD");
            });
        }

        [Test]
        public void WhenUsernameAndPasswordAreCorrect_ReturnsCorrectPerson()
        {
            var security = new SqlSecurity(connectionString);
            var person = security.Authenticate("Alpha", "pass1");
            Assert.AreEqual(1, person.PersonId);
            Assert.AreEqual(false, person.IsPlayer);
            Assert.AreEqual(true, person.IsCaptain);
            Assert.AreEqual("Alpha Is Awesome", person.DisplayName);
        }

    }
}
