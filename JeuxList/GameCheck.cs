using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxList
{
    public class GameCheck
    {
        public GameCheck()
        {

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


        public bool CheckGame(Game game)
        {
            if (string.IsNullOrEmpty(game.Title) || string.IsNullOrEmpty(game.CategoryName) || game.Quantity <= 0 || string.IsNullOrEmpty(game.NbJoueur) || game.Age <= 0 || game.Duree <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
