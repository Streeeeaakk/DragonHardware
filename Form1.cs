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
    
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+AppDomain.CurrentDomain.BaseDirectory+"dragon.mdb");
        private static Form1 form1 = new Form1();
        private static Form2 form2 = new Form2();
        private static Form3 form3 = new Form3();
        private static Form4 form4 = new Form4();
        private static Form5 form5 = new Form5();
        public Form1()
        {
            InitializeComponent();
        }

       

        private void admin_login()
        { 
            
            
            string sql = "select * from login_data where Username='" + textBox1.Text + "' and Password ='" + textBox2.Text + "' and ID = 1";
            string sql1 = "select * from login_data where Username='" + textBox1.Text + "' and Password ='" + textBox2.Text + "' and ID = 2";
            
            con.Open();
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader reader = com.ExecuteReader();

            OleDbCommand com1 = new OleDbCommand(sql1, con);
            OleDbDataReader reader1 = com1.ExecuteReader();

                int count1 = 0;
                int count = 0;

                while (reader.Read())
                {
                    count++;
                }

                while (reader1.Read())
                {
                    count1++;
                }
                
           

       if(count== 1){
            
            if (count == 1)
            {
                form2.Show();
                this.Hide();
            }
            

       }

       else if (textBox1.Text == "" && textBox2.Text == "")
       {
           MessageBox.Show("Please enter username and password");
       }

       else if (textBox1.Text == "")
       {
           MessageBox.Show("Please enter username");

       }
       else if (textBox2.Text == "")
       {
           MessageBox.Show("Please enter password");
       }

       else if (count1 == 1)
       {
           if (count1 == 1)
           {
               
               form4.Show();
               this.Hide();
           }
         
       }
       else
       {
           MessageBox.Show("Wrong Credentials!");
           textBox1.Text = "";
           textBox2.Text = "";
       }

            con.Close();
        }

       
       

        private void button5_Click(object sender, EventArgs e)
        {
            
            admin_login();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            form5.ShowDialog();
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

        private void Form1_Load(object sender, EventArgs e)
        {

            CheckBox checkbox = new CheckBox();
            checkbox.Appearance = Appearance.Button;
            checkbox.TextAlign = ContentAlignment.MiddleCenter;
            checkbox.MinimumSize = new Size(75,25);

        }

       
    }
}
