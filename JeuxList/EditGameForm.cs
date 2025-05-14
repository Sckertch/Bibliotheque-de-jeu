using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuxList
{
    public partial class EditGameForm : Form
    {
        private Game selectedGame;
        private DatabaseConnection dbConnection;
        private Form3 parentForm;
        private DataGridViewButtonColumn btnEdit;
        public EditGameForm(Game game, DatabaseConnection dbConnection, Form3 parent, DataGridViewButtonColumn btnEdit)
        {
            InitializeComponent();
            this.selectedGame = game;
            this.dbConnection = dbConnection;
            this.parentForm = parent;
            this.btnEdit = btnEdit;

            // Remplir les champs avec les valeurs du jeu sélectionné
            modifNom.Text = selectedGame.Title;
            modifDes.Text = selectedGame.Description;
            modifCat.Text = selectedGame.CategoryName;
            modifQuant.Text = selectedGame.Quantity.ToString();
            nbj.Text = selectedGame.NbJoueur;
            age.Text = selectedGame.Age.ToString();
            duree.Text = selectedGame.Duree.ToString();

            LoadCategories();
        }

        private void LoadCategories()
        {
            List<string> categories = Game.GetCategories(dbConnection);
            modifCat.DataSource = categories;
        }
        private void btnEnreg_Click(object sender, EventArgs e)
        {
            string name = modifNom.Text;
            string description = modifDes.Text;
            string categegorie = modifCat.SelectedItem.ToString();
            int quantity = (int)modifQuant.Value;
            int id = (int)selectedGame.GameId;
            string nbJoueur = nbj.Text;
            int age = (int)selectedGame.Age;
            int duree = (int)selectedGame.Duree;

            Game game = new Game(name, description, categegorie, quantity, nbJoueur, age, duree, id);

            bool success = Game.UpdateGame(game, this.dbConnection); ///

            if (success)
            {
                MessageBox.Show("Jeu mis à jour avec succès !");
                this.parentForm.LoadDataGridView(this.btnEdit); // Rafraîchir la grille
                this.Close(); // Fermer la fenêtre
            }
            else
            {
                MessageBox.Show("Erreur lors de la mise à jour.");
            }
        }

        private void retour_Click(object sender, EventArgs e)
        {
            this.Close(); // Fermer Form3
        }
    }
}
