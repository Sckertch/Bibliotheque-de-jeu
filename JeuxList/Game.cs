using MySql.Data.MySqlClient;
using System;

namespace JeuxList
{
    public class Game
    {
        public int? GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public string NbJoueur { get; set; }
        public int Age { get; set; }
        public int Duree { get; set; }

        // Constructeur avec paramètres
        public Game(string title, string description, string categoryName, int quantity, string nbJoueur, int age, int duree, int? id = null)
        {
            GameId = id;
            Title = title;
            Description = description;
            CategoryName = categoryName;
            Quantity = quantity;
            NbJoueur = nbJoueur;
            Age = age;
            Duree = duree;
        }

        public static List<Game> GetGames(DatabaseConnection dbConnection, string key = "")
        {

            List<Game> games = new List<Game>();
            string query = "SELECT Title, Description, CategoryName, Quantity, GameID, NombreJoueurs, AgeRecommande, DureeJeuMoyenne FROM games JOIN categories ON games.CategoryId = categories.CategoryId WHERE Title LIKE '%" + key + "%' OR Description LIKE '%" + key + "%' OR CategoryName LIKE '%" + key + "%';";

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                dbConnection.OpenConnection(connection);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Game game = new Game(
                                reader.GetString("Title"),
                                reader.GetString("Description"),
                                reader.GetString("CategoryName"),
                                reader.GetInt32("Quantity"),
                                reader.GetString("NombreJoueurs"),
                                reader.GetInt32("AgeRecommande"),
                                reader.GetInt32("DureeJeuMoyenne"),
                                reader.GetInt32("GameID")
                            );
                            games.Add(game);
                        }
                    }
                }
                dbConnection.CloseConnection(connection);
            }
            return games;
        }

        public static List<string> GetCategories(DatabaseConnection dbConnection)
        {
            string query = "SELECT CategoryName FROM categories;";
            List<string> categories = new List<string>();
            using(MySqlConnection connection = dbConnection.GetConnection())
            {
                dbConnection.OpenConnection(connection);
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(reader.GetString("CategoryName"));
                        }
                    }
                }
                dbConnection.CloseConnection(connection);
            }
            return categories;
        }
    }
}
