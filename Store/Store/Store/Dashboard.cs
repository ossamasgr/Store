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
    public partial class Dashboard : UserControl
    {
        ADO d = new ADO();
        
        public Dashboard()
        {
            InitializeComponent();
        }



        void user_infos(int id)
        {
            
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;

            label1.Text = today.ToString();
            bunifuCircleProgressbar1.Value = 70;
            bunifuCircleProgressbar2.Value = 80;
            bunifuCircleProgressbar3.Value = 30;
            //AddXY value in chart1 in series named as Salary  
            chart1.Series["products"].Points.AddXY("tide", "10000");
            chart1.Series["products"].Points.AddXY("taous", "8000");
            chart1.Series["products"].Points.AddXY("eyoo", "7000");
            chart1.Series["products"].Points.AddXY("pepsi", "10000");
            chart1.Series["products"].Points.AddXY("colimo", "8500");
            //chart title  
            chart1.Titles.Add("Products Chart");
            //AddXY value in chart1 in series named as Salary  
            chart2.Series["sales"].Points.AddXY("mohammed", "12");
            chart2.Series["sales"].Points.AddXY("hamid", "8000");
            chart2.Series["sales"].Points.AddXY("zahir", "124");
            chart2.Series["sales"].Points.AddXY("messi", "1548");
            chart2.Series["sales"].Points.AddXY("toto", "302");
            //chart title  
            chart2.Titles.Add("sales Chart");
        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {
            // get the data
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
