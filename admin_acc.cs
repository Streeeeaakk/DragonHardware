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
    public partial class admin_acc : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        private static main_login form1 = new main_login();
        private static admin_user form2 = new admin_user();
        private static admin_acc form3 = new admin_acc();
        public static string sesID1 = "";
        public admin_acc()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "Update login_data set [Username]='" + textBox1.Text + "'  where [ID] = 1";
            OleDbCommand com = new OleDbCommand(sql, con);
            
                string sql1 = "Update login_data set[Password]='"+textBox2.Text+"' where [ID] = 1";
                OleDbCommand com1 = new OleDbCommand(sql1, con);


            
            if (textBox2.Text == textBox3.Text)
            {
                com.ExecuteNonQuery();
                com1.ExecuteNonQuery();
                MessageBox.Show("Account Details Updated!");

                acc_details a = new acc_details();
                a.Enabled = true;
                a.Show();
                this.Hide();
            }
            else if(textBox2.Text != textBox3.Text)
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

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            CheckBox checkbox = new CheckBox();
            checkbox.Appearance = Appearance.Button;
            checkbox.TextAlign = ContentAlignment.MiddleCenter;
            checkbox.MinimumSize = new Size(75, 25);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            h();
        }
        private void h()
        {
            sesID1 = main_login.sesID1;
            con.Open();
            string sql = "Update login_data set [Username]='" + textBox1.Text + "'  where [ID] = "+sesID1+"";
            OleDbCommand com = new OleDbCommand(sql, con);

            string sql1 = "Update login_data set[Password]='" + textBox2.Text + "' where [ID] = " + sesID1 + "";
            OleDbCommand com1 = new OleDbCommand(sql1, con);

            string sql2 = "Update login_data set[Name]='" + textBox4.Text + "' where [ID] = " + sesID1 + "";
            OleDbCommand com2 = new OleDbCommand(sql2, con);
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
                com2.ExecuteNonQuery();
                MessageBox.Show("Account Details Updated!");

               
                con.Close();

                this.Close();
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

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
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

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
