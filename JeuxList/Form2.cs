using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JeuxList
{
    public partial class Form2 : Form
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();
        private Form1 form1;
        private string connectUser;
        private Dictionary<string, int> gameDictionary = new Dictionary<string, int>();

        public Form2(Form1 form1, string connectUser)
        {
            InitializeComponent();
            InitializeDataGridView();
            LoadDataGridView();
            this.form1 = form1;
            this.connectUser = connectUser;

            addCart.Enabled = false;
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
            // Activer le bouton addCart si une ligne est sélectionnée
            addCart.Enabled = ListBoxGames.SelectedRows.Count > 0;
        }
        private void addCart_Click(object sender, EventArgs e)
        {
            if (ListBoxGames.SelectedRows.Count > 0)
            {
                string gameName = ListBoxGames.SelectedRows[0].Cells["Title"].Value.ToString();
                if (gameDictionary.ContainsKey(gameName))
                {
                    gameDictionary[gameName]++;
                }
                else
                {
                    gameDictionary[gameName] = 1;
                }
            }

            MessageBox.Show("Le jeu a été ajouté au panier" + gameDictionary);
        }

        private void ListBoxGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

