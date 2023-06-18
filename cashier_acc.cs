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
    public partial class cashier_acc : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
     
        public cashier_acc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h();
        }

        private void h()
        {
            con.Open();
            string sql = "Update login_data set [Username]='" + textBox1.Text + "'  where [ID] = 'cashierID'";
            OleDbCommand com = new OleDbCommand(sql, con);

            string sql1 = "Update login_data set[Password]='" + textBox2.Text + "' where [ID] = 'cashierID'";
            OleDbCommand com1 = new OleDbCommand(sql1, con);


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Some Fields Are Empty");
            }
            else if (textBox2.Text == textBox3.Text)
            {
                com.ExecuteNonQuery();
                com1.ExecuteNonQuery();
                MessageBox.Show("Account Details Updated!");
                acc_details a = new acc_details();
                a.Enabled = true;
                a.Show();
                a.Refresh();
                this.Hide();
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
            acc_details a = new acc_details();
            a.Enabled = true;
            a.Show();
            this.Hide();
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

        private void cashier_acc_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                h();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                h();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                h();
            }
        }
    }
}
