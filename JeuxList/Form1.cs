using MySql.Data.MySqlClient;

namespace JeuxList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textboxvalue1 = textBox1.Text;
            string textboxvalue2 = User.HashPassword(textBox2.Text);

            DatabaseConnection conn = new DatabaseConnection();
            User user = new User(textboxvalue1);

            UserCheck check = new UserCheck();
            UserCheck result = check.identification(user, conn, textboxvalue2);

            MessageBox.Show(result.name);

            switch (result.status)
            {
                case 0:
                    MessageBox.Show("Utilisateur ou Mot de passe incorrect");
                    break;
                case 1:

                    // Cacher le formulaire Form1 au lieu de le fermer
                    this.Hide();

                    // Instancier le formulaire Form2
                    Form3 form3 = new Form3(this, result.name, conn);

                    // Afficher le formulaire Form2
                    form3.Show();

                    break;
                case 3:
                    //ouvertutre du formulaire de modification de nouveau mot de passe
                    PassChange passChange = new PassChange(conn, result);
                    passChange.Show();
                    break;
                default:
                    // Instancier le formulaire Form2
                    Form2 form2 = new Form2(this, result.name);

                    // Afficher le formulaire Form2
                    form2.Show();

                    // Cacher le formulaire Form1 au lieu de le fermer
                    this.Hide();

                    break;
            }
        }

        public void ResetValues()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
