using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ID3
{
    class DB
    {
        protected string conStr;//连接字符串
        protected SqlConnection con;//连接对象
        public DB(string dbName)
        {
            conStr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\" + ID3.dataDir + "\\"
                + dbName + ";Integrated Security=True;User Instance=True";
        }
        private void open()
        {
            if (con == null)
            {
                con = new SqlConnection(conStr);
            }

            if (con.State.Equals(System.Data.ConnectionState.Closed))
            {
                con.Open();
            }
        }
        private void close()
        {
            if (con != null && !con.State.Equals(System.Data.ConnectionState.Closed))
                con.Close();
        }

        /// <summary>
        /// 根据字符串查询出一个数据表对象
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getData(string sql)
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.close();
            return dt;
        }

        /// <summary>
        /// 根据表名返回所有表数据
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataTable getDataTable(string tbName)
        {
            DataTable dt;
            try
            {
                dt=getData("select * from " + tbName + " order by " + ID3.decAttrName);
            }
            catch (Exception)
            {
                dt = null;
                MessageBox.Show("数据表" + tbName + "中无名为\"" + ID3.decAttrName + "\"的列作为决策属性，请添加或修改决策属性名称！");
            }
            return dt;
        }

        /// <summary>
        /// 获取数据库中所有的用户数据表名
        /// </summary>
        /// <returns>用户表明列表</returns>
        public List<string> getTbNames()
        {
            List<string> tbNames = new List<string>();
            try
            {
                open();
                SqlCommand sqlcmd = con.CreateCommand();
                sqlcmd.CommandText = ("sp_tables");
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = sqlcmd.ExecuteReader();
                while (dr.Read())
                {
                    if ("TABLE".Equals(dr["table_type"].ToString()))//用户表
                    {
                        tbNames.Add(dr["table_name"].ToString());//添加获得的表名
                    }
                }
                dr.Close();
                close();
                if(tbNames.Count==0)
                    MessageBox.Show("无用户数据信息！");
            }
            catch (Exception)
            {
                MessageBox.Show("无效数据信息！");
            }
            return tbNames;
        }
    }
}
