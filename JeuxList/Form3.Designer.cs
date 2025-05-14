namespace JeuxList
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListBoxGames = new DataGridView();
            Ajouter = new Button();
            decon = new Button();
            label1 = new Label();
            recherche = new TextBox();
            EditUsers = new Button();
            Connect = new Label();
            ((System.ComponentModel.ISupportInitialize)ListBoxGames).BeginInit();
            SuspendLayout();
            // 
            // ListBoxGames
            // 
            ListBoxGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBoxGames.Location = new Point(80, 90);
            ListBoxGames.Name = "ListBoxGames";
            ListBoxGames.RowHeadersWidth = 51;
            ListBoxGames.Size = new Size(1685, 412);
            ListBoxGames.TabIndex = 1;
            ListBoxGames.CellContentClick += ListBoxGames_CellContentClick;
            // 
            // Ajouter
            // 
            Ajouter.Location = new Point(36, 473);
            Ajouter.Name = "Ajouter";
            Ajouter.Size = new Size(38, 29);
            Ajouter.TabIndex = 2;
            Ajouter.Text = "+";
            Ajouter.UseVisualStyleBackColor = true;
            Ajouter.Click += button1_Click;
            // 
            // decon
            // 
            decon.Location = new Point(1646, 44);
            decon.Name = "decon";
            decon.Size = new Size(114, 29);
            decon.TabIndex = 3;
            decon.Text = "Déconnexion";
            decon.UseVisualStyleBackColor = true;
            decon.Click += decon_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(428, 47);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 4;
            label1.Text = "Rechercher :";
            label1.Click += label1_Click;
            // 
            // recherche
            // 
            recherche.Location = new Point(551, 44);
            recherche.Name = "recherche";
            recherche.Size = new Size(853, 27);
            recherche.TabIndex = 5;
            recherche.TextChanged += recherche_TextChanged;
            // 
            // EditUsers
            // 
            EditUsers.Location = new Point(1451, 44);
            EditUsers.Name = "EditUsers";
            EditUsers.Size = new Size(170, 29);
            EditUsers.TabIndex = 6;
            EditUsers.Text = "Gérer les utilisateurs";
            EditUsers.UseVisualStyleBackColor = true;
            EditUsers.Click += EditUsers_Click;
            // 
            // Connect
            // 
            Connect.AutoSize = true;
            Connect.Location = new Point(80, 51);
            Connect.Name = "Connect";
            Connect.Size = new Size(0, 20);
            Connect.TabIndex = 7;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1804, 564);
            Controls.Add(Connect);
            Controls.Add(EditUsers);
            Controls.Add(recherche);
            Controls.Add(label1);
            Controls.Add(decon);
            Controls.Add(Ajouter);
            Controls.Add(ListBoxGames);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)ListBoxGames).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ListBoxGames;
        private Button Ajouter;
        private Button decon;
        private Label label1;
        private TextBox recherche;
        private Button EditUsers;
        private Label Connect;
    }
}