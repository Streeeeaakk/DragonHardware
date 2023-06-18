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
    public partial class addmeasurement : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        
        public addmeasurement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addit();
            textBox1.Text = "";
        }

        private void addit()
        {
            con.Open();
            try
            {
                string sql = "insert into UoM([Unit Of Measure])values('" + textBox1.Text + "')";
                OleDbCommand com = new OleDbCommand(sql, con);
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Field is Empty");
                }
                else
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("Measurement Added");

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
                MessageBox.Show("This type of measurement is already saved", "Error");
            }
            con.Close();
        }

        private void addmeasurement_Load(object sender, EventArgs e)
        {
            con.Open();
            String sql = "select * from UoM";
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader dr = com.ExecuteReader();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            editmeasure a = new editmeasure();
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
    }
}
