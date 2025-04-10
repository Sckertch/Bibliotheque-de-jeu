using JeuxList;

namespace BiblioTests
{
    [TestClass]
    public sealed class Connection
    {
        [TestMethod]
        public void adminConnexion()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Information de connexion
            User username = new User("admin");
            var password = "hash_admin_password";

            UserCheck userCheck = new UserCheck().identification(username, dbConnection, User.HashPassword(password));

            Assert.AreEqual(1, userCheck.status);
        }

        [TestMethod]

        public void userConnexion()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Information de connexion
            User username = new User("alice");
            var password = "1234";

            UserCheck userCheck = new UserCheck().identification(username, dbConnection, User.HashPassword(password));

            Assert.AreEqual(2, userCheck.status);
        }
    }


}
