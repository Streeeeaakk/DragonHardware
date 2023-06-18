using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DGVPrinterHelper;

namespace WindowsFormsApplication1
{
    public partial class Inventoryacc : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        private static main_login form1 = new main_login();
        private static admin_user form2 = new admin_user();
        private static admin_acc form3 = new admin_acc();

        public Inventoryacc()
        {
            InitializeComponent();
        }

        private void Inventoryacc_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "All";
            view();
           
        }
        

        public void view()
        {
            String sql = "select [ID],[Category],[Product Name],[UoM],[Original Price],[Selling Price],[Date Added],[Quantity],[Reorder Point] from DragonHardware";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            //hak();
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                var a = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                var b = int.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());

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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                string sql = "select * from DragonHardware where [ID] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Category")
            {
                string sql = "select * from DragonHardware where [Category] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Product")
            {
                string sql = "select * from DragonHardware where [Product Name] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "UoM")
            {
                string sql = "select * from DragonHardware where [UoM] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Original Price")
            {
                string sql = "select * from DragonHardware where [Original Price] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Selling Price")
            {
                string sql = "select * from DragonHardware where [Selling Price] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Date Added")
            {
                string sql = "select * from DragonHardware where [Date Added] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Quantity")
            {
                string sql = "select * from DragonHardware where [Quantity] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                string sql = "select * from DragonHardware where [ID] like '%" + textBox9.Text + "%' or [Category] like '%" + textBox9.Text + "%' or [Product Name] like '%" + textBox9.Text + "%' or [UoM] like '%" + textBox9.Text + "%'or [Original Price] like '%" + textBox9.Text + "%' or [Selling Price] like '%" + textBox9.Text + "%' or [Date Added] like '%" + textBox9.Text + "%' or [Quantity] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2.Enabled = false;
            main_close close = new main_close();
            close.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            inven_acc a = new inven_acc();
            a.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string s = now.ToString("dd/MM/yyyy");
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Dragon Hardware";
            printer.SubTitle = "Inventory Report " + s;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Dragon Hardware";
            printer.FooterSpacing = 15;
            
            printer.PrintDataGridView(dataGridView1);
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ID")
            {
                string sql = "select * from DragonHardware where [ID] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Category")
            {
                string sql = "select * from DragonHardware where [Category] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Product")
            {
                string sql = "select * from DragonHardware where [Product Name] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "UoM")
            {
                string sql = "select * from DragonHardware where [UoM] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Original Price")
            {
                string sql = "select * from DragonHardware where [Original Price] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Selling Price")
            {
                string sql = "select * from DragonHardware where [Selling Price] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Date Added")
            {
                string sql = "select * from DragonHardware where [Date Added] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (comboBox1.Text == "Quantity")
            {
                string sql = "select * from DragonHardware where [Quantity] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                string sql = "select * from DragonHardware where [ID] like '%" + textBox9.Text + "%' or [Category] like '%" + textBox9.Text + "%' or [Product Name] like '%" + textBox9.Text + "%' or [UoM] like '%" + textBox9.Text + "%'or [Original Price] like '%" + textBox9.Text + "%' or [Selling Price] like '%" + textBox9.Text + "%' or [Date Added] like '%" + textBox9.Text + "%' or [Quantity] like '%" + textBox9.Text + "%'";
                OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                DataSet ds = new DataSet();

                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
