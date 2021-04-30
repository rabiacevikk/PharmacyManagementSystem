using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementSystem.PharmacistUC
{
    public partial class UC_P_Dashbord : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;
        Int64 count;
        public UC_P_Dashbord()
        {
            InitializeComponent();
        }
        private void UC_P_Dashbord_Load(object sender, EventArgs e)
        {
            DateTime.Now.ToString("yyyy-MM-dd");
            loadChart();
        }
        public void loadChart()
        {
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            query = "select count(mname) from medic where eDate >= getdate()";
            ds = fn.getData(query);
            count =Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Valid Medicines"].Points.AddXY("Medicine Validity Chart", count);
            DateTime.Now.ToString("yyyy-MM-dd");


            query = "select count(mname) from medic where eDate <= getdate()";
            ds = fn.getData(query);
            count = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            this.chart1.Series["Expired Medicines"].Points.AddXY("Medicine Validity Chart", count);

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadChart();
        }
    }
}
