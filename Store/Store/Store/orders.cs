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
        public orders()
        {
            InitializeComponent();
        }

        private void orders_Load(object sender, EventArgs e)
        {
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
    }
}
