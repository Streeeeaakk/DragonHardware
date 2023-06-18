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
    public partial class admin_user : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");
        private static main_login form1 = new main_login();
        private static admin_user form2 = new admin_user();
        private static admin_acc form3 = new admin_acc();
        private static int qty = 0;
        public static string sesID = "";
        
        private static double tanan = 0;
        private object get;

        public admin_user()
        {
            InitializeComponent();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox20.Text = "0";
            deta();
            comboBox1.Text = "All";
            dataGridView2.Rows.Clear();
            button1.Enabled = false;
            dataGridView3.BringToFront();

            sesID = main_login.sesID;

            con.Open();
            String sql = "select * from login_data Where [Login Type] = '" + sesID + "'";
            OleDbCommand com1 = new OleDbCommand(sql, con);
            OleDbDataReader read1 = com1.ExecuteReader(CommandBehavior.Default);

            while (read1.Read())
            {
                textBox19.Text = read1[3].ToString();
            }
            con.Close();
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                var a = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                var b = int.Parse(dataGridView1.Rows[i].Cells[8].Value.ToString());


                if (a <= b)
                {
                    
                    if (a == 0)
                    {
                        MessageBox.Show("Some items are running out of stock!", "Alert");
                        MessageBox.Show("Some items are out of stock!", "Alert");
                        break;
                    }
                    
                }
                

            }
        }
        private void deta()
        {
            String sql = "select [ID],[Category],[Product Name],[UoM],[Original Price],[Selling Price],[Date Added],[Quantity],[Reorder Point] from DragonHardware order by [Quantity] asc";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
           textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
           textBox3.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
           textBox4.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
           textBox5.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
           textBox6.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
           textBox7.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
           textBox8.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
           textBox10.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
           textBox11.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
           textBox12.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
           textBox13.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
           textBox22.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

           groupBox1.Visible = true;
           dataGridView1.Enabled = false;
           textBox14.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qty = int.Parse(textBox7.Text) + 1;
            textBox7.Text = qty.ToString();

       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            qty = int.Parse(textBox7.Text) - 1;
            textBox7.Text = qty.ToString();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            var a = MessageBox.Show("Are you sure you want to log out?", "Confirm", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    var hak = double.Parse(this.dataGridView2.Rows[i].Cells[2].Value.ToString());
                    var ha = double.Parse(this.dataGridView2.Rows[i].Cells[4].Value.ToString());
                    var total = hak + ha;
                    var aa = this.dataGridView2.Rows[i].Cells[1].Value.ToString();

                    textBox7.Text = "" + total;

                    con.Open();
                    string sql = "Update DragonHardware set [Quantity]=" + total + " where [ID] = '" + aa + "'";
                    OleDbCommand com = new OleDbCommand(sql, con);
                    com.ExecuteNonQuery();
                    deta();
                    con.Close();
                }
                dataGridView2.Rows.Clear();
                //dataGridView3.Visible = false;
                textBox21.Text = "";
                main_login ass = new main_login();
                //ass.FormClosed += delegate
                //{
                //    this.Show();
                //    ass = null;
                //};
                this.Hide();

                ass.Show();
                ass.Activate();
            }

        }

        private void has()
        {
             for (int i = 1; i<dataGridView2.Rows.Count; ++i)
                {
                    var hak = double.Parse(this.dataGridView2.Rows[i].Cells[2].Value.ToString());
        var ha = double.Parse(this.dataGridView2.Rows[i].Cells[4].Value.ToString());
        var total = hak + ha;
        var aa = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
        textBox7.Text = "" + total;

                    con.Open();
                    string sql = "Update DragonHardware set [Quantity]=" + total + " where [ID] = '" + aa + "'";
        OleDbCommand com = new OleDbCommand(sql, con);
        com.ExecuteNonQuery();
                    deta();
        con.Close();
                    jaja();
    }
    //dataGridView3.Visible = false;
                this.Hide();
                main_login a = new main_login();
                a.Show();
            //if (dataGridView2.Rows.Count == 0)
            //{
            //    dataGridView2.Rows.Clear();
            //}
            textBox21.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //con.Open();
            //string sql = "Update DragonHardware set [Quantity]='" + textBox7.Text + "' where [ID] = " + textBox8.Text + "";
            //OleDbCommand com = new OleDbCommand(sql, con);
            //com.ExecuteNonQuery();
            //con.Close();
            //deta();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            acc_details a = new acc_details();
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

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var a = int.Parse(textBox16.Text);
                var b = int.Parse(textBox17.Text);
                
                if (b < a)
                {
                    MessageBox.Show("Money is Not Enough");
                }
                else if (textBox21.Text == "")
                {
                    MessageBox.Show("Please enter Customer Name");
                }
                else if (b >= a)
                {
                    button4.Enabled = false;
                    button6.Enabled = false;
                    button5.Enabled = false;
                    button3.Enabled = false;
                    dataGridView1.Enabled = false;
                    groupBox2.Enabled = false;
                    groupBox3.Visible = true;
                    receipt_final();
                }
            }
            catch
            {
                MessageBox.Show("Money is Not Enough");
            }
        }

        private void detaa()
        {
            String sql = "select * from Receipt";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];

            //hak();
        }
        private void receipt_final()
        {

            var haks = this.dataGridView2.Rows[0].Cells[0].Value.ToString();
            var haksz = this.dataGridView2.Rows[0].Cells[2].Value.ToString();
            var hakszxc = this.dataGridView2.Rows[0].Cells[5].Value.ToString();
            var total = int.Parse(hakszxc) * int.Parse(haksz);
                var a = int.Parse(hakszxc);
                var b = a * 0.12;
                var vat = a + b;
                Random rnd = new Random();
                int rndnum = rnd.Next(1, 999);
                int rndnum2 = rnd.Next(1, 999);
                DateTime now = DateTime.Now;
                string s = now.ToString("yyyyMMdd");
                this.dataGridView3.Rows.Clear();
                this.dataGridView3.Rows.Add("Date and Time", now);
                this.dataGridView3.Rows.Add("Receipt Number", s + rndnum + rndnum2);
                this.dataGridView3.Rows.Add("Cashier Name", textBox19.Text);
                this.dataGridView3.Rows.Add("Customer Name", textBox21.Text);
                this.dataGridView3.Rows.Add("=========", "");
                this.dataGridView3.Rows.Add("Product", haks + " x " + haksz + "; ₱" + total);

                for (var i = 1; i < dataGridView2.Rows.Count; ++i)
                {
                    var hak = this.dataGridView2.Rows[i].Cells[0].Value.ToString();
                    var ha = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
                    var h = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
                    var total1 = int.Parse(h) * int.Parse(ha);
                    this.dataGridView3.Rows.Add("", hak + " x " + ha+ "; ₱" + total1);
                }
               this.dataGridView3.Rows.Add("=========", "");
                this.dataGridView3.Rows.Add("VAT", haks+ "; ₱" + b);

                for (var i = 1; i < dataGridView2.Rows.Count; ++i)
                {
                    var hak = this.dataGridView2.Rows[i].Cells[0].Value.ToString();
                    var aa = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
                    var bb = int.Parse(aa) * 0.12;
                    this.dataGridView3.Rows.Add("", hak+ "; ₱" + bb);
                 }
                this.dataGridView3.Rows.Add("=========", "");
    
                this.dataGridView3.Rows.Add("Total Price", "₱" + textBox16.Text);            
                this.dataGridView3.Rows.Add("Money", "₱" + textBox17.Text);
                this.dataGridView3.Rows.Add("Change", "₱" + textBox18.Text);
            
        }
        private void solve()
        {
            if (textBox17.Text == "" || double.Parse(textBox16.Text) > double.Parse(textBox17.Text))
            {
                MessageBox.Show("Money is not enough");
            }
            else
            {
                var a = int.Parse(textBox16.Text);
                var b = int.Parse(textBox17.Text);
                //var c = comboBox2.Text;
                var total1 = b - a;

                
                
               

                MessageBox.Show("Succesfully sold! Sold By: "+textBox19.Text);

                this.Hide();
                //main_login es = new main_login();
                //es.Show();
                //es.Hide();

                admin_user ass = new admin_user();

                ass.Show();
            }
        }



        private void clearf()
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            //textBox18.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            //int row = dataGridView2.CurrentCell.RowIndex;
            //dataGridView2.Rows.RemoveAt(row);
            //groupBox2.Visible = false;

            //textBox15.Text = "";
            //for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            //{
            dataGridView2.Rows.Clear();
            textBox17.Enabled = false;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
            
                textBox14.Enabled = true;
                //textBox15.Enabled = true;
                //button1.Enabled = true;
                button7.Enabled = true;
            if(textBox10.Text == "")
            {
                textBox14.Enabled = false;
                //textBox15.Enabled = false;
                //button1.Enabled = false;
                button7.Enabled = false;
            }
            
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            //var a = int.Parse(textBox14.Text);
            //var c = int.Parse(textBox15.Text);
            //var d = int.Parse(textBox12.Text);

            //var total1 = c - (a * d);
            //textBox16.Text = total1.ToString();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            //var a = int.Parse(textBox14.Text);
            //var d = int.Parse(textBox12.Text);

            //var total1 = -(a * d);
            //textBox16.Text = total1.ToString();
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            var a = textBox3.Text;
            if (a == "Kilogram")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            else if (a == "Piece")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (a == "Meter")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }


            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if(groupBox1.Visible == true){
                if (textBox14.Text == "")
                {
                    MessageBox.Show("Field is Empty");
                }
                else
                {
                    cartcart();
                }
                }
                else{
                    MessageBox.Show("Error");
                }
            
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            var a = textBox3.Text;
            if (a == "Kilogram")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            else if (a == "Piece")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (a == "Meter")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                papa();
            }
        }

       

        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            editItems a = new editItems();
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
            var hak = double.Parse(this.dataGridView2.Rows[i].Cells[2].Value.ToString());
            var ha = double.Parse(this.dataGridView2.Rows[i].Cells[4].Value.ToString());
            var total = hak + ha;
            var aa = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
            
            textBox7.Text = "" + total;

            con.Open();
            string sql = "Update DragonHardware set [Quantity]=" + total + " where [ID] = '" + aa + "'";
            OleDbCommand com = new OleDbCommand(sql, con);
            com.ExecuteNonQuery();
            deta();
            con.Close();
            }
            clearf();
            dataGridView2.Rows.Clear();
            
        }

        private void cart()
        {
                    String sql = "select * from [Cart_Items]";

                    OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
                    DataSet ds = new DataSet();

                    adap.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
            if (textBox14.Text == "")
            {
                MessageBox.Show("Field is Empty");
            }
            else if(double.Parse(textBox14.Text) == 0){
                MessageBox.Show("You cannot buy 0 items! Please try again");
                textBox14.Text = "";
            }
            else
            {
                cartcart();
            }
        }

        private void cartcart()
        {
            var a = double.Parse(textBox14.Text);
            var b = double.Parse(textBox12.Text);
            var c = double.Parse(textBox7.Text);
            
            
            if (textBox14.Text == "")
            {
                MessageBox.Show("Field is Empty");
            }
            else if (textBox7.Text == "0")
            {
                MessageBox.Show("Out of stock!");
                textBox14.Text = "";
            }
            else if (a > c)
            {
                MessageBox.Show("The product you want to buy is not enough");
                textBox14.Text = "";
            }
            

            else
            {
                var total1 = a * b;

                var total = c - a;
                textBox7.Text = "" + total;

                con.Open();
                string sql = "Update DragonHardware set [Quantity] = " + textBox7.Text + " where [ID]='" + textBox8.Text + "'";
                OleDbCommand com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();
                this.dataGridView2.Rows.Add(textBox10.Text, textBox8.Text, textBox14.Text, total1, textBox7.Text, textBox4.Text);
                groupBox1.Visible = false;
                dataGridView1.Enabled = true;
                deta();
                con.Close();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            dataGridView1.Enabled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "0")
            {

            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            groupBox2.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            papa();
            
        }

        private void papa()
        {
            var a = double.Parse(textBox15.Text);
            var b = double.Parse(this.dataGridView2.CurrentRow.Cells[4].Value.ToString());
            var c = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            var d = double.Parse(this.dataGridView2.CurrentRow.Cells[2].Value.ToString());
            
            
            if(a == 0){
                MessageBox.Show("You cannot buy 0 items! Delete it properly");
            }
            else if (b > a)
            {

                if (a < d)
                {
                    this.dataGridView2.CurrentRow.Cells[2].Value = textBox15.Text;
                    var total = d - a;
                    var total1 = b + total;
                    this.dataGridView2.CurrentRow.Cells[4].Value = total1;

                    con.Open();
                    string sql = "Update DragonHardware set [Quantity] = " + textBox7.Text + " where [ID]='" + textBox8.Text + "'";
                    OleDbCommand com = new OleDbCommand(sql, con);
                    com.ExecuteNonQuery();
                    deta();
                    con.Close();

                    groupBox2.Visible = false;
                    textBox15.Text = "";
                }
                else
                {
                    this.dataGridView2.CurrentRow.Cells[2].Value = textBox15.Text;
                    var total = a - d;
                    var total1 = b - total;
                    this.dataGridView2.CurrentRow.Cells[4].Value = total1;

                    con.Open();
                    string sql = "Update DragonHardware set [Quantity] = " + this.dataGridView2.CurrentRow.Cells[4].Value + " where [ID] = '" + this.dataGridView2.CurrentRow.Cells[1].Value.ToString() + "'";
                    OleDbCommand com = new OleDbCommand(sql, con);
                    com.ExecuteNonQuery();
                    deta();
                    con.Close();

                    groupBox2.Visible = false;
                    textBox15.Text = "";
                }
            
            }
            else
            {
                MessageBox.Show("The product you want to buy is not enough");
                textBox15.Text = "";
            }
        }

        private void textBox15_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            var a = textBox3.Text;
            if(a == "Kilogram"){
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            else if (a == "Piece")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (a == "Meter")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }

         
                if (e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if (textBox15.Text == "")
                    {
                        MessageBox.Show("Field is Empty");
                    }
                    else
                    {
                        papa();
                    }
                }
            
            

        }

        private void button10_Click(object sender, EventArgs e)
        {
            jaja();
            
            
        }

        private void jaja()
        {
            var hak = double.Parse(this.dataGridView2.CurrentRow.Cells[2].Value.ToString());
            var ha = double.Parse(this.dataGridView2.CurrentRow.Cells[4].Value.ToString());
            var total = hak + ha;
            var aa = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = "" + total;

            con.Open();
            string sql = "Update DragonHardware set [Quantity]=" + total + " where [ID] = '" + aa + "'";
            OleDbCommand com = new OleDbCommand(sql, con);
            com.ExecuteNonQuery();
            deta();
            con.Close();

            var sum = double.Parse(textBox16.Text);
            var hak1 = double.Parse(this.dataGridView2.CurrentRow.Cells[3].Value.ToString());
            var total1 = sum - hak1;
            textBox16.Text = "" + total1;

            int row = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(row);
            groupBox2.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }


        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
            }
            textBox16.Text = sum.ToString();
            tanan = sum;
            button2.Enabled = true;
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
                if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                solve();
            }

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            //textBox16.Enabled = true;
            textBox17.Enabled = true;
            button1.Enabled = true;
            textBox17.Text = "";
            textBox18.Text= "";
            //button12.Enabled = true;
            textBox20.Text = "";
            textBox21.Enabled = true;
            
        }

        private void asd()
        {
            for(int i = 0; i < dataGridView2.Rows.Count; i++){
               var a = double.Parse(this.dataGridView2.Rows[i].Cells[2].Value.ToString());
               var a1 = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
               var b = double.Parse(textBox7.Text);
               var total = b - a;
               textBox7.Text = total.ToString();
                con.Open();
               string sql = "Update DragonHardware set [Quantity] ="+total+" where [ID]='"+a1+"'";
               OleDbCommand com = new OleDbCommand(sql, con);
               com.ExecuteNonQuery();
               deta();
               con.Close();
            }
            

        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
            
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

            
            if (!string.IsNullOrEmpty(textBox17.Text))
            {
                textBox18.Text = (Convert.ToDouble(textBox17.Text) - Convert.ToDouble(textBox16.Text)).ToString();
                textBox20.Enabled = true;
                button1.Enabled = true;
                textBox21.Enabled = true;

            }
            else
            {
                textBox20.Enabled = false;
                button1.Enabled = false;
            }
            

        }

        private void textBox17_MouseClick(object sender, MouseEventArgs e)
        {
            textBox17.SelectAll();
        }

        private void s(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            //cashier_details a = new cashier_details();
            //a.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text == "Kilogram")
            {
                label11.Text = "Kilogram:";
            }
            else if (textBox13.Text == "Piece")
            {
                label11.Text = "Remaining Item:";
            }
            else if (textBox13.Text == "Meter")
            {
                label11.Text = "Meter:";
            }
            else
            {
                label11.Text = "Remaining Item:";
            }
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {


            //if (!string.IsNullOrEmpty(textBox20.Text))
            //{
            //    textBox18.Text = (Convert.ToDouble(textBox17.Text) - Convert.ToDouble(textBox16.Text)).ToString();
            //}
            
            if (!string.IsNullOrEmpty(textBox20.Text))
            {
                if(textBox20.Text == null)
                {
                    textBox20.Text = "0";
                }
                var c = double.Parse(textBox20.Text);
                var pers = c / 100;
                var q = double.Parse(textBox18.Text);
                var qq = double.Parse(textBox17.Text);
                var qqq = double.Parse(textBox16.Text);

                var tot = qqq * pers;
                
                if (c <= 0 || textBox20.Text == null)
                {
                    textBox18.Text = (Convert.ToDouble(textBox17.Text) - Convert.ToDouble(textBox16.Text)).ToString();
                }
                else if (c >= 101)
                {
                    textBox20.Text = "100";
                }
                else if (c > 0)
                {
                    var totl = qqq - tot;
                    //var total = (Convert.ToDouble(textBox17.Text)) - totl;
                    var total = qq - totl;
                    textBox18.Text = "" + total;
                }
            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            //textBox18.Text = (Convert.ToDouble(textBox17.Text) - Convert.ToDouble(textBox16.Text)).ToString();
            
        }

        private void button12_Click_1(object sender, EventArgs e)
        { 
                
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void button12_Click_2(object sender, EventArgs e)
        {

        }

        private void button12_Click_3(object sender, EventArgs e)
        {
            
        }

        private void button12_Click_4(object sender, EventArgs e)
        {
            //DGVPrinter printer = new DGVPrinter();
            //printer.Title = "Receipt";
            //printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            //printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //printer.PageNumbers = true;
            //printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            //printer.HeaderCellAlignment = StringAlignment.Near;
            //printer.Footer = "Dragon Hardware";
            //printer.FooterSpacing = 15;
            
        }
        public void sellhistory()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; ++i) {
                var prodname = this.dataGridView2.Rows[i].Cells[0].Value.ToString();
                var prodid = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
                var prodquan = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
                var prodprice = this.dataGridView2.Rows[i].Cells[3].Value.ToString();
                var a = int.Parse(this.dataGridView2.Rows[i].Cells[3].Value.ToString());
                var b = int.Parse(this.dataGridView2.Rows[i].Cells[2].Value.ToString());
                var prodsellprice = a * b;
                var cashierName = textBox19.Text;
                var customerName = textBox21.Text;
                DateTime now = DateTime.Now;
                string s = now.ToString("dd/MM/yyyy");
                con.Open();
                string sql = "Insert into PurchaseHistory([Product ID],[Product Name],[Selling Price],[Quantity],[Total Price],[Date Sold],[Customer Name],[Cashier Name])values('" + prodid + "','" + prodname + "'," + prodprice + "," + prodquan + "," +prodsellprice+",'"+s+"','"+customerName+"','"+cashierName+"')";
                OleDbCommand com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button12_Click_5(object sender, EventArgs e)
        {

            var a = MessageBox.Show("PLEASE CONFIRM, pressing cancel during printing can result in DATA LOSS","Confirm", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                sellhistory();
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Dragon Hardware";
                printer.SubTitle = "Sales Invoice of Dragon Hardware";
                printer.TitleAlignment = StringAlignment.Near;
                printer.SubTitleAlignment = StringAlignment.Near;
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                //printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                // printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                //printer.Footer = "Dragon Hardware";
                //printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView3);


                groupBox3.Visible = false;
                clearf();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                button4.Enabled = true;
                button6.Enabled = true;
                button5.Enabled = true;
                button3.Enabled = true;
                dataGridView1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Visible = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //clearf();
            button4.Enabled = true;
            button6.Enabled = true;
            button5.Enabled = true;
            button3.Enabled = true;
            dataGridView1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Visible = false;
        }

        private void qwe()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                var hak = double.Parse(this.dataGridView2.Rows[i].Cells[2].Value.ToString());
                var ha = double.Parse(this.dataGridView2.Rows[i].Cells[4].Value.ToString());
                var total = hak + ha;
                var aa = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
                textBox7.Text = "" + total;

                con.Open();
                string sql = "Update DragonHardware set [Quantity]=" + total + " where [ID] = '" + aa + "'";
                OleDbCommand com = new OleDbCommand(sql, con);
                com.ExecuteNonQuery();
                deta();
                con.Close();
                //jaja();
            }
            dataGridView2.Rows.Clear();
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            qwe();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            purchasehistory a = new purchasehistory();
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
            
            //printer.KeepRowsTogether = true;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
