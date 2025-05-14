namespace JeuxList //vue admin
{
    public partial class Form3 : Form
    {
        private DatabaseConnection dbConnection;
        private DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        private Form1 form1;
        private string connectUser;


        public Form3(Form1 form1, string connectUser, DatabaseConnection dbConnection)
        {
            this.form1 = form1;
            this.dbConnection = dbConnection;
            this.connectUser = connectUser;
            InitializeComponent();
            InitializeDataGridView();
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
            ListBoxGames.Columns.Add("Duree", "Durée moyenne (min)");

            this.btnEdit.Name = "Edit";
            this.btnEdit.HeaderText = "Modifier";
            this.btnEdit.Text = "✏️";
            this.btnEdit.UseColumnTextForButtonValue = true;
            this.ListBoxGames.Columns.Add("Edit", "Modifier");

            ListBoxGames.Columns.Add("GameID", "GameID");
            ListBoxGames.Columns["GameID"].Visible = false;

            ListBoxGames.AllowUserToAddRows = false;  // Empêche l’ajout manuel de lignes
            ListBoxGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Sélection complète de la ligne

            LoadDataGridView(btnEdit);


            // Ajuster la largeur de la colonne 
            ListBoxGames.Columns["Title"].Width = 250;
            ListBoxGames.Columns["Description"].Width = 450; // Ajustez la largeur selon vos besoins
            ListBoxGames.Columns["CategoryName"].Width = 150;
        }

        public void LoadDataGridView(DataGridViewButtonColumn btnEdit)
        {
            List<Game> games = Game.GetGames(this.dbConnection);

            // Effacer les éléments existants dans le DataGridView
            ListBoxGames.Rows.Clear();

            // Ajouter les résultats au DataGridView
            foreach (Game game in games)
                ListBoxGames.Rows.Add(game.Title, game.Description, game.CategoryName, game.Quantity, game.NbJoueur, game.Age, game.Duree, "✏️", game.GameId);
        }

        private Game ListBoxGames_SelectionChanged(object sender, EventArgs e)
        {
            string titlec;
            string descriptionc;
            string categoryc;
            int quantityc;
            int idc;
            string nbJoueur;
            int age;
            int duree;

            DataGridViewRow row = ListBoxGames.SelectedRows[0];
            titlec = row.Cells["Title"].Value.ToString();
            descriptionc = row.Cells["Description"].Value.ToString();
            categoryc = row.Cells["CategoryName"].Value.ToString();
            quantityc = int.Parse(row.Cells["Quantity"].Value.ToString());
            idc = int.Parse(row.Cells["GameID"].Value.ToString());
            nbJoueur = row.Cells["Joueur"].Value.ToString();
            age = int.Parse(row.Cells["Age"].Value.ToString());
            duree = int.Parse(row.Cells["Duree"].Value.ToString());



            return new Game(titlec, descriptionc, categoryc, quantityc, nbJoueur, age, duree, idc);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AjoutGame ajout = new AjoutGame(this, this.btnEdit);

            ajout.Show();
        }


        private void ListBoxGames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ListBoxGames.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = ListBoxGames.Rows[e.RowIndex];

                Game selectedGame = new Game(
                    row.Cells["Title"].Value.ToString(),
                    row.Cells["Description"].Value.ToString(),
                    row.Cells["CategoryName"].Value.ToString(),
                    Convert.ToInt32(row.Cells["Quantity"].Value),
                    row.Cells["Joueur"].Value.ToString(),
                    Convert.ToInt32(row.Cells["Age"].Value),
                    Convert.ToInt32(row.Cells["Duree"].Value),
                    Convert.ToInt32(row.Cells["GameID"].Value) // Récupérer l'ID du jeu
                );

                EditGameForm editForm = new EditGameForm(selectedGame, this.dbConnection, this, this.btnEdit);
                editForm.Show();
            }
        }

        private void recherche_TextChanged(object sender, EventArgs e)
        {
            string keyword = recherche.Text;
            List<Game> games = Game.GetGames(this.dbConnection, keyword);

            // Effacer les éléments existants dans le DataGridView
            ListBoxGames.Rows.Clear();

            // Ajouter les résultats au DataGridView
            foreach (Game game in games)
                ListBoxGames.Rows.Add(game.Title, game.Description, game.CategoryName, game.Quantity, game.NbJoueur, game.Age, game.Duree, "✏️", game.GameId);

        }

        private void decon_Click(object sender, EventArgs e)
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

        private void EditUsers_Click(object sender, EventArgs e)
        {
            EditUser useredit = new EditUser();

            useredit.Show();
        }
    }
}
