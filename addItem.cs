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
    public partial class addItem : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        editItems a = new editItems();
        public addItem()
        {
            InitializeComponent();
        }

        private void addItem_Load(object sender, EventArgs e)
        {
            hak();
            hakk();
            comboBox1.Text = "(Select Category)"; 
            comboBox2.Text = "(Select Measure)";
            
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
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            try
            {
                con.Open();
                string sql = "Insert into DragonHardware([ID],[Category],[Product Name],[UoM],[Original Price],[Selling Price],[Date Added],[Quantity],[Reorder Point])values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "'," + textBox7.Text + ", "+textBox3.Text+")";

                if (textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || comboBox2.Text == "(Select Measure)" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Some Fields Are empty, please fill up the fields properly");
                }
                else
                {

                    OleDbCommand com = new OleDbCommand(sql, con);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Item Added");
                    string sql1 = "Insert into EditItems([Product ID],[Product Name],[Edit Type],[Date Edited])values('" + textBox1.Text + "','" + textBox2.Text + "','Added Item','" + now + "')";
                    OleDbCommand com1 = new OleDbCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    clearf();
                }

            }
            catch
            {
                MessageBox.Show("Same ID", "ERROR");
            }
            con.Close();
        }
        private void hak()
        {
            con.Open();
            String sql = "select * from categs";
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Category"]);
            }
            con.Close();

        }
        private void hakk()
        {
            con.Open();
            String sql = "select * from UoM";
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Unit Of Measure"]);
            }
            con.Close();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                var vat = 0.12;
                var a = int.Parse(textBox4.Text);
                var total = a * vat;
                var total1 = a + total;
                textBox5.Text = total1 + "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //a.Enabled = true;
            //a.Show();

            //a.FormClosed += delegate
            //{
            //    this.Close();
            //    a = null;

            //};

            this.Close();
            //a.Show();
           // a.Activate();
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.Text == "Piece")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
