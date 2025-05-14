namespace JeuxList
{
    partial class Form2
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
            recherche = new TextBox();
            label1 = new Label();
            decon = new Button();
            Connect = new Label();
            ((System.ComponentModel.ISupportInitialize)ListBoxGames).BeginInit();
            SuspendLayout();
            // 
            // ListBoxGames
            // 
            ListBoxGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListBoxGames.Location = new Point(84, 116);
            ListBoxGames.Name = "ListBoxGames";
            ListBoxGames.RowHeadersWidth = 51;
            ListBoxGames.Size = new Size(1666, 414);
            ListBoxGames.TabIndex = 0;
            // 
            // recherche
            // 
            recherche.Location = new Point(756, 66);
            recherche.Name = "recherche";
            recherche.Size = new Size(853, 27);
            recherche.TabIndex = 9;
            recherche.TextChanged += recherche_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(648, 70);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 8;
            label1.Text = "Rechercher :";
            // 
            // decon
            // 
            decon.Location = new Point(1633, 66);
            decon.Name = "decon";
            decon.Size = new Size(114, 29);
            decon.TabIndex = 7;
            decon.Text = "Déconnexion";
            decon.UseVisualStyleBackColor = true;
            decon.Click += decon_Click_1;
            // 
            // Connect
            // 
            Connect.AutoSize = true;
            Connect.Location = new Point(84, 73);
            Connect.Name = "Connect";
            Connect.Size = new Size(0, 20);
            Connect.TabIndex = 10;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1801, 608);
            Controls.Add(Connect);
            Controls.Add(recherche);
            Controls.Add(label1);
            Controls.Add(decon);
            Controls.Add(ListBoxGames);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)ListBoxGames).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ListBoxGames;
        private TextBox recherche;
        private Label label1;
        private Button decon;
        private Label Connect;
    }
}