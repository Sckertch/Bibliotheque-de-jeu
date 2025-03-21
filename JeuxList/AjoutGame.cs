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
    public partial class AjoutGame : Form
    {
        private Form3 form3;
        private DataGridViewButtonColumn btnEdit;
        public AjoutGame(Form3 form3, DataGridViewButtonColumn btnEdit)
        {
            this.form3 = form3;
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            List<string> categories = Game.GetCategories(new DatabaseConnection());
            foreach (string category in categories)
            {
                categorie.Items.Add(category);
            }
            categorie.SelectedIndex = 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = titre.Text;
            string categorie = this.categorie.Text;
            int quantity = (int)quantite.Value;
            string description = deescription.Text;
            string nbJoueur = nbj.Text;
            int age = (int)this.age.Value;
            int duree = (int)this.duree.Value;


            DatabaseConnection conn = new DatabaseConnection();
            Game game = new Game(name, description, categorie, quantity, nbJoueur, age, duree);
            GameCheck check = new GameCheck();

            if (check.CheckGame(game))
            {
                if (GameCheck.AddGame(game, conn))
                {
                    MessageBox.Show("Jeu ajouté avec succès");
                    this.form3.LoadDataGridView(this.btnEdit);
                    //this.form3.Close();
                    //this.form3.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du jeu");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ajout_Load(object sender, EventArgs e)
        {


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Fermer Form3
        }
    }
}
