using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
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

        private int eskCount;
        public ParselDetails(bool isOvnerP, int selectTableP, int selectIDP)
        {
            InitializeComponent();
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
                setRegionColection();
            }
            else
            {
                btnAdd.Visible = false;
                btnUpd.Visible = true;
                setRegionColection();
                setOllDataToTxtBox(selectID);
            }
            btnUpd.Enabled = false;
            btnAdd.Enabled = false;
            canPush = false;
            //MessageBox.Show("Значення у форматі int: " + selectID.ToString());

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
                }
                else
                {
                    this.Hide();
                    AdminForm adminForm = new AdminForm(isOvner, selectTable);
                    adminForm.Show();
                }
                eskCount++;
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
        private void setOllDataToTxtBox(int recIDP)
        {

            string sql = "SELECT " +
                "p.ID AS ParcelID, " +
                "p.parcel_number AS ParcelNumber, " +
                "p.sender_first_name AS SenderFirstName, " +
                "p.sender_last_name AS SenderLastName, " +
                "p.sender_middle_name AS SenderMiddleName, " +
                "p.sender_phone_number AS SenderPhoneNumber, " +
                "p.recipient_first_name AS RecipientFirstName, " +
                "p.recipient_last_name AS RecipientLastName, " +
                "p.recipient_middle_name AS RecipientMiddleName, " +
                "p.recipient_phone_number AS RecipientPhoneNumber, " +
                "p.send_datetime AS SendDatetime, " +
                "p.estimated_arrival_datetime AS EstimatedArrivalDatetime, " +
                "p.weight AS Weight, " +
                "p.status AS Status, " +
                "p.parcel_type AS ParcelType, " +
                "p.cost AS Cost, " +
                "p.payment_status AS PaymentStatus, " +
                "p.depart_ID AS DepartID, " +
                "po.ID AS PostOfficeID, " +
                "po.region AS Region, " +
                "po.city AS City, " +
                "po.street AS Street, " +
                "po.building_number AS BuildingNumber, " +
                "po.office_number AS OfficeNumber " +
                "FROM parcels p " +
                "INNER JOIN post_offices po ON p.depart_ID = po.ID WHERE p.ID = " + recIDP + "";
            DB dB = new DB();
            MySqlCommand command = new MySqlCommand(sql, dB.getConnection());
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            dB.openConnection();
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int parcelID = reader.GetInt32("ParcelID");
                    String parcelNumber = reader.GetString("ParcelNumber");
                    txtID.Text = parcelNumber;
                    String senderFirstName = reader.GetString("SenderFirstName");
                    txtFirstNS.Text = senderFirstName;
                    String senderLastName = reader.GetString("SenderLastName");
                    txtLastNS.Text = senderLastName;
                    String senderMiddleName = reader.GetString("SenderMiddleName");
                    txtMidlNS.Text = senderMiddleName;
                    String senderPhoneNumber = reader.GetString("SenderPhoneNumber");
                    txtNumS.Text = senderPhoneNumber;
                    String recipientFirstName = reader.GetString("RecipientFirstName");
                    txtFirstNR.Text = recipientFirstName;
                    String recipientLastName = reader.GetString("RecipientLastName");
                    txtLastNR.Text = recipientLastName;
                    String recipientMiddleName = reader.GetString("RecipientMiddleName");
                    txtMidlNR.Text = recipientMiddleName;
                    String recipientPhoneNumber = reader.GetString("RecipientPhoneNumber");
                    txtNumR.Text = recipientPhoneNumber;
                    // DateTime sendDatetime = reader.GetDateTime("SendDatetime");
                    // DateTime estimatedArrivalDatetime = reader.GetDateTime("EstimatedArrivalDatetime");
                    double weight = reader.GetDouble("Weight");
                    txtWeight.Text = weight.ToString();
                    String status = reader.GetString("Status");
                    comBoxStatus.Text = status;
                    String parcelType = reader.GetString("ParcelType");
                    comBoxParType.Text = parcelType;
                    double cost = reader.GetDouble("Cost");
                    txtCost.Text = cost.ToString();
                    String paymentStatus = reader.GetString("PaymentStatus");
                    comBoxPStatus.Text = paymentStatus;
                    //int departID = reader.GetInt32("DepartID");
                    //int postOfficeID = reader.GetInt32("PostOfficeID");
                    String region = reader.GetString("Region");
                    comBoxReg.Text = region;
                    String city = reader.GetString("City");
                    comBoxCity.Text = city;
                    //String street = reader.GetString("Street");
                    //String buildingNumber = reader.GetString("BuildingNumber");
                    String officeNumber = reader.GetString("OfficeNumber");
                    comBoxOfNum.Text = officeNumber;
                }
                reader.Close();
            }
            dB.closeConnection();
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
            insertCommand.Parameters.AddWithValue("@parcelNumber", 1234345);
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

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `post_offices` WHERE `region`='"+comBoxReg.Text.ToString()+"' AND `city` = '"+comBoxCity.Text.ToString()+"' AND `office_number`='"+comBoxOfNum.Text.ToString()+"';", dB.getConnection());
            try
            {
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
                String idOff;
                if (dataTable.Rows.Count > 0 && dataTable.Columns.Contains("ID"))
                {
                    idOff = dataTable.Rows[0]["ID"].ToString();
                    departID = Convert.ToInt32(idOff);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
            dB.closeConnection();
        }
    }
}
