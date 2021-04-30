using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementSystem
{
    public partial class FrmPharmacist : Form
    {
        public FrmPharmacist()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin fr = new FrmLogin(); //login form opens when the user click log out
            fr.Show();
            this.Hide(); //hiding the page
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uC_P_Dashbord1.Visible = true;
            uC_P_Dashbord1.BringToFront();
        }

        private void FrmPharmacist_Load(object sender, EventArgs e)
        {
            uC_P_Dashbord1.Visible = false;
            btnDashbord.PerformClick();
            uC_P_AddMedicine1.Visible = false;  //According to the clicked button, we used visible to open the desired page.
            uC_P_ViewMedicines1.Visible = false;                          
            uC_P_UpdateMedicine1.Visible = false;
            uC_P_MedicineValidityCheck1.Visible = false;
            uC_P_SellMedicine1.Visible = false;

        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uC_P_AddMedicine1.Visible = true;                 
            uC_P_AddMedicine1.BringToFront();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uC_P_ViewMedicines1.Visible = true;
            uC_P_ViewMedicines1.BringToFront();
        }

        private void btnModifyMedicine_Click(object sender, EventArgs e)
        {
            uC_P_UpdateMedicine1.Visible = true;
            uC_P_UpdateMedicine1.BringToFront();
        }

        private void btnMedicineValidityCheck_Click(object sender, EventArgs e) 
        {
            uC_P_MedicineValidityCheck1.Visible = true;
            uC_P_MedicineValidityCheck1.BringToFront();
         }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            uC_P_SellMedicine1.Visible = true;
            uC_P_SellMedicine1.BringToFront();
        }
    }
}
