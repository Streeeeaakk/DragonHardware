using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class acc_details : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
       
        public acc_details()
        {
            InitializeComponent();
        }

        private void acc_details_Load(object sender, EventArgs e)
        {
            deta();
        }

        private void deta()
        {
            String sql = "select * from login_data where not [Login Type] = 'admin'";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_acc a = new admin_acc();
            a.FormClosed += delegate
            {
                this.Show();
                a = null;
                this.Enabled = true;
            };
            this.Enabled = false;
            a.Show();
            a.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cashier_details a = new cashier_details();
            a.FormClosed += delegate
            {
                this.Show();
                a = null;
                this.Enabled = true;
            };
            this.Enabled = false;
            a.Show();
            a.Activate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            dataGridView1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "delete from login_data where [ID]=" + this.dataGridView1.CurrentRow.Cells[0].Value + "";
            OleDbCommand com = new OleDbCommand(sql, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            con.Close();
            panel1.Visible = false;
            dataGridView1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            deta();
        }


    }
}
