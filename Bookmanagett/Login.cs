using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookmanagett
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public class ACCOUNT
        {
            public string account { get; set; }
            public string password { get; set; }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            name = name.Trim();     // 删除空格
            password = password.Trim();

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "ERR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            if (comboBox1.Text == "阅读者")
            {
                if (name.Equals("tt") && password.Equals("tt"))
                {
                    userv form = new userv();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("账号密码出错！请重新输入！");
                }
            }
            if (comboBox1.Text == "管理员")
            {
                if (name.Equals("admin") && password.Equals("123"))
                {
                    admin form = new admin();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("账号密码出错！请重新输入！");
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
