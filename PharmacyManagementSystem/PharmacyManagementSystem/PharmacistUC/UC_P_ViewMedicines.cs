﻿using System;
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
    public partial class UC_P_ViewMedicines : UserControl
    {
        function fn = new function();
        string query;

        public UC_P_ViewMedicines()
        {
            InitializeComponent();
        }

        private void UC_P_ViewMedicines_Load(object sender, EventArgs e)
        {
            query = "select * from medic";
            setDataGridView(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medic where mname like '" + txtSearch.Text + "%'";
            setDataGridView(query);
            
        }
        private void setDataGridView(String query)
        {
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?","Delete Confirmation !",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                query = "delete from medic where mid= '" + medicineId + "'";
                fn.setData(query, "Medicine Record Deleated.");
                UC_P_ViewMedicines_Load(this, null);
            }
        }
        String medicineId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medicineId = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_ViewMedicines_Load(this, null);
        }
    }
}
