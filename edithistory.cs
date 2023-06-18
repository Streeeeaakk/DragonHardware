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
    public partial class edithistory : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "dragon.mdb");

        public edithistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void edithistory_Load(object sender, EventArgs e)
        {
            String sql = "select * from EditItems";

            OleDbDataAdapter adap = new OleDbDataAdapter(sql, con);
            DataSet ds = new DataSet();

            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
