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
    public partial class editmeasure : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        
        public editmeasure()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string sql = "Update UoM set [Unit Of Measure] ='" + textBox1.Text + "' where [Unit Of Measure] ='" + comboBox1.Text + "' ";
                OleDbCommand com = new OleDbCommand(sql, con);
                if (comboBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Some Fields are empty");
                }
                else
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    comboBox1.Text = "";
                    textBox1.Text = "";

                    re();
                }
            }
            catch
            {
                MessageBox.Show("This type of measurement is already saved", "Error");
            }
            con.Close();
        }
        private void re()
        {
            //this.Hide();
            //categoryy es = new categoryy();

            //es.Show();
           
            editmeasure a = new editmeasure();
            a.Hide();
            a.Show();
            //es.Enabled = false;
        }

        private void editmeasure_Load(object sender, EventArgs e)
        {
            hak();
        }
        private void hak()
        {
            con.Open();
            String sql = "select * from UoM";
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Unit Of Measure"]);
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "Delete from UoM where [Unit Of Measure] ='" + comboBox1.Text + "'";
            OleDbCommand com = new OleDbCommand(sql, con);

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Field is Empty");
            }
            else
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Deleted");

                re();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.Text;
        }
    }
}
