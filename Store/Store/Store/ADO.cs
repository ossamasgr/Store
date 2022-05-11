using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Store
{
    class ADO
    {
        // Declaration des objets sql
        public SqlConnection cnx = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        private static string employee = "dd";

        public static string GlobalVar
        {
            
            get { return employee; }
            set { employee = value; }
        }
        // declaration de la methode connecter
        public void CONNECTER()
        {
            if (cnx.State == ConnectionState.Closed || cnx.State == ConnectionState.Broken)
            {
                // cnx.ConnectionString = "Data Source=LENOVOPC;Initial Catalog=TDI;Integrated Security=True";
                cnx.ConnectionString = @"Data Source=DESKTOP-DE8GMO7\sqlexpress;Initial Catalog=store;Integrated Security=True";
                cnx.Open();
            }
        }

        // declaration de la methode deconnecter
        public void DECONNECTER()
        {
            if (cnx.State == ConnectionState.Open)
            {

                cnx.Close();
            }
        }
    }
}
