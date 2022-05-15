using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Store
{
    public partial class transactions : UserControl
    {
        ADO d = new ADO();
        DataSet ds = new DataSet();
        DataSet ds_storage = new DataSet();
        DataRow order_dr;
        SqlDataAdapter order_da;
        DateTime today = DateTime.Now;
        SqlDataAdapter minus_store_da;
        string product_quantity;
        string name = "product's name";
        float price = 00;
        float TotalPrice = 00;
        string user_id = ADO.GlobalVar;
        int id_t_use = 0;
        
        public transactions()
        {
            InitializeComponent();
        }
        void reset()
        {
            bunifuMaterialTextbox1.Text = "";
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuMaterialTextbox1.Focus();
            id_to_use();
            bunifuMaterialTextbox2.Text = "";
        }
        void get_product_infos(int product_id)
        { 

            //gets a prduct name and price for a given product_id 
            d.cmd = new SqlCommand("select * from products where id = '"+product_id+"'",d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                name = d.dr[1].ToString();
                price = float.Parse(d.dr[2].ToString());
            }
            d.DECONNECTER();

        }
        void qte_in_stock(string p_id)
        {
            
            d.cmd = new SqlCommand("select qte_in_stock from storage where product_id = '" + p_id + "' ", d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                 product_quantity =  d.dr[0].ToString();
            }
            d.DECONNECTER();
                    }
        void id_to_use()
        {
            //get the order id to use in insert (save)
            //first get the last used id from the table order_id
            d.cmd = new SqlCommand("select id from order_id",d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            if (d.dr.Read())
            {
                id_t_use = (int)d.dr[0] + 1;
                //MessageBox.Show(id_to_use.ToString());
            }
                
            d.DECONNECTER();
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
            bunifuMaterialTextbox1.Focus();
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
                    else
                    {
                        bunifuMaterialTextbox1.Text = "";
                    }
                }
                else
                {
       
                    //get product's info 
                    get_product_infos(int.Parse(bunifuMaterialTextbox1.Text));
                    
                    /*
                     
                    save to order using the Disconnected  method 
                    why ?
                    we're not sure if the end user is going to save the order or not 
                    so we don't save unless he clicks the save and print button
                     
                     */

                    order_da = new SqlDataAdapter("select * from orders", d.cnx);
                    order_da.Fill(ds, "orders");
                    order_dr = ds.Tables["orders"].NewRow();
                    //order id 
                    order_dr[0] = id_t_use;
                    //product id 
                    order_dr[1] = bunifuMaterialTextbox1.Text;
                    // user id
                    order_dr[2] = user_id;
                    // order's date
                    order_dr[3] = today;
                    // quantity 
                    order_dr[4] = "1";
                    ds.Tables["orders"].Rows.Add(order_dr);
                    
                    //add to datagrid
                    bunifuCustomDataGrid1.Rows.Add(false,id_t_use, name, price, bunifuMaterialTextbox1.Text, 1, ADO.GlobalVar);
                    
                    // add price 
                    TotalPrice = TotalPrice + price;
                    bunifuMaterialTextbox2.Text = TotalPrice.ToString();

                    // minus store

                    //get product's quantity in stock 
                    qte_in_stock(bunifuMaterialTextbox1.Text.ToString());

                    minus_store_da = new SqlDataAdapter("select * from storage where product_id = '" + bunifuMaterialTextbox1.Text + "' ", d.cnx);
                    minus_store_da.Fill(ds_storage, "storage");

                    for (int a = 0; a < ds_storage.Tables["storage"].Rows.Count; a++)
                    {

                        if (bunifuMaterialTextbox1.Text == ds_storage.Tables["storage"].Rows[a][0].ToString())
                        {
                            int q_s = int.Parse(product_quantity);
                            q_s = q_s - 1;

                            ds_storage.Tables["storage"].Rows[a][1] = q_s.ToString();
                            
                        }
                    }

                    //focus on textbox 
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox1.Focus();

                    
                    
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
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // delete from data grid 
           
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            //save to orders 
            SqlCommandBuilder cb_order = new SqlCommandBuilder(order_da);
            order_da.Update(ds, "orders");
            
            //save minus storage
            SqlCommandBuilder cb_minus_store = new SqlCommandBuilder(minus_store_da);
            minus_store_da.Update(ds_storage, "storage");

            // add 1 to order_id table 
            d.cmd = new SqlCommand("update order_id set id = id + 1",d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            d.DECONNECTER();

            //save to command 
            d.cmd = new SqlCommand("insert into command values ('"+id_t_use+"','"+TotalPrice+"','"+today+"')",d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            d.DECONNECTER();
            
            //print
          
            //reset
            reset();
        }

        private void transactions_Load(object sender, EventArgs e)
        {
            // get id to use 
            id_to_use();
           
            //focus on textbox
            bunifuMaterialTextbox1.Focus();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
