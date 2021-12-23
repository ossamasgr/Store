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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            transactions h = new transactions();
            panel2.Controls.Add(h);
            h.Dock = DockStyle.Fill;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            bestsales s = new bestsales();
            panel2.Controls.Add(s);
            s.Dock = DockStyle.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Product s = new Product();
            panel2.Controls.Add(s);
            s.Dock = DockStyle.Fill;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            store1 s = new store1();
            panel2.Controls.Add(s);
            s.Dock = DockStyle.Fill;

        }
        

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Yellow;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }
       

        private void label2_MouseEnter_1(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Yellow;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Yellow;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Yellow;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            admin_area s = new admin_area();
            panel2.Controls.Add(s);
            s.Dock = DockStyle.Fill;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Yellow;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();       
            panel3.Visible = false;
            transactions h = new transactions();
            panel2.Controls.Add(h);
            h.Dock = DockStyle.Fill;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

       

    }
}
