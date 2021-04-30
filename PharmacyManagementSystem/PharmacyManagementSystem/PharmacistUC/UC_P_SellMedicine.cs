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
    public partial class UC_P_SellMedicine : UserControl
    {
        function fn = new function();
        string query;  
        DataSet ds;
        public UC_P_SellMedicine()
        {
            InitializeComponent();
        }

        private void UC_P_SellMedicine_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            query = "select mname from medic where eDate >= getdate() and quantity >'0'"; //Drug name lists into the listbox
            ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_SellMedicine_Load(this, null);  //refresh
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();  //search process data in listbox
            query = "select mname from medic where mname like'" + txtSearch.Text + "%' and eDate >=getdate() and quantity>'0' ";
            ds = fn.getData(query);
            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoOfUnits.Clear();
            string name = listBox1.GetItemText(listBox1.SelectedItem); //When we click on the drug in the listbox, its information is written to the textboxes.
            txtMedicineName.Text = name;
            query = "select mid,eDate,perUnit from medic where mname ='" + name + "'";
            ds = fn.getData(query);
            txtMedicineID.Text = ds.Tables[0].Rows[0][0].ToString();
            dateTimeEDate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPricePerUnit.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void txtNoOfUnits_TextChanged(object sender, EventArgs e)
        {
            if (txtNoOfUnits.Text!="") //if something is entered
            {
                string unitPrice= txtPricePerUnit.Text;
                string noOfUnit = txtNoOfUnits.Text;
                Int64 a = Int64.Parse(unitPrice);
                Int64 b = Int64.Parse(noOfUnit);
                Int64 totalAmount = a * b;  //Calculation 
                txtTotalPrice.Text = totalAmount.ToString(); //printing


            }
            else
            {
                txtTotalPrice.Clear();
            }
        }
        private void btnPurchaseandPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();  //printing process and purchase
            print.Title = "Medicine Bill";
            print.SubTitle = String.Format("Date: - {0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer="Total Payable amount :"+lblTotalAmount.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(dataGridView1);
            totalAmount = 0; //reset
            lblTotalAmount.Text = " Rs. 00"; //reset
            dataGridView1.DataSource = 0; //reset

        }
        private void clearAll()
        {
            txtMedicineID.Clear();  //cleaning items
            txtMedicineName.Clear();
            txtNoOfUnits.Clear();
            txtPricePerUnit.Clear();
            txtSearch.Clear();
            txtTotalPrice.Clear();
            dateTimeEDate.ResetText();
        }
        int valueAmount;  //Declaration 
        string valueId;
        int totalAmount;
        protected Int64 noOfunit;
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (valueId!=null)  // if id is not null
            {
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                    query = "select quantity from medic where mid='" + valueId + "'"; //selection query
                    ds = fn.getData(query);
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfunit;
                    query = "update  medic set quantity ='" + newQuantity + "' where mid='" + valueId + "'";
                    fn.setData(query, "Medicine Removed from Cart.");
                    totalAmount = totalAmount - valueAmount;  //calculation 
                    lblTotalAmount.Text = "Rs. " + totalAmount.ToString();
                
                UC_P_SellMedicine_Load(this, null);
            }
        }
        protected int n;
        protected Int64 quantity,newQuantity;
        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (txtMedicineID.Text != "")
            {
                query = "select quantity from medic where mid='" + txtMedicineID.Text + "'";
                ds = fn.getData(query);
                quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = quantity - Int64.Parse(txtNoOfUnits.Text);
                if (newQuantity>=0)
                {                                 //we insert a row in gridview by using textboxes         
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = txtMedicineID.Text;
                    dataGridView1.Rows[n].Cells[1].Value = txtMedicineName.Text;
                    dataGridView1.Rows[n].Cells[2].Value = dateTimeEDate.Text;
                    dataGridView1.Rows[n].Cells[3].Value = txtPricePerUnit.Text;
                    dataGridView1.Rows[n].Cells[4].Value = txtNoOfUnits.Text;
                    dataGridView1.Rows[n].Cells[5].Value = txtTotalPrice.Text;
                    totalAmount = totalAmount + int.Parse(txtTotalPrice.Text);
                    lblTotalAmount.Text = "Rs. " + totalAmount.ToString();
                    query = "update medic set quantity ='" + newQuantity + "' where mid='"+txtMedicineID.Text+"'";  //updation query
                    fn.setData(query, "Medicine Added");
                }
                else
                {
                    MessageBox.Show("Medicine is out of Stock.\n Only " + quantity + " Left", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);  //error message 
                }
            }
        }
    }
}
