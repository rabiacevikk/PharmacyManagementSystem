using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;  //for SQL (library)
using System.Data;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-387VI6I\\MSSQLSERVER01;Initial Catalog=pharmacy;Integrated Security=True";  //connenction with database
            return con;
        }
        public DataSet getData(string query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);// create data adapter
            DataSet ds = new DataSet();  // create the DataSet 
            da.Fill(ds);     // fill the DataSet using our DataAdapter 
            return ds;
        }
        public void setData(string query,string msg)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();  //Connection open
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close(); //Connection Close
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);  // showing messagebox for confirmation message for user 
        }
    }
}
