using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe_management
{
    public partial class Form1 : Form
    {
        Function fn = new Function();
        string query;
        public Form1()
        {
            InitializeComponent();
        }

        private void lnkGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dashboard ds = new dashboard("Guest");
            ds.Show();
            this.Hide();

        }


        private const string ConnectionString = @"Data Source=LAPTOP-6V7655K9\SQLEXPRESS;Initial Catalog=cafe;Integrated Security=True";
        SqlConnection con = new SqlConnection(ConnectionString);
        private void btnLogin_Click(object sender, EventArgs e)
        {

            //play around login
            /* if (txtUsername.Text == "Masindi" && txtPassword.Text == "Cindi")
             {
                 dashboard ds = new dashboard("Admin");
                 ds.Show();
                 this.Hide();
             }*/


            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-6V7655K9\\SQLEXPRESS;Initial Catalog=cafe;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users WHERE username='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "'", con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    dashboard dash = new dashboard("Admin");
                    dash.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
