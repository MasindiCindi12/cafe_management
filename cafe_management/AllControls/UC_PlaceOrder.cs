using DGVPrinterHelper;
using System;
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
    public partial class UC_PlaceOrder : UserControl
    {

        Function fn = new Function();
        string query;
        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Amount : R " + lblTotal.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);
            total = 0;
            guna2DataGridView1.Rows.Clear();
            lblTotal.Text = "R " + total;

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lstResult.Items.Clear();
                string category = cmbCategory.Text;
                query = "select name from items where category='" + cmbCategory.Text + "'";
                DataSet ds = fn.getData(query);

                int i;
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lstResult.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                }
            
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString(),"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lstResult.Items.Clear();
                string category = cmbCategory.Text;
                query = "select name from items where category='" + cmbCategory.Text + "' and name like'"+txtSearch.Text+"%'";
                DataSet ds = fn.getData(query);

                int i;
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lstResult.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showItemList(string query)
        {
            lstResult.Items.Clear();
            DataSet da = fn.getData(query);


        }

        private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();
            string text = lstResult.GetItemText(lstResult.SelectedItem);
            txtItemName.Text = text;
            try
            {
                query = "select price from items where name='" + txtItemName.Text + "'";
                DataSet ds = fn.getData(query);
                txtRand.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected int n, total = 0;

        private void btn_AddCart_Click(object sender, EventArgs e)
        {

            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {


                n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = txtItemName.Text;
                guna2DataGridView1.Rows[n].Cells[1].Value = txtRand.Text;
                guna2DataGridView1.Rows[n].Cells[2].Value = txtQuantityUpDown.Value;
                guna2DataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;

                total = total + int.Parse(txtTotal.Text);
                lblTotal.Text = "R " + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity needs to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        int amount;

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            }
            catch(Exception ex)
            {
                ex.ToString();
            }
           
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            total = total - amount;
            lblTotal.Text = "R " + total;
        }

        private void UC_PlaceOrder_Load(object sender, EventArgs e)
        {

        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtQuantityUpDown.Value.ToString());

            Int64 price = Int64.Parse(txtRand.Text);
            txtTotal.Text = (quan * price).ToString();
        }
    }
}
