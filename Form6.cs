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
    public partial class Form6 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
     
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "Update login_data set [Username]='" + textBox1.Text + "'  where [ID] = 2";
            OleDbCommand com = new OleDbCommand(sql, con);

            string sql1 = "Update login_data set[Password]='" + textBox2.Text + "' where [ID] = 2";
            OleDbCommand com1 = new OleDbCommand(sql1, con);



            if (textBox2.Text == textBox3.Text)
            {
                com.ExecuteNonQuery();
                com1.ExecuteNonQuery();
                MessageBox.Show("Account Details Updated!");
                Form6 form6 = new Form6();
                form6.Hide();
                Form4 form4 = new Form4();
                form4.Show();
            }
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password Does Not Match");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Some Fields Are Empty");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
