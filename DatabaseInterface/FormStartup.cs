using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DatabaseInterface
{
    public partial class FormStartup : Form
    {
        public FormStartup()
        {
            InitializeComponent();
            //pictureBox1.Image = Image.FromFile("resources\\images\\FT_New.png");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DBInterface db = new DBInterface(txtUsername.Text, txtPassword.Text);
            db.TestConnection();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
