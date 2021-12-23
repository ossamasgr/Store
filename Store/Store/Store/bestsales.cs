using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class bestsales : UserControl
    {
        public bestsales()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bestsales_Load(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.Value = 50;
            bunifuCircleProgressbar2.Value = 70;
            bunifuCircleProgressbar3.Value = 30;
            //AddXY value in chart1 in series named as Salary  
            chart1.Series["products"].Points.AddXY("tide", "10000");
            chart1.Series["products"].Points.AddXY("taous", "8000");
            chart1.Series["products"].Points.AddXY("eyoo", "7000");
            chart1.Series["products"].Points.AddXY("pepsi", "10000");
            chart1.Series["products"].Points.AddXY("colimo", "8500");
            //chart title  
            chart1.Titles.Add("Products Chart");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
