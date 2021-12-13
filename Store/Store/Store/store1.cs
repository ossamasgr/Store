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
    public partial class store1 : UserControl
    {
        public store1()
        {
            InitializeComponent();
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            add_to_store h = new add_to_store();
            panel1.Controls.Add(h);
            h.Dock = DockStyle.Fill;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            edit_store h = new edit_store();
            panel1.Controls.Add(h);
            h.Dock = DockStyle.Fill;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            view_store h = new view_store();
            panel1.Controls.Add(h);
            h.Dock = DockStyle.Fill;
        }
    }
}
