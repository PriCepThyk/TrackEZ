using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackEZ
{
    internal class DB
    {
        String connectStr = "server=localhost;port=3306;username=root;password=usbw;database=trackez;Charset=utf8;";

        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=usbw;database=trackez;Charset=utf8;");

        public void openConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB error " + ex.Message);
            }
        }

        public void closeConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB error: " + ex.Message);
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }

        public String getConnStr()
        {
            return connectStr;
        }
    }
}
