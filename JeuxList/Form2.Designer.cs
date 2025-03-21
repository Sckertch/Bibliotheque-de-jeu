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
            addCart = new Button();
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
            ListBoxGames.CellContentClick += ListBoxGames_CellContentClick;
            // 
            // addCart
            // 
            addCart.Location = new Point(1712, 69);
            addCart.Name = "addCart";
            addCart.Size = new Size(38, 29);
            addCart.TabIndex = 1;
            addCart.Text = "+";
            addCart.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1801, 608);
            Controls.Add(addCart);
            Controls.Add(ListBoxGames);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)ListBoxGames).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ListBoxGames;
        private Button addCart;
    }
}