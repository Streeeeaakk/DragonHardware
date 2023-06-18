using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class addstock : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");

        public addstock()
        {
            InitializeComponent();
        }

        private void addstock_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "(Select Product)";
            hak();
        }

        private void hak()
        {
            con.Open();
            String sql = "select * from DragonHardware";
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Product Name"]);
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int i;
            if(Int32.TryParse(a, NumberStyles.Integer, CultureInfo.InvariantCulture, out i))
            {


                OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandText = "Update DragonHardware SET [Quantity] = [Quantity] + @p where [Product Name] = '"+ comboBox1.Text +"'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@p", i);
                        con.Open();

                if (comboBox1.Text == "(Select Product)")
                {
                    MessageBox.Show("Please select a product!", "Error");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added!");
                    con.Close();
                    restock();
                }
            }
                

            }

        private void restock()
        {
            DateTime now = DateTime.Now;
            string s = now.ToString("dd/MM/yyyy");

            con.Open();
            string sql = "Insert into Restock([Product Name],[Items Added],[Date Updated])values('"+comboBox1.Text+"',"+textBox1.Text+",'"+s+"')";
            OleDbCommand com = new OleDbCommand(sql, con);
            com.ExecuteNonQuery();
            con.Close();
        }


        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            addstock a = new addstock();
            a.Enabled = false;
            restock re = new restock();
            re.Show();
        }
    }
}
