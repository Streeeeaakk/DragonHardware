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
    public partial class categoryy : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        
        public categoryy()
        {
            InitializeComponent();
        }

        private void categoryy_Load(object sender, EventArgs e)
        {
            ////hak();
        }

        //private void hak()
        //{
        //    con.Open();
        //    String sql = "select * from categs";
        //    OleDbCommand com = new OleDbCommand(sql, con);
        //    OleDbDataReader dr = com.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        comboBox1.Items.Add(dr["Category"]);
        //    }
        //    con.Close();

        //}

        private void addit()
        {
            con.Open();
            try
            {
                string sql = "insert into categs([Category])values('" + textBox1.Text + "')";
                OleDbCommand com = new OleDbCommand(sql, con);
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Field is Empty");
                }
                else
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("Category Added");

                    //editItems e = new editItems();
                    //e.Enabled = true;
                    //e.Show();
                    //e.Enabled = false;
                    //e.Hide();
                    //categoryy cs = new categoryy();
                    //cs.Show();

                }
            }
            catch
            {
                MessageBox.Show("This type of category is already saved", "Error");
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addit();
            textBox1.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatecateg a = new updatecateg();
            a.FormClosed += delegate
            {
                this.Show();
                a = null;
                this.Enabled = true;
            };
            this.Enabled = false;

            a.Show();
            a.Activate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                addit();
            }
        }
    }
}
