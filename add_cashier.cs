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
    public partial class add_cashier : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
       
        public add_cashier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hak();
        }

        private void hak()
        {
            con.Open();
            string sql = "Insert into login_data([Username],[Password])values('"+textBox1.Text+"', '"+textBox2.Text+"')";
            OleDbCommand com = new OleDbCommand(sql, con);

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Some Fields Are Empty");
            }
            else if (textBox2.Text == textBox3.Text)
            {
                com.ExecuteNonQuery();
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
            a.Refresh();
            this.Hide();
        }
    }
}
