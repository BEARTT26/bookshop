using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Bookmanagett
{
    public partial class admin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Product;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public string[] data;
        public int num;
        DataSet dst = new DataSet();
        SqlDataAdapter sda;

        public admin()
        {
            InitializeComponent();
           
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button6.Hide();
            
        }
//获取数据填充表格
        void fillGridView()
        {
            
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

     
//添加
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "")
            {
                try
                {
                    String query = "insert into Product ([Title],[Author], [Publisher], [isbn], [Price], [p_Date]) values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "', '" + textBox3.Text.Trim() + "', '" + textBox4.Text.Trim() + "', '" + textBox5.Text.Trim() + "', '" + dateTimePicker1.Text.Trim() + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("书本添加成功！");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Details Exists", ex.Message);
                }
            }
            else
            {
                MessageBox.Show("请填满表格");
            }
        }
//更新
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && dateTimePicker1.Text != "")
            {
                try
                {
                    String query = "update Product set Title= '" + textBox1.Text.Trim() + "', Author= '" + textBox2.Text.Trim() + "', Publisher= '" + textBox3.Text.Trim() + "', isbn= '" + textBox4.Text.Trim() + "', Price= '" + textBox5.Text.Trim() + "', p_Date= '" + dateTimePicker1.Text + "'where p_id='" + textBox6.Text.Trim() + "' ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("书籍更新成功");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    fillGridView();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Details Exists", ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("请填满表格");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            



        }

//显示
        private void button4_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Visible = true;
            fillGridView();
            button4.Hide();
            button6.Show();
        }
//隐藏
        private void button6_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Visible = false;
            button6.Hide();
            button4.Show();
        }

     

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
//查询
        private void button7_Click(object sender, EventArgs e)
        {
            string condition = " where ";
            if (textBox6.Text != "")
                condition += "p_id='" + textBox6.Text + "'" + " and "; ;
            if (textBox1.Text != "")
                condition += "Title='" + textBox1.Text + "'" + " and ";
            if (textBox2.Text != "")
                condition += "Author='" + textBox2.Text + "'" + " and ";
            if (textBox3.Text != "")
                condition += "Publisher='" + textBox3.Text + "'" + " and ";
            condition += "1=1 ";
            string sql = "select p_id as 'p_id',Title as 'Title',Author as 'Author',Publisher as 'Publisher',isbn as 'isbn',Price as 'Price',p_Date as 'p_Date'  from Product" + condition;
            SqlCommand cmd = new SqlCommand(sql, conn);
            sda = new SqlDataAdapter(cmd);
            dst.Tables.Clear();
            sda.Fill(dst, "Product");
            dataGridView1.DataSource = dst.Tables["Product"];
            dataGridView1.Columns[6].Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }
    }
}
