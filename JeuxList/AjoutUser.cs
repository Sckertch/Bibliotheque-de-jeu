using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JeuxList
{
    public partial class AjoutUser : Form
    {
        private EditUser editUser;
        private DatabaseConnection conn;
        private DataGridViewButtonColumn btnEdit;
        public AjoutUser(EditUser editUser, DatabaseConnection conn, DataGridViewButtonColumn btnEdit)
        {
            this.editUser = editUser;
            this.conn = conn;
            this.btnEdit = btnEdit;
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Utilisateur");
            comboBox1.SelectedIndex = 0;
        }

        private void AjoutUser_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string role = comboBox1.Text;

            User user = new User(name);
            UserCheck check = new UserCheck();

            if (User.CheckUser(user, conn))
            {
                MessageBox.Show("L'utilisateur existe déjà");
            }
            else
            {
                if (User.AddUser(user, role, this.conn))
                {
                    MessageBox.Show("Utilisateur ajouté avec succès");
                    this.editUser.LoadDataGridView(this.btnEdit);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout de l'utilisateur");
                }
            }
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
