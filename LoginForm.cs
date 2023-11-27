using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace TrackEZ
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що хочете вийти?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;

            }
            else { Application.ExitThread(); }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            String adminLogin = txtLogin.Text;
            String adminPassword = txtLogin.Text;

            if (adminLogin == "" || adminPassword == "")
                MessageBox.Show("Введіть дані", "Помилка", MessageBoxButtons.OK);
            else
            {
                DB dB = new DB();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `trackez`.`admin_accounts` WHERE `admin_accounts`.`login` = @adminLogin AND `admin_accounts`.`password` = @adminPassword", dB.getConnection());
                cmd.Parameters.AddWithValue("@adminLogin", adminLogin);
                cmd.Parameters.AddWithValue("@adminPassword", adminPassword);
                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                    bool isOwner = false;
                    if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("isOwner"))
                    {
                        isOwner = Convert.ToBoolean(dataTable.Rows[0]["isOwner"]);
                    }
                    if (dataTable.Rows.Count > 0)
                    {
                        AdminForm adminF = new AdminForm(isOwner);
                        this.Hide();
                        adminF.Show();
                    }
                    else
                        MessageBox.Show("Помилка входу", "Помилка", MessageBoxButtons.OK);

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Помилка входу: " + ex.Message);
                }
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Ви впевнені, що хочете вийти?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
        }
    }
}