using MySql.Data.MySqlClient;
using System.Data;

namespace DatabaseInterface
{
    internal class DBInterface
    {
        private string conString = "";
        private MySqlConnection Conn;
        bool conStrSet = false;
        bool connected = false;
        DataTable dt;
        public DataTable DTable { get { return dt; } }

        public DBInterface(string name, string pwd)
        {
            conStrSet = SetConnstring(name, pwd);
            if(conStrSet)
            {
                connected = true;
            }
            else
            {
                Conn = new MySqlConnection(conString);
            }
        }

        bool SetConnstring(string name, string pwd)
        {
            conString = $"server=localhost;user={name};password={pwd};database=demodb";
            if (TestConnection())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TestConnection()
        {
            bool ex = false;

            if (conStrSet)
            {
                Conn = new MySqlConnection(conString);

                try
                {
                    Conn.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("An error has occurred!");
                    ex = true;
                }

                if (!ex)
                {
                    MessageBox.Show("Connected!");
                    Conn.Close();
                    connected = true;
                }
                else
                {
                    DeleteConnection();
                    MessageBox.Show("Please try again!", "Invalid Credentials", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                }
            }

            return !ex;
        }

        public void DeleteConnection()
        {
            if (Conn != null && connected)
            {
                Conn.Close();
                Conn.Dispose();
                conString = "";
                connected = false;
                conStrSet = false;
            }
        }

        public void RetrieveAllDataFrom(string table)
        {
            string query = $"SELECT * FROM {table}";

            MySqlCommand cmd = new MySqlCommand(query);

            cmd.ExecuteReader();
        }
    }
}
