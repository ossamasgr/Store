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
    public partial class Product : UserControl
    {
        ADO d = new ADO();

        public Product()
        {
            InitializeComponent();
        }
        void filldatagrid()
        {
            //filling datagrid
            bunifuCustomDataGrid1.Rows.Clear();
            d.cmd = new SqlCommand("select * from products ", d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                bunifuCustomDataGrid1.Rows.Add(false, d.dr[0], d.dr[1], d.dr[2]);
            }
            d.dr.Close();
            d.DECONNECTER();
        }
        void filldatagrid_search(string user)
        {
            //filling datagrid
            bunifuCustomDataGrid1.Rows.Clear();
            d.cmd = new SqlCommand("select * from products where id like '%" + user + "%'", d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                bunifuCustomDataGrid1.Rows.Add(false, d.dr[0], d.dr[1], d.dr[2]);
            }
            d.dr.Close();
            d.DECONNECTER();
        }
        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Product_Load(object sender, EventArgs e)
        {
            //filling datagrid
            filldatagrid();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //add
            add_product_popup a = new add_product_popup();
            a.Show();
           
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //delete            
            bunifuCustomDataGrid1.EndEdit();

            foreach(DataGridViewRow row in bunifuCustomDataGrid1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    //[delete from storage first then delete]
                    d.cmd = new SqlCommand("delete from products where id  = '" + row.Cells[1].Value.ToString()+ "'", d.cnx);
                    d.CONNECTER();
                    d.cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted '"+row.Cells[2].Value.ToString()+"'");
                    d.DECONNECTER();
                   
                }
            }
            filldatagrid();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Clear();
            //fill datagrid if textbox is empty and if not 
            //search for product using it's value
            if (bunifuTextbox1.text == "")
            {
                filldatagrid();
            }
            else
            {
                filldatagrid_search(bunifuTextbox1.text);
            }
           
        }

        private void bunifuTextbox1_Click(object sender, EventArgs e)
        {
            bunifuTextbox1.text = "";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            bunifuTextbox1.text = "";
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //apply
            bunifuCustomDataGrid1.EndEdit();
            filldatagrid();
        }
    }
}
