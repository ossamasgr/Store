using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Store
{
    public partial class auth : Form
    {
        ADO d = new ADO();
        public auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // employee global variable 
            // to use in transactions
            ADO.GlobalVar = textBox1.Text;
            // checking the database for password:
            d.cmd = new SqlCommand("select count (*) from users where id = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", d.cnx);
            d.CONNECTER();
            int i = (int)d.cmd.ExecuteScalar();
            if (i == 1)
            {
                main m = new main();
                m.Show();
                this.Hide();
                ADO.GlobalVar = textBox1.Text;
            }
            else if (i == 0)
            {
                MessageBox.Show("information incorrect ||معلومات غير صحيحة  ");
            }
            d.DECONNECTER();
        }
    }
}
