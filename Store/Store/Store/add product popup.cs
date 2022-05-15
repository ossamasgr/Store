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
    public partial class add_product_popup : Form
    {
        ADO d = new ADO();
        public add_product_popup()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //add To products 
            d.cmd = new SqlCommand("insert into products values('"+bunifuMaterialTextbox1.Text+"','"+bunifuMaterialTextbox2.Text+"','"+bunifuMaterialTextbox3.Text+"')",d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            d.DECONNECTER();
            
            //add To Storage 
            DateTime today = DateTime.Today;
            d.cmd = new SqlCommand("insert into storage(id,qte_in_stock,product_id,last_updated) values('" + bunifuMaterialTextbox1.Text + "','" + bunifuMaterialTextbox4.Text + "','" + bunifuMaterialTextbox1.Text + "','" + today + "')", d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            d.DECONNECTER();


            MessageBox.Show("Product '" + bunifuMaterialTextbox2.Text + "' with '" + bunifuMaterialTextbox4.Text + "' items added to the Store");
            //back to products
            this.Hide();
            
        }
    }
}
