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
    public partial class FrmAdminstrator : Form
    {
        String user = "";  //decvlaration of string variable
        public FrmAdminstrator()
        {
            InitializeComponent();
        }
        public string ID
        {
            get
            {
                return user.ToString();
            }
        }
        public FrmAdminstrator(String username)
        {
            InitializeComponent();
            lblUsername.Text = username;
            user = username;
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin fr = new FrmLogin();
            fr.Show();        //exit process
            this.Hide();
        }

        private void btnDashbord_Click(object sender, EventArgs e)
        {
            uC_Dashbord1.Visible = true;
            uC_Dashbord1.BringToFront();
        }

        private void FrmAdminstrator_Load(object sender, EventArgs e)
        {
            uC_Dashbord1.Visible = false;
            uC_AddUser1.Visible = false;
            uC_ViewUser1.Visible = false;
            uC_Profile1.Visible = false;
            btnDashbord.PerformClick();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true; //user control appears according to the button
            uC_ViewUser1.BringToFront();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }
    }
}
