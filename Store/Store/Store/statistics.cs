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
    public partial class statistics : UserControl
    {
        public statistics()
        {
            InitializeComponent();
        }
        private void fillChart()
        {
            //AddXY value in chart1 in series named as Salary  
            chart1.Series["products"].Points.AddXY("tide", "10000");
            chart1.Series["products"].Points.AddXY("taous", "8000");
            chart1.Series["products"].Points.AddXY("eyoo", "7000");
            chart1.Series["products"].Points.AddXY("pepsi", "10000");
            chart1.Series["products"].Points.AddXY("colimo", "8500");
            //chart title  
            chart1.Titles.Add("Products Chart");
            //AddXY value in chart1 in series named as Salary  
            chart2.Series["employes"].Points.AddXY("mohammed", "12");
            chart2.Series["employes"].Points.AddXY("hamid", "8000");
            chart2.Series["employes"].Points.AddXY("zahir", "124");
            chart2.Series["employes"].Points.AddXY("messi", "1548");
            chart2.Series["employes"].Points.AddXY("toto", "302");
            //chart title  
            chart2.Titles.Add("employes Chart");
            //AddXY value in chart1 in series named as Salary  
            chart3.Series["Store"].Points.AddXY("makla", "12");
            chart3.Series["Store"].Points.AddXY("mchroba", "156");
            chart3.Series["Store"].Points.AddXY("l3dees", "4587");
            chart3.Series["Store"].Points.AddXY("sabon", "123");
            chart3.Series["Store"].Points.AddXY("7alawa", "5487");
            //chart title  
            chart3.Titles.Add("Store Chart");
            //AddXY value in chart1 in series named as Salary  
            chart4.Series["wt"].Points.AddXY("wt1", "10000");
            chart4.Series["wt"].Points.AddXY("wt2", "8000");
            chart4.Series["wt"].Points.AddXY("wt3", "7000");
            chart4.Series["wt"].Points.AddXY("wt4", "10000");
            chart4.Series["wt"].Points.AddXY("wt5", "8500");
            //chart title  
            chart4.Titles.Add("wt Chart");
        }  

        private void statistics_Load(object sender, EventArgs e)
        {
            fillChart();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }
    }
}
