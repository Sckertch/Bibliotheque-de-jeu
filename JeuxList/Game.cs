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

        public static bool AddGame(Game game, DatabaseConnection dbConnection)
        {
            try
            {
                using (MySqlConnection connection = dbConnection.GetConnection())
                {
                    dbConnection.OpenConnection(connection);
                    string query = "INSERT INTO games (Title, Description, CategoryID, Quantity, NombreJoueurs, AgeRecommande, DureeJeuMoyenne) VALUES (@Title, @Description, (SELECT CategoryID FROM categories WHERE CategoryName = @CategoryName), @Quantity, @NombreJoueurs, @AgeRecommande, @DureeJeuMoyenne);";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", game.Title);
                        command.Parameters.AddWithValue("@Description", game.Description);
                        command.Parameters.AddWithValue("@CategoryName", game.CategoryName);
                        command.Parameters.AddWithValue("@Quantity", game.Quantity);
                        command.Parameters.AddWithValue("@NombreJoueurs", game.NbJoueur);
                        command.Parameters.AddWithValue("@AgeRecommande", game.Age);
                        command.Parameters.AddWithValue("@DureeJeuMoyenne", game.Duree);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.CloseConnection(connection);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        // Update a game in database
        public static bool UpdateGame(Game game, DatabaseConnection dbConnection)
        {
            try
            {
                using (MySqlConnection connection = dbConnection.GetConnection())
                {
                    dbConnection.OpenConnection(connection);
                    string query = "UPDATE games SET Title = @Title, Description = @Description, CategoryID = (SELECT CategoryID FROM categories WHERE CategoryName = @CategoryName), Quantity = @Quantity, NombreJoueurs = @NombreJoueurs, AgeRecommande = @AgeRecommande, DureeJeuMoyenne = @DureeJeuMoyenne WHERE GameID = @GameID;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", game.Title);
                        command.Parameters.AddWithValue("@Description", game.Description);
                        command.Parameters.AddWithValue("@CategoryName", game.CategoryName);
                        command.Parameters.AddWithValue("@Quantity", game.Quantity);
                        command.Parameters.AddWithValue("@NombreJoueurs", game.NbJoueur);
                        command.Parameters.AddWithValue("@AgeRecommande", game.Age);
                        command.Parameters.AddWithValue("@DureeJeuMoyenne", game.Duree);
                        command.Parameters.AddWithValue("@GameID", game.GameId);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.CloseConnection(connection);
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        // Search a game in the database


        public static bool CheckGame(Game game)
        {
            if (string.IsNullOrEmpty(game.Title) || string.IsNullOrEmpty(game.CategoryName) || game.Quantity <= 0 || string.IsNullOrEmpty(game.NbJoueur) || game.Age <= 0 || game.Duree <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
