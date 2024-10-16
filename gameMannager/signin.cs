using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gameMannager
{
    public partial class signin : Form
    {
        public signin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text.Trim(); // 获取用户ID
                string name = textBox2.Text.Trim(); // 获取用户名
                string sex = comboBox1.SelectedItem.ToString(); // 获取性别
                string psw = textBox3.Text; // 获取密码

                // 基本的输入验证
                if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(psw))
                {
                    MessageBox.Show("用户名、密码和ID不能为空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 检查用户名是否已经存在
                string checkSql = "SELECT COUNT(*) FROM t_user WHERE name = @name";
                Dao dao = new Dao();
                using (SqlCommand cmd = dao.command(checkSql))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("用户名已存在，请选择其他用户名。", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 插入新用户
                string sql = "INSERT INTO t_user (id, name, sex, psw) VALUES (@id, @name, @sex, @psw)";
                using (SqlCommand cmd = dao.command(sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@psw", psw);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("注册成功，请登录。", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("注册失败，请重试。", "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                dao.DaoClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册过程中发生错误：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
