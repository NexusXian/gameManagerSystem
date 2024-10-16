using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameMannager
{
    public partial class user3 : Form
    {
        public user3()
        {
            InitializeComponent();
            Table();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select [no],[gid],[datetime] from t_buy where [uid] = '{Data.UID}' ";
            IDataReader dc = dao.ExecuteReader(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要退款的订单！");
                return;
            }

            string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();  // Purchase ID
            string gameId = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();  // Game ID

            // Correct the SQL query
            string sql = $@"
        DELETE FROM t_buy WHERE [no] = '{no}'; 
        UPDATE t_game SET number = number + 1 WHERE id = '{gameId}'";

            Dao dao = new Dao();

            try
            {
                int result = dao.Execute(sql);

                if (result > 0)
                {
                    MessageBox.Show("退款成功");
                    Table();  // Reload the data grid
                }
                else
                {
                    MessageBox.Show("退款失败，请重试！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}");
            }
            finally
            {
                dao.DaoClose();
            }
        }

    }
}
