using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace DatabaseInterface
{
    internal class DBInterface
    {
        private string conString = "";
        private SqlConnection Conn;
        bool conStrSet = false;
        bool connected = false;
        public DBInterface()
        {

        }

        public DBInterface(string name, string pwd)
        {
            conStrSet = SetConnstring(name, pwd);
        }

        bool SetConnstring(string name, string pwd)
        {
            conString = $"server=localhost;user={name};password={pwd};database=demodb";
            return true;
        }

        public void TestConnection()
        {
            if (conStrSet)
            {
                bool ex = false;
                MySqlConnection mCon;
                mCon = new MySqlConnection(conString);

                try
                {
                    mCon.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    MessageBox.Show("An error has occurred!");
                    ex = true;
                }

                if (!ex)
                {
                    MessageBox.Show("Connected!");
                    mCon.Close();
                    connected = true;
                }
                else
                {
                    DeleteConnection();
                    MessageBox.Show("Please try again!", "Invalid Credentials", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error,);
                }
            }
        }

        public void DeleteConnection()
        {
            if(Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
                conString = "";
                connected = false;
                conStrSet = false;
            }
        }
    }
}
