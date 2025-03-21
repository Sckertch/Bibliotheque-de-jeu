using MySql.Data.MySqlClient;
using System;


namespace JeuxList
{
    public class User
    {
        public string Nom { get; set; }
        public int? UserId { get; set; }

        public int? UserBorrow { get; set; }

        public User(string nom, int? userId = null, int? userBorrow = null)
        {
            Nom = nom;
            UserId = userId;
            UserBorrow = userBorrow;
        }

        public static List<User> GetUsers(DatabaseConnection dbConnection)
        {
            List<User> users = new List<User>();
            string query = "SELECT u.Username, u.UserID, COUNT(b.BorrowingID) AS BorrowCount FROM users u LEFT JOIN borrowing b ON u.UserID = b.UserID GROUP BY u.Username, u.UserID;";
            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                dbConnection.OpenConnection(connection);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User(
                                reader.GetString("Username"),
                                reader.GetInt32("UserID"),
                                reader.GetInt32("BorrowCount")
                            );
                            users.Add(user);
                        }
                    }
                }
                dbConnection.CloseConnection(connection);
            }
            return users;
        }

        // une fonction qui génére aléatoairement un mot de passe de 10 caratères
        public static string GeneratePassword()
        {
            string password = "";
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                password += (char)random.Next(33, 126);
            }
            return password;
        }

        // fonction qui hash un mot de passe
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        //fonction qui modifie un mot de passe en fonction de l'id
        public static bool UpdatePassword(int id, string password,string modif, DatabaseConnection dbConnection)
        {
            try
            {
                string query = "UPDATE users SET PasswordHash = @password, modif = @modif WHERE UserID = @id";
                using (MySqlConnection connection = dbConnection.GetConnection())
                {
                    dbConnection.OpenConnection(connection);
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@password", User.HashPassword(password));
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@modif", modif);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.CloseConnection(connection);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
    }
}
