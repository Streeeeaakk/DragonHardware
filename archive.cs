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
    public partial class archive : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
       
        public archive()
        {
            InitializeComponent();
        }

        private void deta()
        {
            String sql = "select * from DragonArchive";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void archive_Load(object sender, EventArgs e)
        {
            deta();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No Items to Retrieve");
            }
            else
            {
                con.Open();
                string sql = "Insert into DragonHardware([ID],[Category],[Product Name],[UoM],[Original Price],[Selling Price],[Date Added],[Quantity])values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                OleDbCommand com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();
                string sql1 = "Delete from DragonArchive where [ID]='" + textBox1.Text + "'";
                OleDbCommand com1 = new OleDbCommand(sql1, con);
                com1.ExecuteNonQuery();
                MessageBox.Show("Item Retrieved");
                deta();
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("No Items to Delete");
            }
            else
            {

                con.Open();
                string sql = "delete from DragonArchive where [ID]='" + textBox1.Text + "'";
                OleDbCommand com = new OleDbCommand(sql, con);
                var a = MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                {
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted");
                    deta();
                }
                clearf();
            }
        }

        private void clearf()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "(Select Measure)";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "(Select Category)";
        }


        private void button5_Click(object sender, EventArgs e)
        {
            
                con.Open();
                string sql = "Delete from DragonArchive";
                OleDbCommand com = new OleDbCommand(sql, con);
            var a = MessageBox.Show("Are you sure you want to delete all items?", "Confirm", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                com.ExecuteNonQuery();
                deta();
                MessageBox.Show("All items deleted");
            }
                con.Close();

            
        }




    }
}
