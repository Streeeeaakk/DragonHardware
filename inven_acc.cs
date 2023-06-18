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
    public partial class inven_acc : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        public static string sesID1 = "";
        public inven_acc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hak();
        }

        private void hak()
        {
            sesID1 = main_login.sesID1;
            con.Open();
            string sql = "Update login_data set [Username]='" + textBox1.Text + "'  where [ID] = " + sesID1 + "";
            OleDbCommand com = new OleDbCommand(sql, con);

            string sql1 = "Update login_data set[Password]='" + textBox2.Text + "' where [ID] = " + sesID1 + "";
            OleDbCommand com1 = new OleDbCommand(sql1, con);
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
                MessageBox.Show("Account Details Updated!");
                Inventoryacc a = new Inventoryacc();
                a.Enabled = true;
                a.Show();
                this.Hide();
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

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventoryacc a = new Inventoryacc();
            a.Enabled = true;
            a.Show();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                hak();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                hak();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                hak();
            }
        }

        private void inven_acc_Load(object sender, EventArgs e)
        {

        }
    }
}
