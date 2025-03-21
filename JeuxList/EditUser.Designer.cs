namespace JeuxList
{
    partial class EditUser
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
            userGrid = new DataGridView();
            ajoutU = new Button();
            Retour = new Button();
            ((System.ComponentModel.ISupportInitialize)userGrid).BeginInit();
            SuspendLayout();
            // 
            // userGrid
            // 
            userGrid.AllowUserToAddRows = false;
            userGrid.AllowUserToDeleteRows = false;
            userGrid.AllowUserToOrderColumns = true;
            userGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userGrid.Location = new Point(111, 71);
            userGrid.Name = "userGrid";
            userGrid.ReadOnly = true;
            userGrid.RowHeadersWidth = 51;
            userGrid.Size = new Size(550, 352);
            userGrid.TabIndex = 0;
            userGrid.CellContentClick += userGrid_CellContentClick;
            // 
            // ajoutU
            // 
            ajoutU.Font = new Font("Segoe UI", 12F);
            ajoutU.Location = new Point(667, 386);
            ajoutU.Margin = new Padding(1);
            ajoutU.Name = "ajoutU";
            ajoutU.Size = new Size(42, 37);
            ajoutU.TabIndex = 1;
            ajoutU.Text = "+";
            ajoutU.UseVisualStyleBackColor = true;
            ajoutU.Click += ajoutU_Click;
            // 
            // Retour
            // 
            Retour.Location = new Point(567, 429);
            Retour.Name = "Retour";
            Retour.Size = new Size(94, 29);
            Retour.TabIndex = 2;
            Retour.Text = "Retour";
            Retour.UseVisualStyleBackColor = true;
            Retour.Click += Retour_Click;
            // 
            // EditUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(Retour);
            Controls.Add(ajoutU);
            Controls.Add(userGrid);
            Name = "EditUser";
            Text = "EditUser";
            Load += EditUser_Load;
            ((System.ComponentModel.ISupportInitialize)userGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView userGrid;
        private Button ajoutU;
        private Button Retour;
    }
}