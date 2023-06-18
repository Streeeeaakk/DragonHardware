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
    public partial class cashier_details : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        public static string sesID1 = "";
        public cashier_details()
        {
            InitializeComponent();
        }

        private void cashier_details_Load(object sender, EventArgs e)
        {
           
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();

            sesID1 = main_login.sesID1;
            if (textBox2.Text == textBox3.Text)
            {
               
                String sql2 = "Select * from login_data where [Username] = '" + textBox1.Text + "'";
                OleDbCommand com2 = new OleDbCommand(sql2, con);
                OleDbDataReader read = com2.ExecuteReader(CommandBehavior.Default);

                int count = 0;

                while (read.Read())
                {
                    count++;
                }

                if(count > 0){
                    MessageBox.Show("Username already exist. Please try a different username");
                    return;
                }
                con.Close();

                //////////////////////////////////////////////////////////////////////////////////////////////////////
                con.Open();
                string sql = "Insert into login_data([Username],[Password],[Name],[Login Type])values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "', 'cashier')";
                OleDbCommand com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();
                MessageBox.Show("New Cashier Added!");
                
                con.Close();

                this.Close();
            }
            else if(textBox1.Text == "" ||textBox2.Text == "" ||textBox3.Text == ""){
                MessageBox.Show("Some Fields Are Empty");
            }
            else
            {
                MessageBox.Show("Passwords does not match!");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
