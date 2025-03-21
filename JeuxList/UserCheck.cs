using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxList
{
    public class UserCheck
    {
        public string name { get; set; }
        public int status { get; set; }
        public int? id { get; set; }

        public UserCheck(string name = "", int status = 0, int? id = null)
        {
            this.name = name;
            this.status = status;
            this.id = id;
        }

        public UserCheck identification(User user, DatabaseConnection dbConnection, string? mdp = null)
        {

            string query = "SELECT * FROM users WHERE Username = @nom AND PasswordHash = @mdp";

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                dbConnection.OpenConnection(connection);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", user.Nom);
                    command.Parameters.AddWithValue("@mdp", mdp);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32("UserID");
                            string nom = reader.GetString("Username");
                            int status = reader.GetInt32("Role");
                            int modif = reader.GetInt32("modif");

                            if (modif == 1)
                            {
                                status = 3;
                            }

                            return new UserCheck(nom, status, id);
                        }
                    }
                }
                dbConnection.CloseConnection(connection);
            }

            return new UserCheck("null", 0);
        }

        // Fonction qui verifie si un utilisateur avec le meme Username existe
        public bool checkUser(User user, DatabaseConnection dbConnection)
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

        // fonction qui ajoute un utilisateur a la bdd
        public bool addUser(User user, string role, DatabaseConnection dbConnection)
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
    }
}
