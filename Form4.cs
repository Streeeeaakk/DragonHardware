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
    public partial class Form4 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        private static Form1 form1 = new Form1();
        private static Form2 form2 = new Form2();
        private static Form3 form3 = new Form3();
        private static Form4 form4 = new Form4();
        private static int qty = 0;

        public Form4()
        {
            InitializeComponent();
        }
        private void deta()
        {
            String sql = "select * from DragonHardware";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MessageBox.Show("You logged in as Cashier");
            deta();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qty = int.Parse(textBox7.Text) + 1;
            textBox7.Text = qty.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            qty = int.Parse(textBox7.Text) - 1;
            textBox7.Text = qty.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "Update DragonHardware set [Quantity]='" + textBox7.Text + "' where [ID] = " + textBox8.Text + "";
            OleDbCommand com = new OleDbCommand(sql, con);
            com.ExecuteNonQuery();
            con.Close();
            deta();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form4.Close();
            Form6 form6 = new Form6();
            form6.Show();
        }
    }
}
