namespace JeuxList
{
    partial class EditGameForm
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
            modifDes = new TextBox();
            modifQuant = new NumericUpDown();
            modifCat = new ComboBox();
            modifNom = new TextBox();
            btnEnreg = new Button();
            retour = new Button();
            nombre = new Label();
            label2 = new Label();
            label3 = new Label();
            duree = new NumericUpDown();
            age = new NumericUpDown();
            nbj = new TextBox();
            ((System.ComponentModel.ISupportInitialize)modifQuant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)duree).BeginInit();
            ((System.ComponentModel.ISupportInitialize)age).BeginInit();
            SuspendLayout();
            // 
            // modifDes
            // 
            modifDes.Location = new Point(12, 70);
            modifDes.Multiline = true;
            modifDes.Name = "modifDes";
            modifDes.Size = new Size(477, 120);
            modifDes.TabIndex = 11;
            // 
            // modifQuant
            // 
            modifQuant.Location = new Point(339, 14);
            modifQuant.Name = "modifQuant";
            modifQuant.Size = new Size(150, 27);
            modifQuant.TabIndex = 10;
            // 
            // modifCat
            // 
            modifCat.FormattingEnabled = true;
            modifCat.Location = new Point(163, 14);
            modifCat.Name = "modifCat";
            modifCat.Size = new Size(151, 28);
            modifCat.TabIndex = 9;
            // 
            // modifNom
            // 
            modifNom.Location = new Point(12, 14);
            modifNom.Name = "modifNom";
            modifNom.Size = new Size(125, 27);
            modifNom.TabIndex = 8;
            // 
            // btnEnreg
            // 
            btnEnreg.Location = new Point(163, 294);
            btnEnreg.Name = "btnEnreg";
            btnEnreg.Size = new Size(324, 29);
            btnEnreg.TabIndex = 12;
            btnEnreg.Text = "Enregistrer";
            btnEnreg.UseVisualStyleBackColor = true;
            btnEnreg.Click += btnEnreg_Click;
            // 
            // retour
            // 
            retour.Location = new Point(12, 294);
            retour.Name = "retour";
            retour.Size = new Size(125, 29);
            retour.TabIndex = 13;
            retour.Text = "Retour";
            retour.UseVisualStyleBackColor = true;
            retour.Click += retour_Click;
            // 
            // nombre
            // 
            nombre.AutoSize = true;
            nombre.Location = new Point(12, 212);
            nombre.Name = "nombre";
            nombre.Size = new Size(82, 20);
            nombre.TabIndex = 14;
            nombre.Text = "Nb joueur :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(277, 212);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 18;
            label2.Text = "Durée (min):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 259);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 19;
            label3.Text = "Age moyen :";
            // 
            // duree
            // 
            duree.Location = new Point(371, 210);
            duree.Name = "duree";
            duree.Size = new Size(73, 27);
            duree.TabIndex = 20;
            // 
            // age
            // 
            age.Location = new Point(110, 257);
            age.Name = "age";
            age.Size = new Size(73, 27);
            age.TabIndex = 21;
            // 
            // nbj
            // 
            nbj.Location = new Point(100, 210);
            nbj.Multiline = true;
            nbj.Name = "nbj";
            nbj.Size = new Size(93, 27);
            nbj.TabIndex = 22;
            // 
            // EditGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 345);
            Controls.Add(nbj);
            Controls.Add(age);
            Controls.Add(duree);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(nombre);
            Controls.Add(retour);
            Controls.Add(btnEnreg);
            Controls.Add(modifDes);
            Controls.Add(modifQuant);
            Controls.Add(modifCat);
            Controls.Add(modifNom);
            Name = "EditGameForm";
            Text = "ch";
            ((System.ComponentModel.ISupportInitialize)modifQuant).EndInit();
            ((System.ComponentModel.ISupportInitialize)duree).EndInit();
            ((System.ComponentModel.ISupportInitialize)age).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox modifDes;
        private NumericUpDown modifQuant;
        private ComboBox modifCat;
        private TextBox modifNom;
        private Button btnEnreg;
        private Button retour;
        private Label nombre;
        private Label label2;
        private Label label3;
        private NumericUpDown duree;
        private NumericUpDown age;
        private TextBox nbj;
    }
}