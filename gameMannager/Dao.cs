using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace gameMannager
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = "data source=nexus-win;Initial Catalog = GameDB;Integrated Security = True";//数据库连接字符串
            sc = new SqlConnection(str);//创建数据库对象
            sc.Open();//打开数据库
            return sc;//返回数据库对象 
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)//更新操作
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader ExecuteReader(string sql)//读取操作
        { 
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sc.Close();//关闭数据库连接
        }
    }
}
