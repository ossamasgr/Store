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
    public partial class store1 : UserControl
    {
        ADO d = new ADO();
        public store1()
        {
            InitializeComponent();
        }
        void filldatagrid()
        {
            //filling datagrid
            bunifuCustomDataGrid1.Rows.Clear();
            d.cmd = new SqlCommand("select product_id,name,qte_in_stock,last_updated from storage s,products p where s.product_id = p.id ", d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                bunifuCustomDataGrid1.Rows.Add(false, d.dr[0], d.dr[1], d.dr[2],d.dr[3]);
            }
            d.dr.Close();
            d.DECONNECTER();
        }
        void filldatagrid_search(string user)
        {
            //filling datagrid
            bunifuCustomDataGrid1.Rows.Clear();
            d.cmd = new SqlCommand("select product_id,name,qte_in_stock,last_updated from storage s,products p where s.product_id = p.id and s.product_id like '%" + user + "%'", d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                bunifuCustomDataGrid1.Rows.Add(false, d.dr[0], d.dr[1], d.dr[2], d.dr[3]);
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

        private void store1_Load(object sender, EventArgs e)
        {
            //Load
            filldatagrid();
            // focus on search textbox
            bunifuTextbox1.text = "";
            bunifuTextbox1.Focus();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            bunifuTextbox1.text = "";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Delete 
            bunifuCustomDataGrid1.EndEdit();
            
            foreach (DataGridViewRow row in bunifuCustomDataGrid1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    //[delete from storage first then delete]
                    d.cmd = new SqlCommand("delete from storage where id  in (select id from storage where product_id = '" + row.Cells[1].Value.ToString() + "') ", d.cnx);
                    d.CONNECTER();
                    d.cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted '" + row.Cells[2].Value.ToString() + "'");
                    d.DECONNECTER();

                }
            }
            filldatagrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //add
            add_to_storage a = new add_to_storage();
            a.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            filldatagrid();
        }
    }
}