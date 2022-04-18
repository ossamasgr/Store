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
    public partial class transactions : UserControl
    {
        public transactions()
        {
            InitializeComponent();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            //if product doesn't exist suggest to add it (make it easy)
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int i = int.Parse(label5.Text);
            i += 1;
            label5.Text = i.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int i = int.Parse(label5.Text);
            i -= 1;
            label5.Text = i.ToString();
        }
    }
}
