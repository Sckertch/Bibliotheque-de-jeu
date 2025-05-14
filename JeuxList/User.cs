using MySql.Data.MySqlClient;
using System;


namespace JeuxList
{
    public class User
    {
        public string Nom { get; set; }
        public int? UserId { get; set; }


        public User(string nom, int? userId = null)
        {
            Nom = nom;
            UserId = userId;
        }

        public static List<User> GetUsers(DatabaseConnection dbConnection)
        {
            List<User> users = new List<User>();
            string query = "SELECT u.Username, u.UserID FROM users u GROUP BY u.Username, u.UserID;";
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
                                reader.GetInt32("UserID")
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

        // fonction qui ajoute un utilisateur a la bdd
        public static bool AddUser(User user, string role, DatabaseConnection dbConnection)
        {
            switch (role)
            {
                case "Admin":
                    role = "1";
                    break;
                case "Utilisateur":
                    role = "2";
                    break;
            }

            string newMdp = User.GeneratePassword();

            try
            {
                string query = "INSERT INTO users (Username, PasswordHash, Role, modif) VALUES (@nom, @mdp, @role, @modif)";
                using (MySqlConnection connection = dbConnection.GetConnection())
                {
                    dbConnection.OpenConnection(connection);
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nom", user.Nom);
                        command.Parameters.AddWithValue("@mdp", User.HashPassword(newMdp));
                        command.Parameters.AddWithValue("@role", role);
                        command.Parameters.AddWithValue("@modif", 1);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.CloseConnection(connection);
                }
                MessageBox.Show("Le mot de passe de l'utilisateur est : " + newMdp);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Fonction qui verifie si un utilisateur avec le meme Username existe
        public static bool CheckUser(User user, DatabaseConnection dbConnection)
        {
            string query = "SELECT * FROM users WHERE Username = @nom";
            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                dbConnection.OpenConnection(connection);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", user.Nom);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
                dbConnection.CloseConnection(connection);
            }
            return false;
        }
    }
}
