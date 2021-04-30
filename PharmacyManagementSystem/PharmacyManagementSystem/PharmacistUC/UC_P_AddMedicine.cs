using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementSystem.PharmacistUC
{
    public partial class UC_P_AddMedicine : UserControl
    {
        function fn = new function();
        string query;
        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMedicineID.Text != "" && txtMedicineName.Text != "" && txtMedicineNumber.Text != "" && txtQuantity.Text != "" && txtPricepUnit.Text != "")
            {
                string mid = txtMedicineID.Text;       //recording the database
                string mname = txtMedicineName.Text;
                string mnumber = txtMedicineNumber.Text;
                string mdate = Convert.ToDateTime(dateTimeMD.Value).ToString("yyyy-MM-dd");
                string edate = Convert.ToDateTime(dateTimeExpireDate.Value).ToString("yyyy-MM-dd");
                Int64 quantity = Int64.Parse(txtQuantity.Text);
                Int64 perunit = Int64.Parse(txtPricepUnit.Text);
                query = "insert into medic (mid,mname,mnumber,mDate,eDate,quantity, perUnit) values ('" + mid + "','" + mname + "','" + mnumber + "','" + mdate + "','" + edate + "'," + quantity + "," + perunit + ")";
                fn.setData(query, "Medicine Added to Database.");
                clearAll();
               
            }
            else
            {
                MessageBox.Show("Enter all Data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);  //error message!
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMedicineID.Clear();
            txtMedicineName.Clear();
            txtQuantity.Clear();
            txtMedicineName.Clear();
            txtMedicineNumber.Clear();    //Cleaning items
            txtPricepUnit.Clear();
            dateTimeMD.ResetText();
            dateTimeExpireDate.ResetText();
        }

        private void UC_P_AddMedicine_Load(object sender, EventArgs e)
        {
            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
