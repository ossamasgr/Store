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
            bunifuCustomDataGrid1.Rows.Clear();
            MessageBox.Show(bunifuDatepicker1.Value.ToString());
            d.cmd = new SqlCommand("select * from command where cmd_date = @date_j", d.cnx);
            d.cmd.Parameters.Add("@date_j", SqlDbType.Date).Value = bunifuDatepicker1.Value;
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
