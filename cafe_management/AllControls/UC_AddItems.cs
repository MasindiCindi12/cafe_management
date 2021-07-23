﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe_management.AllControls
{
    public partial class UC_AddItems : UserControl
    {
        Function fn = new Function();
        string query;
        public UC_AddItems()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                query = "insert into items(name,category,price) values('" + txtItemName.Text + "' ,'" + cmbCategory.Text + "'," + txtprice.Text + ")";
                fn.setData(query);
                clearAll();
               // MessageBox.Show("Item Added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            cmbCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtprice.Clear();
        }

        private void UC_AddItems_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
