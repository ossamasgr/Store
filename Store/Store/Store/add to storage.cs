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
    public partial class add_to_storage : Form
    {
        ADO d = new ADO();
        public add_to_storage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //[check if product exist]
            DateTime today = DateTime.Today;
            //add to storage
            d.cmd = new SqlCommand("update  storage set qte_in_stock = qte_in_stock + '"+bunifuMaterialTextbox4.Text+"', last_updated = '"+today+"' where id in (select id from storage where product_id = '"+bunifuMaterialTextbox1.Text+"')", d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            MessageBox.Show("Added '"+bunifuMaterialTextbox4.Text+"' To storage");
            d.DECONNECTER();
            this.Hide();
        }
    }
}
