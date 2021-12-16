using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class admin_area : UserControl
    {
        public admin_area()
        {
            InitializeComponent();
            customdesign();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            showsubmenu(subuser);
        }
        private void customdesign()
        {
            subadmin.Visible = false;
            subuser.Visible = false;
            subdatabase.Visible = false;
            subordorder.Visible = false;
            substat.Visible = false;
        }
        private void hidesubmenu()
        {
            if (subuser.Visible == true)
                subuser.Visible = false;
            if (subadmin.Visible == true)
                subadmin.Visible = false;
            if (subordorder.Visible == true)
                subordorder.Visible = false;
            if (subdatabase.Visible == true)
                subdatabase.Visible = false;
            if (substat.Visible == true)
                substat.Visible = false;
           
        }
        private void showsubmenu(Panel sub)
        {
            hidesubmenu();
            sub.Visible = true;
        }
        private void admin_area_Load(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            first f = new first();
            panel2.Controls.Add(f);
            f.Dock = DockStyle.Fill;
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            showsubmenu(subadmin);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            showsubmenu(subdatabase);
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            showsubmenu(subordorder);
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            showsubmenu(substat);
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void subuser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void subadmin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void subdatabase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void subordorder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void substat_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
