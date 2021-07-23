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
    public partial class UC_Welcome : UserControl
    {
        public UC_Welcome()
        {
            InitializeComponent();
        }

        int num = 0;

        private void UC_Welcome_Load(object sender, EventArgs e)
        {

            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
                if (num == 0)
                {
                    labelbanner.Location = new Point(94, 367);
                    labelbanner.ForeColor = Color.Orange;
                    num++;
                }
                else if (num == 1)
                {
                    labelbanner.Location = new Point(166, 367);
                    labelbanner.ForeColor = Color.Purple;
                    num++;

                }
                else if (num == 2)
                {
                    labelbanner.Location = new Point(268, 367);
                    labelbanner.ForeColor = Color.RoyalBlue;
                    num = 0;

                }
            }
        
    }
}
