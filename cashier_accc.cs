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
    public partial class cashier_accc : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        public static string sesID1 = "";

        public cashier_accc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h();
        }
        private void h()
        {
            sesID1 = main_login.sesID1;
            con.Open();
            String sql4 = "select * from login_data Where ID = " + sesID1 + "";
            OleDbCommand com4 = new OleDbCommand(sql4, con);
            OleDbDataReader read1 = com4.ExecuteReader(CommandBehavior.Default);

            while (read1.Read())
            {
                sesID1 = read1[0].ToString();
            }
            string sql = "Update login_data set [Username]='" + textBox1.Text + "'  where [ID] = "+ sesID1 +"";
            OleDbCommand com = new OleDbCommand(sql, con);

            string sql1 = "Update login_data set[Password]='" + textBox2.Text + "' where [ID] = " + sesID1 + "";
            OleDbCommand com1 = new OleDbCommand(sql1, con);

            //string sql2 = "Update login_data set[Name]='" + textBox4.Text + "' where [ID] = " + sesID1 + "";
            //OleDbCommand com2 = new OleDbCommand(sql2, con);
            con.Close();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Some Fields Are Empty");
            }
            else if (textBox2.Text == textBox3.Text)
            {
                con.Open();
                String sql3 = "Select * from login_data where [Username] = '" + textBox1.Text + "'";
                OleDbCommand com3 = new OleDbCommand(sql3, con);
                OleDbDataReader read = com3.ExecuteReader(CommandBehavior.Default);

                int count = 0;
                
                while (read.Read())
                {
                    count++;
                }

                if (count > 0)
                {
                    MessageBox.Show("Username already exist. Please try a different username");
                    return;
                }
                

                //////////////////////////////////////////////////////////////////////////////////////////////////////
                com.ExecuteNonQuery();
                com1.ExecuteNonQuery();
                //com2.ExecuteNonQuery();
                MessageBox.Show("Account Details Updated!");
                this.Close();
                con.Close();
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

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
         
        
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

        private void cashier_accc_Load(object sender, EventArgs e)
        {

        }


    }
}
