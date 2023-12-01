using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TrackEZ
{
    public partial class AdminForm : Form
    {
        private int selectTable;
        private int rowCount;
        private bool isOvner;
        private bool nowSearch;
        private int rowCountSearch;
        private DataTable dataTable;
        private Dictionary<DataGridViewCell, object> originalValues = new Dictionary<DataGridViewCell, object>();

        public AdminForm(bool isOvnerP, int selectTableP)
        {
            InitializeComponent();
            isOvner = isOvnerP;
            dataTable = new DataTable();
            if (isOvner) menuStrip1.Visible = true;
            else menuStrip1.Visible = false;

            selectTable = selectTableP;
            selectTableF();
            tableParsRull();
            setSearch();
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
            selectTableF();
        }

        private void getDbData()
        {
            DB dB = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet dataSet = new DataSet();
            BindingSource bindingSource = new BindingSource();
            switch (selectTable)
            {
                case 1:
                    adapter = new MySqlDataAdapter("SELECT * FROM `trackez`.`admin_accounts`", dB.getConnection());
                    if (dataSet != null && dataSet.Tables.Contains("admin_accounts"))
                    {
                        dataSet.Tables["admin_accounts"].Clear();
                    }
                    adapter.Fill(dataSet, "admin_accounts");
                    bindingSource.DataSource = dataSet.Tables["admin_accounts"];
                    dataGridView1.DataSource = bindingSource;
                    break;
                case 2:
                    adapter = new MySqlDataAdapter("SELECT * FROM `trackez`.`post_offices`", dB.getConnection());
                    if (dataSet != null && dataSet.Tables.Contains("post_offices"))
                    {
                        dataSet.Tables["post_offices"].Clear();
                    }
                    adapter.Fill(dataSet, "post_offices");
                    bindingSource.DataSource = dataSet.Tables["post_offices"];
                    dataGridView1.DataSource = bindingSource;
                    break;
                case 3:
                    adapter = new MySqlDataAdapter("SELECT `ID`, `parcel_number`, CONCAT(`sender_first_name`, ' ', `sender_last_name`, ' ', `sender_middle_name`) AS `sender_full_name`, `sender_phone_number`, CONCAT(`recipient_first_name`, ' ', `recipient_last_name`, ' ', `recipient_middle_name`) AS `recipient_full_name`, `status`, `payment_status`, `cost` FROM `trackez`.`parcels`", dB.getConnection());
                    if (dataSet != null && dataSet.Tables.Contains("parcels"))
                    {
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
                    dataGridView1.Columns[1].HeaderText = "Логін";
                    dataGridView1.Columns[2].HeaderText = "Пароль";
                    dataGridView1.Columns[3].HeaderText = "Ім'я";
                    dataGridView1.Columns[4].HeaderText = "Прізвище";
                    dataGridView1.Columns[5].HeaderText = "Адмін";

                    dataGridView1.Columns[0].Visible = false;
                    //dataGridView1.Columns[2].Visible = false;
                    break;
                case 2:
                    getDbData();
                    dataGridView1.Columns[1].HeaderText = "Обліасть";
                    dataGridView1.Columns[2].HeaderText = "Місто";
                    dataGridView1.Columns[3].HeaderText = "Вулиця";
                    dataGridView1.Columns[4].HeaderText = "Будинок";
                    dataGridView1.Columns[5].HeaderText = "Номер";

                    dataGridView1.Columns[0].Visible = false;
                    break;
                case 3:
                    getDbData();
                    dataGridView1.Columns[1].HeaderText = "Номер";
                    dataGridView1.Columns[2].HeaderText = "ПІБ Відправника";
                    dataGridView1.Columns[3].HeaderText = "Номер телефону";
                    dataGridView1.Columns[4].HeaderText = "ПІБ Отримувача";
                    dataGridView1.Columns[5].HeaderText = "Статус";
                    dataGridView1.Columns[6].HeaderText = "Стаус оплати";
                    dataGridView1.Columns[7].HeaderText = "Вартість";

                    dataGridView1.Columns[0].Visible = false;
                    break;
                default:
                    break;
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            rowCount = dataGridView1.RowCount;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            if (string.IsNullOrEmpty(cell.Value?.ToString()))
            {
                if (originalValues.ContainsKey(cell))
                {
                    cell.Value = originalValues[cell];
                }
            }
            else
            {
                originalValues[cell] = cell.Value;
            }

            if (selectTable == 1)
            {
                String newLogon;
                String newPassword;
                String newName;
                String newSName;
                bool newIsOvner;
                int id;

                if (e.RowIndex >= 0 && (rowCount == dataGridView1.RowCount || nowSearch))
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

                    updateDataInProfDatabase(id, newLogon, newPassword, newName, newSName, newIsOvner);
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
                    addDataInProfDatabase(newLogon, newPassword, newName, newSName, newIsOvner);
                }
            }
            else if (selectTable == 2)
            {
                String newRegion;
                String newCity;
                String newStreet;
                String newBuildingNumber;
                String newOfficeNumber;
                int id;

                if (e.RowIndex >= 0 && (rowCount == dataGridView1.RowCount || nowSearch) )
                {
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
                        newRegion = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                        newCity = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
                        newStreet = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
                        newBuildingNumber = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                        newOfficeNumber = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    else
                        return;

                    updateDataInDepDatabase(id, newRegion, newCity, newStreet, newBuildingNumber, newOfficeNumber);
                }
                else if (rowCount < dataGridView1.RowCount)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() != "")
                        newRegion = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                        newCity = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
                        newStreet = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
                        newBuildingNumber = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    else
                        return;
                    if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                        newOfficeNumber = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    else
                        return;

                    dataGridView1.Rows[e.RowIndex].Cells[0].Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value) + 1;
                    rowCount = dataGridView1.RowCount;
                    addDataInDepDatabase(newRegion, newCity, newStreet, newBuildingNumber, newOfficeNumber);
                }
            }
        }
        private void updateDataInProfDatabase(int id, String newLogon, String newPassword, String newName, String newSName, bool newIsOvner)
        {
            DB dB = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("UPDATE `trackez`.`admin_accounts` SET `admin_accounts`.`login` = @newLogon, `admin_accounts`.`password` = @newPassword, `admin_accounts`.`first_name` = @newName, `admin_accounts`.`last_name` = @newSName, `admin_accounts`.`isOwner` = @isOwner  WHERE `admin_accounts`.`id` = @id", dB.getConnection());
            cmd.Parameters.AddWithValue("@newLogon", newLogon);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@newSName", newSName);
            cmd.Parameters.AddWithValue("@isOwner", newIsOvner);
            cmd.Parameters.AddWithValue("@id", id);
            dB.openConnection();
            cmd.ExecuteNonQuery();
            dB.closeConnection();
            cmd = new MySqlCommand("SELECT * FROM `trackez`.`admin_accounts`", dB.getConnection());
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
        }
        private void addDataInProfDatabase(String newLogon, String newPassword, String newName, String newSName, bool newIsOvner)
        {
            DB dB = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `trackez`.`admin_accounts` (login, password, first_name, last_name, isOwner) VALUES (@newLogon, @newPassword, @newName, @newSName, @isOwner) ", dB.getConnection());
            cmd.Parameters.AddWithValue("@newLogon", newLogon);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@isOwner", newIsOvner);
            cmd.Parameters.AddWithValue("@newSName", newSName);
            dB.openConnection();
            cmd.ExecuteNonQuery(); 
            dB.closeConnection() ;
            cmd = new MySqlCommand("SELECT * FROM `trackez`.`admin_accounts`", dB.getConnection());
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
        }
        private void updateDataInDepDatabase(int id, String newRegion, String newCity, String newStreet, String newBuildingNumber, String newOfficeNumber)
        {
            DB dB = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("UPDATE `trackez`.`post_offices` SET `post_offices`.`region` = @newRegion, `post_offices`.`city` = @newCity, `post_offices`.`street` = @newStreet, `post_offices`.`building_number` = @newBuildingNumber, `post_offices`.`office_number` = @newOfficeNumber  WHERE `post_offices`.`id` = @id", dB.getConnection());
            cmd.Parameters.AddWithValue("@newRegion", newRegion);
            cmd.Parameters.AddWithValue("@newCity", newCity);
            cmd.Parameters.AddWithValue("@newStreet", newStreet);
            cmd.Parameters.AddWithValue("@newBuildingNumber", newBuildingNumber);
            cmd.Parameters.AddWithValue("@newOfficeNumber", newOfficeNumber);
            cmd.Parameters.AddWithValue("@id", id);
            dB.openConnection();
            cmd.ExecuteNonQuery();
            dB.closeConnection() ;
            cmd = new MySqlCommand("SELECT * FROM `trackez`.`post_offices`", dB.getConnection());
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
        }
        private void addDataInDepDatabase(String newRegion, String newCity, String newStreet, String newBuildingNumber, String newOfficeNumber)
        {
            DB dB = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `trackez`.`post_offices` (region, city, street, building_number, office_number) VALUES (@newRegion, @newCity, @newStreet, @newBuildingNumber, @newOfficeNumber) ", dB.getConnection());
            cmd.Parameters.AddWithValue("@newRegion", newRegion);
            cmd.Parameters.AddWithValue("@newCity", newCity);
            cmd.Parameters.AddWithValue("@newStreet", newStreet);
            cmd.Parameters.AddWithValue("@newBuildingNumber", newBuildingNumber);
            cmd.Parameters.AddWithValue("@newOfficeNumber", newOfficeNumber);
            dB.openConnection();
            cmd.ExecuteNonQuery();
            dB.closeConnection() ;
            cmd = new MySqlCommand("SELECT * FROM `trackez`.`post_offices`", dB.getConnection());
            DataTable dataTable = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectTable != 3)
            {
                if (e.KeyCode == Keys.Delete && (rowCount == dataGridView1.RowCount || nowSearch))
                {
                    if (selectTable == 1)
                        DeleteRecordProfFromDatabase(dataGridView1.CurrentRow);
                    else if (selectTable == 2)
                        DeleteRecordDepFromDatabase(dataGridView1.CurrentRow);
                }
            }
        }

        private void DeleteRecordProfFromDatabase(DataGridViewRow selectedRow)
        {
            if (selectedRow != null)
            {
                DB dB = new DB();
                int recordId = Convert.ToInt32(selectedRow.Cells[0].Value);
                MessageBox.Show("r " + recordId);
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `trackez`.`admin_accounts` WHERE `id` = @recordId", dB.getConnection());
                cmd.Parameters.AddWithValue("@recordId", recordId);
                dB.openConnection();
                cmd.ExecuteNonQuery();
                dB.closeConnection();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                selectTableF();
                rowCount = dataGridView1.RowCount;
            }
        }

        private void DeleteRecordDepFromDatabase(DataGridViewRow selectedRow)
        {
            if (selectedRow != null)
            {
                DB dB = new DB();
                int recordId = Convert.ToInt32(selectedRow.Cells[0].Value);
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `trackez`.`post_offices` WHERE `id` = @recordId", dB.getConnection());
                cmd.Parameters.AddWithValue("@recordId", recordId);
                dB.openConnection();
                cmd.ExecuteNonQuery();
                dB.closeConnection();
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                selectTableF();
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
            tableParsRull();
            selectTableF();
            setSearch();
        }

        private void departToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTable = 2;
            tableParsRull();
            selectTableF();
            setSearch();
        }

        private void parselToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTable = 3;
            tableParsRull();
            selectTableF();
            setSearch();
        }

        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (selectTable == 3)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (nowSearch)
                    {
                        selectTableF();
                        nowSearch = false;
                    }
                    else
                    {
                        if (MessageBox.Show("Ви впевнені, що хочете вийти?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Hide();
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                        }
                    }
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    String selectedColumn = comBoxSh.SelectedItem.ToString();
                    String searchText = txtSh.Text;
                    if (!String.IsNullOrEmpty(selectedColumn) && !String.IsNullOrEmpty(searchText))
                    {
                        doSearch();
                    }
                }
                else if (e.KeyCode == Keys.Q)
                {
                    showInf();
                }
                else if (e.KeyCode == Keys.W)
                {
                    this.Hide();
                    int selectID = -1;
                    ParselDetails parselDetails = new ParselDetails(isOvner, selectTable, selectID);
                    parselDetails.Show();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (nowSearch)
                    {
                        selectTableF();
                        dataGridView1.AllowUserToAddRows = true;
                        nowSearch = false;
                    }
                    else if (MessageBox.Show("Ви впевнені, що хочете вийти?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }

                }
                else if (e.KeyCode == Keys.Enter)
                {
                    String selectedColumn = comBoxSh.SelectedItem.ToString();
                    String searchText = txtSh.Text;
                    if (!String.IsNullOrEmpty(selectedColumn) && !String.IsNullOrEmpty(searchText))
                    {
                        doSearch();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            int selectID = -1;
            ParselDetails parselDetails = new ParselDetails(isOvner, selectTable, selectID);
            parselDetails.Show();
        }

        private void btnInf_Click(object sender, EventArgs e)
        {
            showInf();

        }
        private void tableParsRull()
        {
            if (selectTable == 3)
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = true;
                btnAdd.Visible = true;
                btnInf.Visible = true;
            }
            else
            {
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToDeleteRows = false;
                btnAdd.Visible = false;
                btnInf.Visible = false;
            }
        }
        private void setSearch()
        {
            comBoxSh.Items.Clear();
            txtSh.Text = string.Empty;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index == 0)
                    continue;
                if (selectTable == 1 && (column.Index == 2 || column.Index == 5))
                    continue;
                comBoxSh.Items.Add(column.HeaderText);
            }
            comBoxSh.SelectedIndex = 0;
        }

        private void btnSh_Click(object sender, EventArgs e)
        {
            doSearch();
        }

        private void doSearch()
        {
            String selectedColumn = comBoxSh.SelectedItem.ToString();
            String searchText = txtSh.Text;

            if (!String.IsNullOrEmpty(selectedColumn) && !String.IsNullOrEmpty(searchText))
            {
                DataTable dataTable = new DataTable();
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    dataTable.Columns.Add(column.HeaderText);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataRow[i] = row.Cells[i].Value;
                    }
                    dataTable.Rows.Add(dataRow);
                }
                string filterExpression = $"[{selectedColumn}] LIKE '%{searchText}%'";
                dataTable.DefaultView.RowFilter = filterExpression;
                if (dataTable.DefaultView.Count != 0)
                {
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    rowCountSearch = dataGridView1.Rows.Count;
                    if (dataTable.DefaultView.Count != rowCount) {
                        nowSearch = true;
                        dataGridView1.AllowUserToAddRows = false;
                    }                      
                }
                else if (rowCountSearch <= rowCount && nowSearch)
                {
                    nowSearch = false;
                    selectTableF();
                    doSearch();
                }
                else
                {
                    //txtSh.Text = string.Empty;
                    MessageBox.Show("Запису не знайдено", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Впишіть дані для пошуку", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void showInf()
        {
            int selectID = 0;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];
                selectID = Convert.ToInt32(dataGridView1.Rows[selectedCell.RowIndex].Cells[0].Value.ToString());
                if (selectID != 0)
                {
                    this.Hide();
                    ParselDetails parselDetails = new ParselDetails(isOvner, selectTable, selectID);
                    parselDetails.Show();
                }
                else
                    MessageBox.Show("Будь ласка, коректно виберіть посилку", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Будь ласка,виберіть посилку", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
