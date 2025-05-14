using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JeuxList
{
    public partial class Form2 : Form
    {
        private DatabaseConnection dbConnection;
        private Form1 form1;
        private string connectUser;


        public Form2(Form1 form1, string connectUser, DatabaseConnection dbConnection)
        {
            ;
            this.form1 = form1;
            this.connectUser = connectUser;
            this.dbConnection = dbConnection;
            InitializeComponent();
            InitializeDataGridView();
            LoadDataGridView();
            Connect.Text = "Connecté en tant que " + this.connectUser;

        }

        private void InitializeDataGridView()
        {
            ListBoxGames.Columns.Add("Title", "Nom du jeu");
            ListBoxGames.Columns.Add("Description", "Description");
            ListBoxGames.Columns.Add("CategoryName", "Categoriez");
            ListBoxGames.Columns.Add("Quantity", "Quantité");
            ListBoxGames.Columns.Add("Joueur", "Nombre de Joueurs");
            ListBoxGames.Columns.Add("Age", "Age recommandé");
            ListBoxGames.Columns.Add("Duree", "Durée moyenne");

            ListBoxGames.Columns.Add("GameID", "GameID");
            ListBoxGames.Columns["GameID"].Visible = false;

            ListBoxGames.AllowUserToAddRows = false;  // Empêche l’ajout manuel de lignes
            ListBoxGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Sélection complète de la ligne

            // Ajuster la largeur de la colonne Description
            ListBoxGames.Columns["Title"].Width = 250;
            ListBoxGames.Columns["Description"].Width = 450; // Ajustez la largeur selon vos besoins
            ListBoxGames.Columns["CategoryName"].Width = 150;

            ListBoxGames.SelectionChanged += ListBoxGames_SelectionChanged;
        }


        private void LoadDataGridView()
        {
            List<Game> games = Game.GetGames(dbConnection);

            // Effacer les éléments existants dans le DataGridView
            ListBoxGames.Rows.Clear();

            // Ajouter les résultats au DataGridView
            foreach (Game game in games)
                ListBoxGames.Rows.Add(game.Title, game.Description, game.CategoryName, game.Quantity, game.NbJoueur, game.Age, game.Duree + " min", "✏️", game.GameId);
        }

        private void ListBoxGames_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void addCart_Click(object sender, EventArgs e)
        {

        }

        private void ListBoxGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void recherche_TextChanged(object sender, EventArgs e)
        {

        }
        private void decon_Click(object sender, EventArgs e)
        {

        }

        private void decon_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form != this && form.Owner == this)
                {
                    form.Close();
                }
            }
            this.form1.ResetValues();
            this.form1.Show(); // Afficher Form1 avant de fermer Form3
            this.Close(); // Fermer Form3
        }

        private void recherche_TextChanged_1(object sender, EventArgs e)
        {
            string keyword = recherche.Text;
            List<Game> games = Game.GetGames(this.dbConnection, keyword);

            // Effacer les éléments existants dans le DataGridView
            ListBoxGames.Rows.Clear();

            // Ajouter les résultats au DataGridView
            foreach (Game game in games)
                ListBoxGames.Rows.Add(game.Title, game.Description, game.CategoryName, game.Quantity, game.NbJoueur, game.Age, game.Duree, "✏️", game.GameId);

        }
    }
}

