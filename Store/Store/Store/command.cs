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
    public partial class command : UserControl
    {
        ADO d = new ADO();
        public command()
        {
            InitializeComponent();
        }

        private void command_Load(object sender, EventArgs e)
        {
            //set datetimepicker format 
              

            //commands
            d.cmd = new SqlCommand("select * from command",d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                bunifuCustomDataGrid1.Rows.Add(d.dr[0],d.dr[1],d.dr[2]);

            }
            d.DECONNECTER();
            d.dr.Close();
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
            d.cmd = new SqlCommand("select * from command where  cmd_date  between '" + datepicked + "' and '" + datepicked_after + "' ", d.cnx);
            d.CONNECTER();
            d.dr = d.cmd.ExecuteReader();
            while (d.dr.Read())
            {
                bunifuCustomDataGrid1.Rows.Add(d.dr[0], d.dr[1], d.dr[2]);
            }
            d.DECONNECTER();
            d.dr.Close();

          
        }
    }
}
