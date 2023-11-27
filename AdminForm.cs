using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackEZ
{
    public partial class AdminForm : Form
    {
        private DB dB;
        private DataTable dataTable;
        private MySqlDataAdapter adapter;
        private BindingSource bindingSource;
        private DataSet dataSet;
        private int selectTable;
        private int rowCount;
        private bool isOvner;

        private Dictionary<DataGridViewCell, object> originalValues = new Dictionary<DataGridViewCell, object>();

        public AdminForm(bool isOvnerP)
        {
            InitializeComponent();
            dB = new DB();
            adapter = new MySqlDataAdapter();
            dataTable = new DataTable();
            bindingSource = new BindingSource();
            dataSet = new DataSet();
            isOvner = isOvnerP;
            if (isOvner)
            {
                menuStrip1.Visible = true;
                selectTable = 1;
            }
            else
            {
                menuStrip1.Visible = false;
                selectTableF();
                selectTable = 3;
            }


        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що хочете вийти?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            selectTableF();
        }

        private void getDbData()
        {
            switch (selectTable)
            {
                case 1:
                    adapter = new MySqlDataAdapter("SELECT * FROM `trackez`.`admin_accounts`", dB.getConnection());
                    if (dataSet != null && dataSet.Tables.Contains("admin_accounts")) {
                        dataSet.Tables["admin_accounts"].Clear();
                    }
                    adapter.Fill(dataSet, "admin_accounts");
                    bindingSource.DataSource = dataSet.Tables["admin_accounts"];
                    dataGridView1.DataSource = bindingSource;
                    break;
                case 2:

                    break;
                case 3:
                    adapter = new MySqlDataAdapter("SELECT `ID`, `parcel_number`, CONCAT(`sender_last_name`, ' ', `sender_first_name`, ' ', `sender_middle_name`) AS `sender_full_name`, `sender_phone_number`, CONCAT(`recipient_last_name`, ' ', `recipient_first_name`, ' ', `recipient_middle_name`) AS `recipient_full_name`, `status`, `payment_status`, `cost` FROM `trackez`.`parcels`", dB.getConnection());
                    if (dataSet != null && dataSet.Tables.Contains("parcels")) {
                        dataSet.Tables["parcels"].Clear();
                    }
                    adapter.Fill(dataSet, "parcels");
                    bindingSource.DataSource = dataSet.Tables["parcels"];
                    dataGridView1.DataSource = bindingSource;
                    break;
                default:
                    break;
            }
        }
        private void selectTableF()
        {
            dataTable.Clear();
            switch (selectTable)
            {
                case 1:
                    getDbData();
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Логін";
                    dataGridView1.Columns[2].HeaderText = "Пароль";
                    dataGridView1.Columns[3].HeaderText = "Ім'я";
                    dataGridView1.Columns[4].HeaderText = "Прізвище";
                    dataGridView1.Columns[5].HeaderText = "Адмін";
                    
                    dataGridView1.Columns[0].Visible = false;
                    rowCount = dataGridView1.RowCount;
                    break;
                case 2:
                    getDbData();

                    break;
                case 3:
                    getDbData();
                    dataGridView1.Columns[1].HeaderText = "ID";
                    dataGridView1.Columns[2].HeaderText = "ПІБ Відправника";
                    dataGridView1.Columns[3].HeaderText = "Номер телефону";
                    dataGridView1.Columns[4].HeaderText = "ПІБ Отримувача";
                    dataGridView1.Columns[5].HeaderText = "Статус";
                    dataGridView1.Columns[6].HeaderText = "Стаус оплати";
                    dataGridView1.Columns[7].HeaderText = "Вартість";

                    dataGridView1.Columns[0].Visible = false;
                    rowCount = dataGridView1.RowCount;
                    break;
                default:
                    break;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (string.IsNullOrEmpty(cell.Value?.ToString())) {
                if (originalValues.ContainsKey(cell)) {
                    cell.Value = originalValues[cell];
                }
            }
            else {
                originalValues[cell] = cell.Value;
            }

            if (selectTable == 3)
            {
                String newLogon;
                String newPassword;
                String newName;
                String newSName;
                bool newIsOvner;
                int id;

                if (e.RowIndex >= 0 && rowCount == dataGridView1.RowCount)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
                        newLogon = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                        newPassword = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
                        newName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
                        newSName = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                        newIsOvner = (bool)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                    else
                        return;

                    updateDataInDatabase(id, newLogon, newPassword, newName, newSName, newIsOvner);
                }
                else if (rowCount < dataGridView1.RowCount)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
                        newLogon = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                        newPassword = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
                        newName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
                        newSName = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    else
                        return;
                    DataGridViewCell cellIsOvn = dataGridView1.Rows[e.RowIndex].Cells["isOwner"];
                    if (cellIsOvn is DataGridViewCheckBoxCell)
                    {
                        if (cellIsOvn.Value != DBNull.Value)
                            newIsOvner = (bool)cellIsOvn.Value;
                        else newIsOvner = false;
                    }
                    else
                        return;
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value) + 1;
                    rowCount = dataGridView1.RowCount;
                    addDataInDatabase(newLogon, newPassword, newName, newSName, newIsOvner);
                }
            }
        }
        private void updateDataInDatabase(int id, String newLogon, String newPassword, String newName, String newSName, bool newIsOvner)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `trackez`.`admin_accounts` SET `admin_accounts`.`login` = @newLogon, `admin_accounts`.`password` = @newPassword, `admin_accounts`.`first_name` = @newName, `admin_accounts`.`last_name` = @newSName, `admin_accounts`.`isOwner` = @isOwner  WHERE `admin_accounts`.`id` = @id", dB.getConnection());
            cmd.Parameters.AddWithValue("@newLogon", newLogon);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@newSName", newSName);
            cmd.Parameters.AddWithValue("@isOwner", newIsOvner);
            cmd.Parameters.AddWithValue("@id", id);
            dB.openConnection();
            try { cmd.ExecuteNonQuery(); } catch (MySqlException ex) { MessageBox.Show("Помилка при оновленні запису: " + ex.Message); }
            cmd = new MySqlCommand("SELECT * FROM `trackez`.`admin_accounts`", dB.getConnection());
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            dB.closeConnection();
        }
        private void addDataInDatabase(String newLogon, String newPassword, String newName, String newSName, bool newIsOvner)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `trackez`.`admin_accounts` (login, password, first_name, last_name, isOwner) VALUES (@newLogon, @newPassword, @newName, @newSName, @isOwner) ", dB.getConnection());
            cmd.Parameters.AddWithValue("@newLogon", newLogon);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@isOwner", newIsOvner);
            cmd.Parameters.AddWithValue("@newSName", newSName);
            dB.openConnection();
            try { cmd.ExecuteNonQuery(); } catch (MySqlException ex) { MessageBox.Show("Помилка при добавленні запису: " + ex.Message); }
            cmd = new MySqlCommand("SELECT * FROM `trackez`.`admin_accounts`", dB.getConnection());
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            dB.closeConnection();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && rowCount == dataGridView1.RowCount)
            {
                DeleteRecordFromDatabase(dataGridView1.CurrentRow);
            }
        }

        private void DeleteRecordFromDatabase(DataGridViewRow selectedRow)
        {
            if (selectedRow != null)
            {
                int recordId = Convert.ToInt32(selectedRow.Cells[0].Value);
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `trackez`.`admin_accounts` WHERE `id` = @recordId", dB.getConnection());
                cmd.Parameters.AddWithValue("@recordId", recordId);
                dB.openConnection();
                try { cmd.ExecuteNonQuery(); } catch (Exception ex) { MessageBox.Show("Помилка при видаленні запису: " + ex.Message); }
                dB.closeConnection();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                rowCount = dataGridView1.RowCount;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (!originalValues.ContainsKey(cell))
            {
                originalValues[cell] = cell.Value;
            }
        }

        private void akkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTable = 1;
            selectTableF();
        }

        private void departToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTable = 2;
            selectTableF();
        }

        private void parselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTable = 3;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;

            selectTableF();
        }

        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
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
