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
{//un admin peut demander la génération d'un nouveau mot de passe pour un utilisateur
 // ce dernier devra se connecter avec le mot de passe donné par l'admin et le changer
    public partial class EditUser : Form
    {
        private DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        private DatabaseConnection dbConnection = new DatabaseConnection();
        public EditUser()
        {
            InitializeComponent();
            InitializeUserGrid();
        }
        private void InitializeUserGrid()
        {
            userGrid.Columns.Add("UserID", "Id utilisateur");
            userGrid.Columns.Add("Username", "Nom d'utilisateur");
            this.btnEdit.Name = "Edit";
            this.btnEdit.HeaderText = "Modifier";
            this.btnEdit.Text = "✏️";
            this.btnEdit.UseColumnTextForButtonValue = true;
            this.userGrid.Columns.Add("Edit", "Demander un changement de mot de passe");

            LoadDataGridView(btnEdit);
        }

        public void LoadDataGridView(DataGridViewButtonColumn btnEdit)
        {
            List<User> users = User.GetUsers(this.dbConnection);
            userGrid.Rows.Clear();
            foreach (User user in users)
                userGrid.Rows.Add(user.UserId, user.Nom, "✏️");
        }
        private void userGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string modif = "1";

            if (e.ColumnIndex == userGrid.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = userGrid.Rows[e.RowIndex];
                User userSelected = new User(
                    row.Cells["Username"].Value.ToString(),
                    Convert.ToInt32(row.Cells["UserID"].Value)
                );

                string newPassword = User.GeneratePassword();
                Clipboard.SetText(newPassword);
                MessageBox.Show("Le nouveau mot de passe est: " + newPassword + "\nLe mot de passe a été copié dans le presse-papiers.");
                User.UpdatePassword(userSelected.UserId.Value, newPassword, modif, this.dbConnection);
            }
        }
        private void ajoutU_Click(object sender, EventArgs e)
        {
            AjoutUser ajoutUser = new AjoutUser(this, this.dbConnection, this.btnEdit);
            ajoutUser.Show();
        }

        private void Retour_Click(object sender, EventArgs e)
        {
            this.Close(); // Fermer 
        }
    }
}
