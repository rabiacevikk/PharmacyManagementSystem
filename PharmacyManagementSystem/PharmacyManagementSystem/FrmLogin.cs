using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Code Writer Rabia Çevik 30.04.2021
namespace PharmacyManagementSystem
{
    public partial class FrmLogin : Form
    {
        function fn = new function();
        string query;
        DataSet ds;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();  //closing 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();  //cleaning items
            txtPassword.Clear();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count==0)
            {
                if (txtUsername.Text=="root" && txtPassword.Text=="root")
                {
                    FrmAdminstrator fr = new FrmAdminstrator();
                    fr.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username='" + txtUsername.Text + "' and pass='" + txtPassword.Text + "'";
            ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count!=0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if (role=="Administrator")
                    {
                        FrmAdminstrator fr = new FrmAdminstrator();
                        fr.Show();
                        this.Hide();
                    }
                    else if (role=="Pharmacist")
                    {
                        FrmPharmacist fr = new FrmPharmacist();
                        fr.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username OR Password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    }

            }
        }
   
}
