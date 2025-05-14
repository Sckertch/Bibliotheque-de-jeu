using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuxList
{
    public partial class PassChange : Form
    {
        private DatabaseConnection conn;
        private UserCheck usercheck;
        public PassChange(DatabaseConnection conn, UserCheck usercheck)
        {
            this.conn = conn;
            this.usercheck = usercheck;
            InitializeComponent();
        }

        private bool checkSamePassWord(string a, string b)
        {
            if (a == b)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            string modif = "0";
            if (checkSamePassWord(textBox1.Text, textBox2.Text))
            {
                try
                {
                    if (User.UpdatePassword(this.usercheck.id.Value, password, modif, this.conn))
                    {
                        MessageBox.Show("Mot de passe changé avec succès");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors du changement de mot de passe");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Les mots de passe ne correspondent pas");
            }
        }
    }
}
