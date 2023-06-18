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
    public partial class Form3 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        private static Form1 form1 = new Form1();
        private static Form2 form2 = new Form2();
        private static Form3 form3 = new Form3();
        public Form3()
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
               
                form3.Hide();
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
            form3.Close();
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
    }
}
