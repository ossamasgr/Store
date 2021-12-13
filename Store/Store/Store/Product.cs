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
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Add_Product h = new Add_Product();
            panel1.Controls.Add(h);
            h.Dock = DockStyle.Fill;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            edit_product h = new edit_product();
            panel1.Controls.Add(h);
            h.Dock = DockStyle.Fill;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            view_product h = new view_product();
            panel1.Controls.Add(h);
            h.Dock = DockStyle.Fill;

        }
    }
}
