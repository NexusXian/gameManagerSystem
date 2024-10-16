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
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
        }

        private void 游戏查看和够买ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void user1_Load(object sender, EventArgs e)
        {

        }

        private void 游戏商场ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user2 usr = new user2();
            usr.ShowDialog();
        }

        private void 游戏库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user3 usr = new user3();
            usr.ShowDialog();
        }
    }
}
