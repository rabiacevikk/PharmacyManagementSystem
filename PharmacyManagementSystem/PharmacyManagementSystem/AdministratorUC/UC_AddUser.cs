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
    public partial class UC_AddUser : UserControl
    {
        function fn = new function();
        string query;
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string role = cmbUserRole.Text;
            String name = txtName.Text;
            string dob = dateTimePicker1.Text;
            string mobile = txtMobileNo.Text;
            string email = txtEmailAddress.Text;
            string username = txtUsername.Text;
            string pass = txtPassword.Text;
            try
            {                //add a user to a database
                query = "insert into users (userRole,name,dob,mobile,email,username,pass) values ('" + role + "','" + name + "','" + dob + "','" + mobile + "','" + email + "','" + username + "','" + pass + "')";
                fn.setData(query,"Sign Up Successful.");
                clearAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Username Already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //error message
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtName.Clear();          //Cleaning items
            dateTimePicker1.ResetText();
            txtMobileNo.Clear();
            txtEmailAddress.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbUserRole.ResetText();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username='" + txtUsername.Text + "'";
            DataSet ds = fn.getData(query);
            label10.Visible = true;
            if (ds.Tables[0].Rows.Count==0)
            {
                label10.ForeColor = Color.Green;
                label10.Text = "✔ "; //if the user name exists, a cross appears
            }
            else
            {
                label10.ForeColor = Color.Red;

                label10.Text = "X";  //if the user name exists, a cross appears
            }
        }
    }
}
