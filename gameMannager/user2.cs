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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
            Table();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(user2));
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(32, 30);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(795, 877);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "游戏ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "游戏名称";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "原案";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "开发商";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "游戏库存";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            // 
            // button1
            // 
            button1.Location = new Point(1034, 484);
            button1.Name = "button1";
            button1.Size = new Size(196, 72);
            button1.TabIndex = 2;
            button1.Text = "购买";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // user2
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1466, 971);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "user2";
            Text = "游戏商城";
            Load += user2_Load;
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button button1;
        private DataGridViewTextBoxColumn Column5;

        private void user2_Load(object sender, EventArgs e)
        {

        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from t_game";
            IDataReader dc = dao.ExecuteReader(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); // 获取游戏ID
            int stock = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()); // 获取当前库存

            if (stock < 1)
            {
                MessageBox.Show("库存不足，请联系管理员添加");
                return; // 如果库存不足，则直接返回
            }

            Dao dao = new Dao();

            // 插入购买记录到 t_buy 表
            string insertSql = $"INSERT INTO t_buy([uid], [gid], [datetime]) VALUES('{Data.UID}', '{id}', GETDATE());";

            // 更新 t_game 表中的库存数量
            string updateSql = $"UPDATE t_game SET number = number - 1 WHERE id = '{id}';";

            // 执行 SQL 语句
            int result1 = dao.Execute(insertSql);
            int result2 = dao.Execute(updateSql);

            if (result1 > 0 && result2 > 0)
            {
                MessageBox.Show($"用户 {Data.Uname} 成功购买了游戏 {id}");
                Table(); // 刷新表格以显示最新库存
            }
            else
            {
                MessageBox.Show("购买失败，请重试");
            }

            dao.DaoClose(); // 关闭数据库连接
        }

    }
}
