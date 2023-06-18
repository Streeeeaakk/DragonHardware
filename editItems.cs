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
    public partial class editItems : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        admin_user adm = new admin_user();

        public editItems()
        {
            InitializeComponent();
        }

        private void editItems_Load(object sender, EventArgs e)
        {
            
            deta();
            hak();
            hakk();
            //hakdo();
            comboBox1.Text = "(Select Category)";
            comboBox2.Text = "(Select Measure)";
            comboBox3.Text = "All";
            
            
        }
        

        private void hak()
        {
            con.Open();
            String sql = "select * from categs";
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Category"]);
            }
            con.Close();

        }
        private void hakk()
        {
            con.Open();
            String sql = "select * from UoM";
            OleDbCommand com = new OleDbCommand(sql, con);
            OleDbDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Unit Of Measure"]);
            }
            con.Close();

        }

        private void deta()
        {
            String sql = "select * from DragonHardware order by ID asc";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                var a = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                var b = int.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());

                if (a == 0)
                {
                    dataGridView1.Rows[i].Cells[7].Style = new DataGridViewCellStyle { BackColor = Color.Red };
                }
                else if (a <= b)
                {
                    dataGridView1.Rows[i].Cells[7].Style = new DataGridViewCellStyle { BackColor = Color.Orange };
                }
                else
                {
                    dataGridView1.Rows[i].Cells[7].Style = new DataGridViewCellStyle { BackColor = Color.Green };
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            addItem a = new addItem();
            a.FormClosed += delegate
            {
                this.Enabled = true;
                this.Show();
                a = null;
                
            };
            //this.Hide();
            this.Enabled = false;
            a.Show();
            a.Activate();
           
        }

        private void clearf()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "(Select Measure)";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";
            textBox9.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
            //textBox1.Visible = false;
            //label1.Visible = false;
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearf();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Some Fields Are empty, please fill up the fields properly");
            }
            else
            {
                con.Open();
                var a = MessageBox.Show("Are you sure you want to delete this item?", "Confirm", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                {
                    DateTime now = DateTime.Now;
                    string sql1 = "Insert into DragonArchive([ID],[Category],[Product Name],[UoM],[Original Price],[Selling Price],[Date Added],[Quantity])values('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                    OleDbCommand com1 = new OleDbCommand(sql1, con);
                    com1.ExecuteNonQuery();
                    string sql = "delete from DragonHardware where [ID]='" + textBox1.Text + "'";
                    OleDbCommand com = new OleDbCommand(sql, con);
                    com.ExecuteNonQuery();
                    
                    MessageBox.Show("Deleted");
                    string sql2 = "Insert into EditItems([Product ID],[Product Name],[Edit Type],[Date Edited])values('" + textBox1.Text + "','" + textBox2.Text + "','Delete Item','" + now + "')";
                    OleDbCommand com2 = new OleDbCommand(sql2, con);
                    com2.ExecuteNonQuery();
                    deta();
                    clearf();
                    
                }
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            archive a = new archive();
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

        private void button7_Click(object sender, EventArgs e)
        {
            deta();
            clearf();
        }

        private void re()
        {
            this.Hide();
            admin_user es = new admin_user();
            ////es.Enabled = true;
            es.Show();

            editItems a = new editItems();

            a.Show();
            //es.Enabled = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "Update DragonHardware set [ID] ='"+textBox1.Text+"', [Category] ='"+comboBox1.Text+"', [Product Name] = '"+textBox2.Text+"', [UoM] = '"+comboBox2.Text+"', [Original Price] ="+textBox4.Text+", [Selling Price] ="+textBox5.Text+",  [Quantity] ="+textBox7.Text+", [Date Added] ='"+textBox6.Text+ "', [Reorder Point] = " + textBox9.Text + " where [primaryKey]=" + textBox8.Text+"";
            
            OleDbCommand com = new OleDbCommand(sql, con);

            if (textBox1.Text == "" || comboBox1.Text == "(Select Category)" || textBox2.Text == "" || comboBox2.Text == "(Select Measure)" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Some Fields Are empty, please fill up the fields properly");
            }
            else
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Updated");
                DateTime now = DateTime.Now;
               // string s = now.ToString("dd/MM/yyyy");
                string sql1 = "Insert into EditItems([Product ID],[Product Name],[Edit Type],[Date Edited])values('"+textBox1.Text+"','"+textBox2.Text+"','Update Item Details','"+now+"')";
                OleDbCommand com1 = new OleDbCommand(sql1, con);
                com1.ExecuteNonQuery();
                deta();
                clearf();
            }


            con.Close();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.Text == "Piece")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "ID")
            {
                string sql = "select * from DragonHardware where [ID] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox3.Text == "Category")
            {
                string sql = "select * from DragonHardware where [Category] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox3.Text == "Product")
            {
                string sql = "select * from DragonHardware where [Product Name] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox3.Text == "UoM")
            {
                string sql = "select * from DragonHardware where [UoM] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox3.Text == "Original Price")
            {
                string sql = "select * from DragonHardware where [Original Price] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox3.Text == "Selling Price")
            {
                string sql = "select * from DragonHardware where [Selling Price] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox3.Text == "Date Added")
            {
                string sql = "select * from DragonHardware where [Date Added] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox3.Text == "Quantity")
            {
                string sql = "select * from DragonHardware where [Quantity] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                string sql = "select * from DragonHardware where [ID] like '%" + textBox3.Text + "%' or [Category] like '%" + textBox3.Text + "%' or [Product Name] like '%" + textBox3.Text + "%' or [UoM] like '%" + textBox3.Text + "%'or [Original Price] like '%" + textBox3.Text + "%' or [Selling Price] like '%" + textBox3.Text + "%' or [Date Added] like '%" + textBox3.Text + "%' or [Quantity] like '%" + textBox3.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            categoryy a = new categoryy();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Kilogram") 
            {
                label8.Text = "Kilogram:";
            }
            else if (comboBox2.Text == "Meter")
            {
                label8.Text = "Meter:";
            }
            else
            {
                label8.Text = "Quantity:";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                var vat = 0.12;
                var a = int.Parse(textBox4.Text);
                var total = a * vat;
                var total1 = a + total;
                textBox5.Text = total1 + "";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            addmeasurement a = new addmeasurement();
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

        private void button9_Click(object sender, EventArgs e)
        {
            addstock a = new addstock();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            edithistory a = new edithistory();
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
