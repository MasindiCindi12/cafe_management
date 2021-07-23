using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe_management
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
        public dashboard( string User)
        {
            InitializeComponent();

            if (User == "Guest")
            {
                btnAddItem.Hide();
                btnUpdateItem.Hide();
                btnRemove.Hide();
            }
            else  if (User == "Admin")
            {
                btnAddItem.Show();
                btnUpdateItem.Show();
                btnRemove.Show();

            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = false;
            uC_PlaceOrder1.Visible = false;
            uC_UpdateItems1.Visible = false;
            uC_RemoveItems1.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            uC_Welcome1.SendToBack();
            guna2Transition1.ShowSync(uC_AddItems1);
            uC_AddItems1.Visible = true;
            uC_AddItems1.BringToFront();
        }

        private void btnPlaceorder_Click(object sender, EventArgs e)
        {
            uC_Welcome1.SendToBack();
            guna2Transition1.ShowSync(uC_PlaceOrder1);
            uC_PlaceOrder1.Visible = true;
            uC_PlaceOrder1.BringToFront();
        }

        private void uC_PlaceOrder1_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            uC_Welcome1.SendToBack();
            guna2Transition1.ShowSync(uC_UpdateItems1);
            uC_UpdateItems1.Visible = true;
            uC_UpdateItems1.BringToFront();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            uC_Welcome1.SendToBack();
            guna2Transition1.ShowSync(uC_RemoveItems1);
            uC_RemoveItems1.Visible = true;
            uC_RemoveItems1.BringToFront();
        }
    }
}
