using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyManagementSystem.AdministratorUC
{
    public partial class UC_Profile : UserControl
    {
        function fn = new function();
        string query;
        public UC_Profile()
        {
            InitializeComponent();
        }

      public string ID
        {
            set
            {
                lblUsername.Text = value;
            }
        }

        private void UC_Profile_Load(object sender, EventArgs e)
        {

        }

        private void UC_Profile_Enter(object sender, EventArgs e)
        {
            query = "select * from users where username='" + lblUsername.Text + "'";
           DataSet ds= fn.getData(query);
            cmbUserRole.Text = ds.Tables[0].Rows[0][1].ToString(); //direct output of user information in textbox
            txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDOB.Text = ds.Tables[0].Rows[0][3].ToString();
            txtMobileNo.Text = ds.Tables[0].Rows[0][4].ToString();
            txtEmailAddress.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0][7].ToString();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UC_Profile_Enter(this, null); //refresh
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String role = cmbUserRole.Text;
            String name = txtName.Text;
            String dob = txtDOB.Text;
            string mobile = txtMobileNo.Text;
            string email = txtEmailAddress.Text;
            string username = lblUsername.Text;  //Updation query
            string pass = txtPassword.Text;
            query = "update users set userRole='" + role + "',name='" + name + "',dob='" + dob + "',mobile='" + mobile + "',email='" + email + "',pass='" + pass + "' where username='"+username+"'";
            fn.setData(query,"Profile Updation Successful.");
        }
    }
}
