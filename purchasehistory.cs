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
    public partial class purchasehistory : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        private static int totalzx = 0;
        //private static int total1 = 0;

        public purchasehistory()
        {
            InitializeComponent();
        }

        private void purchasehistory_Load(object sender, EventArgs e)
        {
            deta();
            //comboBox1.Text = "Select Month";
        }

        private void deta()
        {
            String sql = "select [Product Name],[Cashier Name],[Customer Name],[Selling Price],[Quantity],[Total Price],[Date Sold] from PurchaseHistory";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_user a = new admin_user();
            cashier_user b = new cashier_user();
            a.Enabled = true;
            b.Enabled = true;

            var me = MessageBox.Show("Are you sure you want to go back?", "Confirm", MessageBoxButtons.YesNo);
            if(me == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                a.Enabled = false;
                b.Enabled = false;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Dragon Hardware";
            printer.SubTitle = "Sales Report";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Dragon Hardware";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            //button4.Enabled = false;

            groupBox1.Visible = true;
          
            for(int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                //var total = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                var daynow = this.dataGridView1.Rows[i].Cells[6].Value.ToString();

                var prodname = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                var prodcash = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                var prodcust = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                var prodsell = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                var prodquan = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                var prodtotal = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                var proddate = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                DateTime now = DateTime.Now;
                string s = now.ToString("dd/MM/yyyy");
                if(daynow == s)
                {
                    dataGridView2.Rows.Add(prodname,prodcash,prodcust,prodsell,prodquan,prodtotal,proddate);
                    
                }
                //var total2 = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
                totalzx = totalzx + int.Parse(prodtotal);
                
                

            }
            dataGridView2.Rows.Add("", "", "", "", "Total Sales:", "₱" + totalzx, "");
            //totalzx = 0;
            //total1 = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            //button4.Enabled = true;
            dataGridView2.Rows.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string s = now.ToString("dd/MM/yyyy");
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Dragon Hardware";
            printer.SubTitle = "Today's Sales Report"+s;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Dragon Hardware";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
           // button4.Enabled = false;

           // groupBox2.Visible = true;

            for(int i = 0; i < dataGridView1.Rows.Count; ++i)
            {

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            //button4.Enabled = true;

           // groupBox2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
