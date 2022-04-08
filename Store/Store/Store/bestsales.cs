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
    public partial class bestsales : UserControl
    {
        public bestsales()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bestsales_Load(object sender, EventArgs e)
        {
            panel6.Controls.Clear();
            Dashboard d = new Dashboard();
            panel6.Controls.Add(d);
            d.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
