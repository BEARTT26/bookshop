using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Bookmanagett
{
    public partial class userv : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Product;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string[] data;
        public int num;
        DataSet dst = new DataSet();
        SqlDataAdapter sda;
        public userv()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“bookshopDataSet.Product”中。您可以根据需要移动或移除它。
            // this.productTableAdapter.Fill(this.bookshopDataSet.Product);
            dataGridView1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string condition = " where ";
            
            if (textBox1.Text != "")
                condition += "Title='" + textBox1.Text + "'" + " and ";
           // if (textBox2.Text != "")
           //     condition += "Author='" + textBox2.Text + "'" + " and ";
        
            condition += "1=1 ";
            string sql = "select p_id as 'p_id',Title as 'Title',Author as 'Author',Publisher as 'Publisher',isbn as 'isbn',Price as 'Price',p_Date as 'p_Date'  from Product" + condition;
            SqlCommand cmd = new SqlCommand(sql, conn);
            sda = new SqlDataAdapter(cmd);
            dst.Tables.Clear();
            sda.Fill(dst, "Product");
            dataGridView1.DataSource = dst.Tables["Product"];
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string condition = " where ";

           // if (textBox1.Text != "")
           //     condition += "Title='" + textBox1.Text + "'" + " and ";
             if (textBox2.Text != "")
                 condition += "Author='" + textBox2.Text + "'" + " and ";

            condition += "1=1 ";
            string sql = "select p_id as 'p_id',Title as 'Title',Author as 'Author',Publisher as 'Publisher',isbn as 'isbn',Price as 'Price',p_Date as 'p_Date'  from Product" + condition;
            SqlCommand cmd = new SqlCommand(sql, conn);
            sda = new SqlDataAdapter(cmd);
            dst.Tables.Clear();
            sda.Fill(dst, "Product");
            dataGridView1.DataSource = dst.Tables["Product"];
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Visible = true;
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }
    }
}
