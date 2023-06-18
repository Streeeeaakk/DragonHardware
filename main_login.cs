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
    
    public partial class main_login : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+AppDomain.CurrentDomain.BaseDirectory+"dragon.mdb");
        private static main_login form1 = new main_login();
        private static admin_user form2 = new admin_user();
        private static admin_acc form3 = new admin_acc();
        private static cashier_user form4 = new cashier_user();
        private static main_close form5 = new main_close();
        private static Inventoryacc form90 = new Inventoryacc();
        public static string sesID = "";
        public static string sesID1 = "";
       
        public main_login()
        {
            InitializeComponent();
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            updated_login_final();
        }

        private void updated_login_final()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Some Field are Empty!", "Notice!");
            }
            else
            {
               con.Open();
               String sql = "Select * from login_data where STRComp([Username],'" + textBox1.Text + "',0)=0 and STRComp([Password],'" + textBox2.Text + "',0)=0";
               OleDbCommand com = new OleDbCommand(sql, con);
               OleDbDataReader read = com.ExecuteReader(CommandBehavior.Default);

               int count = 0;

               while (read.Read())
               {
                   count++;
                   sesID = read[4].ToString();
                   sesID1 = read[0].ToString();
               }

               if (sesID == "admin")
               {
                   if (count > 0)
                   {
                       form2.Show();
                       form2.Enabled = true ;
                       this.Hide();
                   }
                   else if (count == 0)
                   {
                       MessageBox.Show("Wrong Credentials!");
                       textBox1.Text = "";
                       textBox2.Text = "";
                   }
               }
               else if (sesID == "cashier")
               {
                   if (count > 0)
                   {
                       form4.Show();
                       form4.Enabled = true;
                       this.Hide();
                   }
                   else if (count == 0)
                   {
                       MessageBox.Show("Wrong Credentials!");
                       textBox1.Text = "";
                       textBox2.Text = "";
                   }
               }
               else if(sesID == "inventory")
               {
                   if (count > 0)
                   {
                       form90.Show();
                       form90.Enabled = true;
                       this.Hide();
                   }
                   else if (count == 0)
                   {
                       MessageBox.Show("Wrong Credentials!");
                       textBox1.Text = "";
                       textBox2.Text = "";
                   }
               }
               else if (count == 0)
               {
                   MessageBox.Show("Wrong Credentials!");
                   textBox1.Text = "";
                   textBox2.Text = "";
               }
               con.Close();
            }
        }


        private void updated_login()
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Some Field are Empty!", "Notice!");
            }
            else
            {
                con.Open();
                String sql = "Select * from login_data where STRComp([Username],'" + textBox1.Text + "',0)=0 and STRComp([Password],'" + textBox2.Text + "',0)=0";
                OleDbCommand com = new OleDbCommand(sql, con);
                OleDbDataReader read = com.ExecuteReader(CommandBehavior.Default);

                int count = 0;

                while (read.Read())
                {
                    count++;
                    sesID = read[0].ToString();
                }

                if (count == 1)
                {
                    this.Hide();
                    form2.Show();
                }
                con.Close();

                if (count < 1)
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Some Field are Empty!", "Notice!");
                    }
                    else
                    {
                        con.Open();
                        String sql1 = "Select * from login_data_cashier where STRComp([Username],'" + textBox1.Text + "',0)=0 and STRComp([Password],'" + textBox2.Text + "',0)=0";
                        OleDbCommand com1 = new OleDbCommand(sql1, con);
                        OleDbDataReader read1 = com1.ExecuteReader(CommandBehavior.Default);

                        int count1 = 0;

                        while (read1.Read())
                        {
                            count1++;
                            sesID = read1[0].ToString();
                        }

                        if (count1 == 1)
                        {
                            this.Hide();
                            form4.Show();
                        }

                        con.Close();
                        if (count1 < 1)
                        {
                            if (textBox1.Text == "" || textBox2.Text == "")
                            {
                                MessageBox.Show("Some Field are Empty!", "Notice!");
                            }
                            else
                            {
                                con.Open();
                                String sql2 = "Select * from login_data_inv where STRComp([Username],'" + textBox1.Text + "',0)=0 and STRComp([Password],'" + textBox2.Text + "',0)=0";
                                OleDbCommand com2 = new OleDbCommand(sql2, con);
                                OleDbDataReader read2 = com2.ExecuteReader(CommandBehavior.Default);

                                int count2 = 0;

                                while (read2.Read())
                                {
                                    count2++;
                                    //sesID = read1[0].ToString();
                                }

                                if (count2 == 1)
                                {
                                    this.Hide();
                                    form90.Show();
                                }

                                con.Close();

                                if (count2 < 1)
                                {
                                    MessageBox.Show("Wrong Credentials!");
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                }
                            }
                        }

                    }
                }
            }
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



        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                updated_login_final();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                updated_login_final();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.SelectAll();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void main_login_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
