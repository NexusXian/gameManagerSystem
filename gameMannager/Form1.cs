using System.Data;
using System.Data.SqlClient;
namespace gameMannager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("不能有空的输入，请重新输入");
            }
        }
        //登陆方法
        public void Login()
        {//user
            if (radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_user where id = '{textBox1.Text}' and psw = '{textBox2.Text}'";
                IDataReader dc = dao.ExecuteReader(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    Data.UID = dc["Id"].ToString();
                    Data.Uname = dc["Name"].ToString();
                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();

            }
            //admin
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where id = '{textBox1.Text}' and psw = '{textBox2.Text}'";
                IDataReader dc = dao.ExecuteReader(sql);
                if (dc.Read())
                {

                    MessageBox.Show("登录成功");

                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            signin s = new signin();
            s.ShowDialog();
        }
    }
}
