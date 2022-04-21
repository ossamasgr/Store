using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Store
{
    public partial class transactions : UserControl
    {
        ADO d = new ADO();
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
            bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox1.Text == " " || bunifuMaterialTextbox1.Text == null)
            {

            }
            else
            {
                //if product doesn't exist suggest to add it (make it easy)
                d.cmd = new SqlCommand("select count(*) from products where id = '" + bunifuMaterialTextbox1.Text + "'", d.cnx);
                d.CONNECTER();
                int i = (int)d.cmd.ExecuteScalar();
                if (i == 0)
                {
                     string message = " Product Doesn't exist.wanna add it ??";
                    string title = "Add Product";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        add_product_popup m = new add_product_popup();
                        m.Show();
                        
                    }
                }
            }


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
