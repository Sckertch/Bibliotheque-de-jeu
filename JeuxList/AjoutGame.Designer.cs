namespace JeuxList
{
    partial class AjoutGame
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
            ajouter = new Button();
            label1 = new Label();
            annuler = new Button();
            titre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            categorie = new ComboBox();
            label4 = new Label();
            deescription = new TextBox();
            quantite = new NumericUpDown();
            nbj = new TextBox();
            age = new NumericUpDown();
            duree = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)quantite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)age).BeginInit();
            ((System.ComponentModel.ISupportInitialize)duree).BeginInit();
            SuspendLayout();
            // 
            // ajouter
            // 
            ajouter.Location = new Point(94, 409);
            ajouter.Name = "ajouter";
            ajouter.Size = new Size(94, 29);
            ajouter.TabIndex = 0;
            ajouter.Text = "Ajouter";
            ajouter.UseVisualStyleBackColor = true;
            ajouter.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 38);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "Titre";
            // 
            // annuler
            // 
            annuler.Location = new Point(203, 409);
            annuler.Name = "annuler";
            annuler.Size = new Size(94, 29);
            annuler.TabIndex = 2;
            annuler.Text = "Annuler";
            annuler.UseVisualStyleBackColor = true;
            annuler.Click += button2_Click;
            // 
            // titre
            // 
            titre.Location = new Point(35, 61);
            titre.Name = "titre";
            titre.Size = new Size(443, 27);
            titre.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 116);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 6;
            label2.Text = "Catégorie";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(278, 125);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 7;
            label3.Text = "Quantité";
            // 
            // categorie
            // 
            categorie.FormattingEnabled = true;
            categorie.Location = new Point(35, 148);
            categorie.Name = "categorie";
            categorie.Size = new Size(219, 28);
            categorie.TabIndex = 8;
            categorie.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 284);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 10;
            label4.Text = "Description";
            // 
            // deescription
            // 
            deescription.Location = new Point(35, 307);
            deescription.Multiline = true;
            deescription.Name = "deescription";
            deescription.Size = new Size(443, 96);
            deescription.TabIndex = 9;
            // 
            // quantite
            // 
            quantite.Location = new Point(278, 148);
            quantite.Name = "quantite";
            quantite.Size = new Size(193, 27);
            quantite.TabIndex = 11;
            quantite.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // nbj
            // 
            nbj.Location = new Point(37, 231);
            nbj.Name = "nbj";
            nbj.Size = new Size(118, 27);
            nbj.TabIndex = 12;
            // 
            // age
            // 
            age.Location = new Point(200, 232);
            age.Name = "age";
            age.Size = new Size(97, 27);
            age.TabIndex = 13;
            // 
            // duree
            // 
            duree.Location = new Point(355, 231);
            duree.Name = "duree";
            duree.Size = new Size(116, 27);
            duree.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 208);
            label5.Name = "label5";
            label5.Size = new Size(131, 20);
            label5.TabIndex = 15;
            label5.Text = "Nombre de joueur";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(200, 209);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 16;
            label6.Text = "Age";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(355, 209);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 17;
            label7.Text = "Durée";
            // 
            // AjoutGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(duree);
            Controls.Add(age);
            Controls.Add(nbj);
            Controls.Add(quantite);
            Controls.Add(label4);
            Controls.Add(deescription);
            Controls.Add(categorie);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(titre);
            Controls.Add(annuler);
            Controls.Add(label1);
            Controls.Add(ajouter);
            Name = "AjoutGame";
            Text = "Ajout";
            Load += Ajout_Load;
            ((System.ComponentModel.ISupportInitialize)quantite).EndInit();
            ((System.ComponentModel.ISupportInitialize)age).EndInit();
            ((System.ComponentModel.ISupportInitialize)duree).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ajouter;
        private Label label1;
        private Button annuler;
        private TextBox titre;
        private Label label2;
        private Label label3;
        private ComboBox categorie;
        private Label label4;
        private TextBox deescription;
        private NumericUpDown quantite;
        private TextBox nbj;
        private NumericUpDown age;
        private NumericUpDown duree;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}