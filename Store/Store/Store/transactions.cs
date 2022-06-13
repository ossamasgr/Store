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
        string p_name = "product's name";
        float p_price = 00;
        float TotalPrice = 00;
        string user_id = ADO.GlobalVar;
        int id_t_use = 0;
        int qte = 1;


        public transactions()
        {
            InitializeComponent();
        }

        public static int check_product_existanse(string product_id)
        {
            // check if a product exist or not for a given product id 
            ADO d = new ADO();
            d.cmd = new SqlCommand("select count(*) from products where id = '" + product_id + "'", d.cnx);
            d.CONNECTER();
            int i = (int)d.cmd.ExecuteScalar();
            
            //if product doesn't exist suggest to add it
            if (i == 0)
            {
                int x = 0;
                return x;
            }
            else
            {
                int x = 1;
                return x;
            }

        }

        void increment_order_id()
        {
            // add 1 to order_id table 
            d.cmd = new SqlCommand("update order_id set id = id + 1", d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            d.DECONNECTER();
        }
        void suggest_toAdd_product()
        {
            string message = " Product Doesn't exist, Do you Want to add it ?";
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
                bunifuMaterialTextbox1.Focus();
            }
        }


        
        void to_default(int order_or_command)
        {
            // get the default values for textboxes,labels,variables...   
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox1.Focus();
            qte = 1;
            label3.Text = qte.ToString();
            // if 0 --> order if 1 --> command
            if(order_or_command == 1)
            {
                //focus on textbox 
                bunifuCustomDataGrid1.Rows.Clear();
                id_to_use();
                bunifuMaterialTextbox2.Text = "";
                qte = 1;
                label3.Text = qte.ToString();
            }
            
        }

        
        void get_product_infos(int product_id)
        {
            
            //gets a prduct name and price for a given product_id 
            d.cmd = new SqlCommand("select * from products where id = '"+product_id+"'",d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                p_name = d.dr[1].ToString();
                p_price = float.Parse(d.dr[2].ToString()) * qte;
            }
            d.DECONNECTER();

        }

        
        void qte_in_stock(string p_id)
        {
            // get a product quantity in stock 
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
            // gets the id to use as an order id from the talbe order_id 
            //the table order_id increments by 1 everytime an id is used 
            
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

        void add_order(int id_to_use, string p_id, string user_id, DateTime date, string quantity, string price)
        {
            // add an order
            
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
            order_dr[0] = id_to_use;
            //product id 
            order_dr[1] = p_id;
            // user id
            order_dr[2] = user_id;
            // order's date
            order_dr[3] = date;
            // quantity 
            order_dr[4] = quantity;
            //price
            order_dr[5] = price;

            ds.Tables["orders"].Rows.Add(order_dr);
        }
        void minus_storage()
        {
            // minus qte from storage
            if (ds_storage.Tables["storage"] != null)
            {
                ds_storage.Tables["storage"].Clear();
            }
            minus_store_da = new SqlDataAdapter("select * from storage", d.cnx);
            minus_store_da.Fill(ds_storage, "storage");
            for (int i = 0; i < ds_storage.Tables["storage"].Rows.Count; i++)
            {
                if (bunifuMaterialTextbox1.Text == ds_storage.Tables["storage"].Rows[i][0].ToString())
                {

                    ds_storage.Tables["storage"].Rows[i][1] = bunifuMaterialTextbox1.Text;                           
                    break;
                }
            }
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

            //   addd orders

            if (bunifuMaterialTextbox1.Text == "" || bunifuMaterialTextbox1.Text == " " || bunifuMaterialTextbox1.Text == null)
            {
                // do nothing if the Textbox is empty.
            }
            else
            {
                //Check if product Exist or not 
                string product_id = bunifuMaterialTextbox1.Text;
                int product_exist = check_product_existanse(product_id);

                //if product doesn't exist suggest to add it
                if (product_exist == 0)
                {
                    suggest_toAdd_product();
                }

                // if product exist add it to order
                else if (product_exist == 1)
                {
       
                    // get product's info 
                    // it updates product p_name and p_price variables with a given product id's name and price
                    get_product_infos(int.Parse(bunifuMaterialTextbox1.Text));

                

                    //add order
                    add_order
                        (id_t_use, //order id 
                         bunifuMaterialTextbox1.Text, //product id 
                         user_id, //user id
                         today,// today's date
                         qte.ToString(), // product's quantity 
                         p_price.ToString());// price * qte
                  
                    //add to datagrid
                    bunifuCustomDataGrid1.Rows.Add(false, // datagrid checkbox
                                                   id_t_use, // order's id 
                                                   p_name,//product's name 
                                                   p_price,// product's price
                                                   bunifuMaterialTextbox1.Text, //product's id 
                                                   qte,// quantity
                                                   ADO.GlobalVar); // user's id 
                    
                    // add price 
                    TotalPrice = TotalPrice + p_price;
                    bunifuMaterialTextbox2.Text = TotalPrice.ToString();
                    
                    // minus storage 
                    

                    //reset 
                    int order_or_command = 0;
                    to_default(order_or_command);
                    
                    
                    
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

            // add 1 to order_id table 
            increment_order_id();

            //save to command 
            d.cmd = new SqlCommand("insert into command values ('"+id_t_use+"','"+TotalPrice+"','"+today+"')",d.cnx);
            d.CONNECTER();
            d.cmd.ExecuteNonQuery();
            d.DECONNECTER();
            
            //print
          
            //reset 
            int order_or_command = 1;
            to_default(order_or_command);
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

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            //plus one 
            qte = qte + 1;
            label3.Text = qte.ToString();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //minus one 
            qte = qte - 1;
            label3.Text = qte.ToString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
