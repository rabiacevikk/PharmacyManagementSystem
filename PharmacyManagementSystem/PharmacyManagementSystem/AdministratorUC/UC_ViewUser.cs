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
    public partial class UC_ViewUser : UserControl
    {
        function fn = new function();
        string query;
        String currentUser = "";
        public UC_ViewUser()
        {
            InitializeComponent();
        }
        public string ID
        {
            set
            {
                currentUser = value;
            }
        }
        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "select * from users";  //Selection query 
         DataSet ds= fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];//printing users in the datagridview

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like'" + txtUsername.Text + "%'";
            DataSet ds = fn.getData(query);                                       
            dataGridView1.DataSource = ds.Tables[0];

        }
        string userName;  //String declaration
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); //username of the person clicked on the datagrit
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Delete Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) //confirmation question
            {
                if (currentUser != userName)
                {
                    query = "delete from users where username='" + userName + "'";  //deletion query
                    fn.setData(query,"User Record Deleated.");
                    UC_ViewUser_Load(this, null); //refresh
                }
                else
                {
                    MessageBox.Show("You are trying to delete \n Your own Profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);  //don't try to erase yourself
                }
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this, null); //refresh
        }
    }
}
