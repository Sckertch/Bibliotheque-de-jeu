﻿namespace JeuxList
{
    partial class PassChange
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(15, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(15, 160);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 28);
            label1.Name = "label1";
            label1.Size = new Size(161, 20);
            label1.TabIndex = 2;
            label1.Text = "Nouveau mot de passe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 123);
            label2.Name = "label2";
            label2.Size = new Size(244, 20);
            label2.TabIndex = 3;
            label2.Text = "Confirmer le nouveau mot de passe";
            // 
            // button1
            // 
            button1.Location = new Point(144, 217);
            button1.Name = "button1";
            button1.Size = new Size(212, 29);
            button1.TabIndex = 4;
            button1.Text = "Changer le mot de passe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PassChange
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 258);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "PassChange";
            Text = "PassChange";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}