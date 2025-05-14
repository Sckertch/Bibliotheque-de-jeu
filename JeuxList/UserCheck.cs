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

                            // modif détermine si le mot de passe a été modifié afin de redirigé l'utilisateur vers la page de modification de mot de passe
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
    }
}
