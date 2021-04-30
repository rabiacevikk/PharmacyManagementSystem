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
    public partial class UC_P_UpdateMedicine : UserControl
    {
        function fn = new function();
        string query;
        public UC_P_UpdateMedicine()
        {
            InitializeComponent();
        }

   

        private void UC_P_UpdateMedicine_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtMedicineID.Text!="")
            {
                query = "select * from medic where mid='" + txtMedicineID.Text + "'";
                DataSet ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtMedicineName.Text = ds.Tables[0].Rows[0][2].ToString();
          txtMedicineNumber.Text = ds.Tables[0].Rows[0][3].ToString();
                    dateTimeManufacturingDate.Text = ds.Tables[0].Rows[0][4].ToString();
                    dateTimeExpireDate.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtAQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtPricePerUnit.Text = ds.Tables[0].Rows[0][7].ToString();

                        }
                else
                {
                    MessageBox.Show("No Medicine with ID:" + txtMedicineID.Text + " exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
                else
                {
                    clearAll();
                }
            
        }
        private void clearAll()
        {
            txtAddQuantity.Clear();
            txtAQuantity.Clear();
            txtMedicineID.Clear();
            txtMedicineName.Clear();
            txtMedicineNumber.Clear();
            txtPricePerUnit.Clear();
            dateTimeExpireDate.ResetText();
            dateTimeManufacturingDate.ResetText();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        Int64 totalQuantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string mname = txtMedicineName.Text;
            string mnumber = txtMedicineNumber.Text;
            string mdate = dateTimeManufacturingDate.Text;
            string edate = dateTimeExpireDate.Text;
            string quantity=txtAQuantity.Text;
      string addQuantity = txtAddQuantity.Text;
            string unitprice =txtPricePerUnit.Text;
            Int64 a = Convert.ToInt64(quantity);
            Int64 b = Convert.ToInt64(addQuantity);
            totalQuantity = (b + a);
            query = "update medic set mname='" + mname + "',mnumber='" + mnumber + "',mDate='" + mdate + "',eDate='" + edate + "',quantity=" + totalQuantity + ",perUnit=" + unitprice + " where mid='" + txtMedicineID.Text + "'";
            fn.setData(query, "Medicine Details Updated.");


        }
    }
}
