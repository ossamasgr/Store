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
    public partial class orders : UserControl
    {
        ADO d = new ADO();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        public orders()
        {
            InitializeComponent();
        }
        // Filling User Combobox
        public void FillCombo()
        {
            comboBox1.Items.Clear();
            da = new SqlDataAdapter("select * from users", d.cnx);
            d.CONNECTER();
            da.Fill(ds, "users");
            comboBox1.DataSource = ds.Tables["users"];
            comboBox1.DisplayMember = "full_name";
            comboBox1.ValueMember = "id";
            d.DECONNECTER();
        }
        private void orders_Load(object sender, EventArgs e)
        {
            //fill combo with users
            FillCombo();

            // load orders
            d.cmd = new SqlCommand("select * from orders",d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                bunifuCustomDataGrid1.Rows.Add(d.dr[0],d.dr[1],d.dr[2],d.dr[3],d.dr[4]);
            }
            d.DECONNECTER();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            /*
             having 2 variables 
             [datepicked] : the date picked fro the datetimepicker with the start of the day(00:00:00) added to it 
             [datepicked_after]: the date picked fro the datetimepicker with the end of the day(23:59:59) added to it
             
             * so we can have a query that gets us all the orders of a selected day (O.O)
             
             */
            string datepicked = bunifuDatepicker1.Value.ToString("yyyy/MM/dd");
            datepicked = datepicked + " " + "00:00:00";
            string datepicked_after = bunifuDatepicker1.Value.ToString("yyyy/MM/dd");
            datepicked_after = datepicked_after + " " + "23:59:59";

            // filter by date
            bunifuCustomDataGrid1.Rows.Clear();
            //[to add the user to the filter, check for it's existense first if it exist apply the filter and if it's not don't apply]
            //check if user exist or not 
            d.cmd = new SqlCommand("select count (*) from users where  id = '"+comboBox1.SelectedValue.ToString()+"' ",d.cnx);
            d.CONNECTER();
            int i = (int)d.cmd.ExecuteScalar();
            if (i == 1)
            {
                // if the user exist 
                
                d.cmd = new SqlCommand("select order_id,product_id,full_name,order_date,qte from orders o , users u  where  o.user_id = u.id and  o.order_date between '" + datepicked + "' and '" + datepicked_after + "'  and o.user_id = '"+comboBox1.SelectedValue+"'", d.cnx);

                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(d.dr[0], d.dr[1], d.dr[2], d.dr[3], d.dr[4]);
                }
              
            }
            else
            {
                // if the user doesn't exist
                d.cmd = new SqlCommand("order_id,product_id,full_name,order_date,qte from orders o , users u where  o.user_id = u.id and  o.order_date between   '" + datepicked + "' and '" + datepicked_after + "' ", d.cnx);
               
                d.dr = d.cmd.ExecuteReader();
                while (d.dr.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(d.dr[0], d.dr[1], d.dr[2], d.dr[3], d.dr[4]);
                }
              
                d.dr.Close();
 
            }
            d.DECONNECTER();

            
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
