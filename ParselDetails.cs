using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TrackEZ
{
    public partial class ParselDetails : Form
    {
        private bool isOvner;
        private int selectTable;
        private int actions;
        private int selectID;
        private bool canPush;
        private String tempTxtData;
        private int departID;
        private bool[] myArray = new bool[14];
        private bool dataIsSet = false;

        private int eskCount;
        public ParselDetails(bool isOvnerP, int selectTableP, int selectIDP)
        {
            InitializeComponent();
            setRegionColection();
            tempTxtData = string.Empty;
            isOvner = isOvnerP;
            selectTable = selectTableP;
            selectID = selectIDP;
            eskCount = 0;
            departID = 0;
            if (selectID < 0)
                actions = 2;
            else actions = 1;
            if (actions == 2)
            {
                btnAdd.Visible = true;
                btnUpd.Visible = false;
                txtID.Visible = false;
                lbID.Visible = false;
            }
            else
            {
                btnAdd.Visible = false;
                btnUpd.Visible = true;
                if (!setOllDataToTxtBox(selectID))
                    setOllDataToTxtBox(selectID);
            }

            if (isOvner && actions == 1)
                btnDel.Visible = true;
            else btnDel.Visible = false;
            btnUpd.Enabled = false;
            btnAdd.Enabled = false;
            canPush = false;

        }

        private void ParselDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (btnAdd.Enabled || btnUpd.Enabled)
                {
                    if (MessageBox.Show("Ви впевнені, що хочете вийти?", "Підтвердження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Hide();
                        AdminForm adminForm = new AdminForm(isOvner, selectTable);
                        adminForm.Show();
                    }
                    eskCount++;
                }
                else
                {
                    this.Hide();
                    AdminForm adminForm = new AdminForm(isOvner, selectTable);
                    adminForm.Show();
                }

            }

            if (eskCount > 5)
                MessageBox.Show("WTF", "ERR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ParselDetails_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm(isOvner, selectTable);
            adminForm.Show();
        }
        private bool setOllDataToTxtBox(int recIDP)
        {
            if (!dataIsSet)
            {
                string sql = "SELECT parcels.*, post_offices.* FROM parcels JOIN post_offices ON parcels.depart_ID = post_offices.ID WHERE parcels.ID = " + recIDP + "";
                DB dB = null;
                try
                {
                    dB = new DB();
                    using (MySqlCommand command = new MySqlCommand(sql, dB.getConnection()))
                    {
                        //command.Parameters.AddWithValue("@RecID", recIDP);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                DataRow row = dataTable.Rows[0];
                                txtID.Text = row["parcel_number"].ToString();
                                txtFirstNS.Text = row["sender_first_name"].ToString();
                                txtLastNS.Text = row["sender_last_name"].ToString();
                                txtMidlNS.Text = row["sender_middle_name"].ToString();
                                txtNumS.Text = row["sender_phone_number"].ToString();
                                txtFirstNR.Text = row["recipient_first_name"].ToString();
                                txtLastNR.Text = row["recipient_last_name"].ToString();
                                txtMidlNR.Text = row["recipient_middle_name"].ToString();
                                txtNumR.Text = row["recipient_phone_number"].ToString();
                                txtWeight.Text = row["weight"].ToString();
                                comBoxStatus.Text = row["status"].ToString();
                                comBoxParType.Text = row["parcel_type"].ToString();
                                txtCost.Text = row["cost"].ToString();
                                comBoxPStatus.Text = row["payment_status"].ToString();
                                comBoxReg.Text = row["region"].ToString();
                                comBoxCity.Text = row["city"].ToString();
                                comBoxOfNum.Text = row["office_number"].ToString();
                                dataIsSet = true;
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
                dataIsSet = false;
                return false;
            }
            else
            {
                return true;
            }
        }
        private void setRegionColection()
        {
            string sql = "SELECT DISTINCT region FROM post_offices;";
            DB dB = new DB();
            MySqlCommand command = new MySqlCommand(sql, dB.getConnection());
            dB.openConnection();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string region = reader.GetString("region");
                    comBoxReg.Items.Add(region);
                }
                reader.Close();
            }
            dB.closeConnection();
        }

        private void comBoxReg_TextChanged(object sender, EventArgs e)
        {
            DB dB = new DB();
            string selectedRegion = comBoxReg.Text;
            comBoxCity.Items.Clear();
            comBoxOfNum.Items.Clear();
            string sql = "SELECT DISTINCT City FROM post_offices WHERE region = @region;";
            MySqlCommand command = new MySqlCommand(sql, dB.getConnection());
            command.Parameters.AddWithValue("@region", selectedRegion);
            dB.openConnection();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string city = reader.GetString("City");
                    comBoxCity.Items.Add(city);
                }
                reader.Close();
            }
            dB.closeConnection();
            canPush = false;
            checkEnBtn();
        }

        private void comBoxCity_TextChanged(object sender, EventArgs e)
        {
            DB dB = new DB();
            string selectedCity = comBoxCity.Text;
            comBoxOfNum.Items.Clear();
            string sql = "SELECT DISTINCT office_number FROM post_offices WHERE City = @city;";
            MySqlCommand command = new MySqlCommand(sql, dB.getConnection());
            command.Parameters.AddWithValue("@city", selectedCity);
            dB.openConnection();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string officeNumber = reader.GetString("office_number");
                    comBoxOfNum.Items.Add(officeNumber);
                }
                reader.Close();
            }
            dB.closeConnection();
            canPush = false;
            checkEnBtn();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            string insertSql = "INSERT INTO parcels " +
                                "(parcel_number, sender_first_name, sender_last_name, sender_middle_name, sender_phone_number, " +
                                "recipient_first_name, recipient_last_name, recipient_middle_name, recipient_phone_number, " +
                                "send_datetime, estimated_arrival_datetime, weight, status, parcel_type, cost, payment_status, depart_ID) " +
                                "VALUES (@parcelNumber, @senderFirstName, @senderLastName, @senderMiddleName, @senderPhoneNumber, " +
                                "@recipientFirstName, @recipientLastName, @recipientMiddleName, @recipientPhoneNumber, " +
                                "@sendDatetime, @estimatedArrivalDatetime, @weight, @status, @parcelType, @cost, @paymentStatus, @departID)";
            MySqlCommand insertCommand = new MySqlCommand(insertSql, dB.getConnection());
            // Додавання параметрів із текстових полів
            insertCommand.Parameters.AddWithValue("@parcelNumber", getMaxNumPars() + 1);
            insertCommand.Parameters.AddWithValue("@senderFirstName", txtFirstNS.Text.ToString());
            insertCommand.Parameters.AddWithValue("@senderLastName", txtLastNS.Text.ToString());
            insertCommand.Parameters.AddWithValue("@senderMiddleName", txtMidlNS.Text.ToString());
            insertCommand.Parameters.AddWithValue("@senderPhoneNumber", txtNumS.Text.ToString());
            insertCommand.Parameters.AddWithValue("@recipientFirstName", txtFirstNR.Text.ToString());
            insertCommand.Parameters.AddWithValue("@recipientLastName", txtLastNR.Text.ToString());
            insertCommand.Parameters.AddWithValue("@recipientMiddleName", txtMidlNR.Text.ToString());
            insertCommand.Parameters.AddWithValue("@recipientPhoneNumber", txtNumR.Text.ToString());
            insertCommand.Parameters.AddWithValue("@sendDatetime", null); // !!!!
            insertCommand.Parameters.AddWithValue("@estimatedArrivalDatetime", null); // !!!!
            insertCommand.Parameters.AddWithValue("@weight", double.Parse(txtWeight.Text));
            insertCommand.Parameters.AddWithValue("@status", comBoxStatus.Text.ToString());
            insertCommand.Parameters.AddWithValue("@parcelType", comBoxParType.Text.ToString());
            insertCommand.Parameters.AddWithValue("@cost", double.Parse(txtCost.Text));
            insertCommand.Parameters.AddWithValue("@paymentStatus", comBoxPStatus.Text.ToString());
            insertCommand.Parameters.AddWithValue("@departID", departID);
            dB.openConnection();
            insertCommand.ExecuteNonQuery();
            dB.closeConnection();
            MessageBox.Show("Запис додано");
            this.Hide();
            AdminForm adminForm = new AdminForm(isOvner, selectTable);
            adminForm.Show();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            string updateSql = "UPDATE parcels SET " +
                                "sender_first_name = @senderFirstName, " +
                                "sender_last_name = @senderLastName, " +
                                "sender_middle_name = @senderMiddleName, " +
                                "sender_phone_number = @senderPhoneNumber, " +
                                "recipient_first_name = @recipientFirstName, " +
                                "recipient_last_name = @recipientLastName, " +
                                "recipient_middle_name = @recipientMiddleName, " +
                                "recipient_phone_number = @recipientPhoneNumber, " +
                                "weight = @weight, " +
                                "status = @status, " +
                                "parcel_type = @parcelType, " +
                                "cost = @cost, " +
                                "payment_status = @paymentStatus, " +
                                "depart_ID = @departID " +
                                "WHERE ID = @ID";
            MySqlCommand updateCommand = new MySqlCommand(updateSql, dB.getConnection());
            updateCommand.Parameters.AddWithValue("@senderFirstName", txtFirstNS.Text.ToString());
            updateCommand.Parameters.AddWithValue("@senderLastName", txtLastNS.Text.ToString());
            updateCommand.Parameters.AddWithValue("@senderMiddleName", txtMidlNS.Text.ToString());
            updateCommand.Parameters.AddWithValue("@senderPhoneNumber", txtNumS.Text.ToString());
            updateCommand.Parameters.AddWithValue("@recipientFirstName", txtFirstNR.Text.ToString());
            updateCommand.Parameters.AddWithValue("@recipientLastName", txtLastNR.Text.ToString());
            updateCommand.Parameters.AddWithValue("@recipientMiddleName", txtMidlNR.Text.ToString());
            updateCommand.Parameters.AddWithValue("@recipientPhoneNumber", txtNumR.Text.ToString());
            updateCommand.Parameters.AddWithValue("@weight", double.Parse(txtWeight.Text));
            updateCommand.Parameters.AddWithValue("@status", comBoxStatus.Text.ToString());
            updateCommand.Parameters.AddWithValue("@parcelType", comBoxParType.Text.ToString());
            updateCommand.Parameters.AddWithValue("@cost", double.Parse(txtCost.Text));
            updateCommand.Parameters.AddWithValue("@paymentStatus", comBoxPStatus.Text.ToString());
            updateCommand.Parameters.AddWithValue("@departID", departID);
            updateCommand.Parameters.AddWithValue("@ID", selectID);
            dB.openConnection();
            updateCommand.ExecuteNonQuery();
            dB.closeConnection();
            MessageBox.Show("Дані оновлено");
        }
        private void checkEnBtn()
        {
            if (actions == 2)
            {
                bool allTrue = true;
                foreach (bool value in myArray)
                {
                    if (!value)
                    {
                        allTrue = false;
                        break;
                    }
                }

                if (allTrue && txtFirstNR.Text != tempTxtData)
                {
                    btnAdd.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                }
            }
            else if (actions == 1)
            {
                if (canPush == true) btnUpd.Enabled = true;
                else btnUpd.Enabled = false;
            }
        }

        private void txtFirstNS_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtFirstNS_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 1))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[1] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtLastNS_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtLastNS_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 1))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[2] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtMidlNS_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtMidlNS_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 1))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[3] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtFirstNR_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtFirstNR_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 1))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[4] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtLastNR_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtLastNR_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 1))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[5] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtMidlNR_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtMidlNR_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 1))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[6] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtNumR_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtNumR_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 2))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[7] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtNumS_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtNumS_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 2))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[8] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtWeight_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 2))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[9] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void txtCost_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                tempTxtData = textBox.Text;
            }
        }

        private void txtCost_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (Validator.ValidateTextBox(textBox, 2))
                {
                    if (textBox.Text != tempTxtData)
                    {
                        canPush = true;
                        myArray[10] = true;
                    }
                }
                else
                    textBox.Text = tempTxtData;
            }
            checkEnBtn();
        }

        private void comBoxPStatus_TextChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedIndex != -1)
                {
                    myArray[12] = true;
                    canPush = true;
                }
                else
                {
                    myArray[12] = false;
                    canPush = false;
                }
            }
            checkEnBtn();
        }

        private void comBoxStatus_TextChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedIndex != -1)
                {
                    myArray[13] = true;
                    canPush = true;
                }
                else
                {
                    myArray[13] = false;
                    canPush = false;
                }
            }
            checkEnBtn();
        }

        private void comBoxParType_TextChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedIndex != -1)
                {
                    myArray[0] = true;
                    canPush = true;
                }
                else
                {
                    myArray[0] = false;
                    canPush = false;
                }
            }
            checkEnBtn();
        }

        private void comBoxOfNum_TextChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedIndex != -1)
                {
                    myArray[11] = true;
                    canPush = true;
                }
                else
                {
                    myArray[11] = false;
                    canPush = false;
                }
            }
            checkEnBtn();

            DB dB = new DB();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `post_offices` WHERE `region`='" + comBoxReg.Text.ToString() + "' AND `city` = '" + comBoxCity.Text.ToString() + "' AND `office_number`='" + comBoxOfNum.Text.ToString() + "';", dB.getConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            String idOff;
            if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("ID"))
            {
                idOff = dataTable.Rows[0]["ID"].ToString();
                departID = Convert.ToInt32(idOff);
            }
        }
        private int getMaxNumPars()
        {
            DB dB = new DB();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT MAX(parcel_number) AS max_parcel_number FROM parcels;", dB.getConnection());
            adapter.SelectCommand = cmd;
            adapter.Fill(dataTable);
            String maxId;
            if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("max_parcel_number"))
            {
                maxId = dataTable.Rows[0]["max_parcel_number"].ToString();
                int maxID = Convert.ToInt32(maxId);
                return maxID;
            }
            return 0;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty)
            {
                DB dB = new DB();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM parcels WHERE ID = @recordId", dB.getConnection());
                cmd.Parameters.AddWithValue("@recordId", selectID);
                dB.openConnection();
                cmd.ExecuteNonQuery();
                dB.closeConnection();
                this.Hide();
                AdminForm adminForm = new AdminForm(isOvner, selectTable);
                adminForm.Show();
            }
        }
    }
}
