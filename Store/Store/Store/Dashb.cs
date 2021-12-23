using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class Dashb : Form
    {
        int is_clicked = 2;
        public Dashb()
        {
            InitializeComponent();
            customdesign();
        }

        private void Dashb_Load(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Dashboard d = new Dashboard();
            panel2.Controls.Add(d);
            d.Dock = DockStyle.Fill;
            bunifuFlatButton2.selected = true;
        }
        private void customdesign()
        {
            subuser.Visible = false;
            subadmin.Visible = false;
        }
        private void hidesubmenu()
        {
            if (subuser.Visible == true)
                subuser.Visible = false;
            if (subadmin.Visible == true)
                subadmin.Visible = false;
        }
        private void showsubmenu(Panel sub)
        {
            bunifuFlatButton2.selected = false;
            hidesubmenu();
            sub.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
            is_clicked = is_clicked + 1;
            if (is_clicked %2 == 0)
            {
                hidesubmenu();
            }
            else
            {
                showsubmenu(subuser);
            }
            
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            is_clicked = is_clicked + 1;
            if (is_clicked % 2 == 0)
            {
                hidesubmenu();
            }
            else
            {
                showsubmenu(subadmin);
            }
            
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            hidesubmenu();
        }

    }
}
