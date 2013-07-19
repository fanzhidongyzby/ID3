using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ID3
{
    class DecTree
    {
        private DataTable dt;//数据表
        private Branch br;//数据分支，第一个是树根

        /// <summary>
        /// 根据DataTable的数据构造一个分支对象作为树根
        /// </summary>
        /// <param name="dt"></param>
        public DecTree(DataTable dt)
        {
            this.dt = dt;
            br = null;
            List<DataRow> rs = new List<DataRow>();
            List<DataColumn> cs = new List<DataColumn>();
            int decPos = -1;//决策属性索引
            int rNum = dt.Rows.Count, cNum = dt.Columns.Count;
            for (int i = 0; i < rNum; i++)
            {
                rs.Add(dt.Rows[i]);
            }
            for (int i = 0; i < cNum; i++)
            {
                if (dt.Columns[i].ColumnName.Equals(ID3.decAttrName)
                    && dt.Columns[i].DataType.ToString().Equals("System.String"))//决策属性[必须是串型]
                    decPos = i;
                cs.Add(dt.Columns[i]);
            }
            if (decPos == -1)
                MessageBox.Show("决策属性" + ID3.decAttrName + "[小写]不能是连续的数值类型！");
            else
            {
                br = new Branch(rs, cs, decPos,"","IF");
            }
        }

        /// <summary>
        /// 生成决策树决策树
        /// </summary>
        /// <returns>树根节点</returns>
        public TreeNode genTree()
        {
            if (br != null)
                return br.divide();//继续分支
            else
                return null;
        }

        /// <summary>
        /// 获取节点对应sql字符串
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataTable getBranchData(string path,string tbName)
        {
            string[] nodeNames = path.Split(new char[] { '\\' });
            Branch b = br;
            for (int i = 1; i < nodeNames.Length; i++)
            {
                b = b.nextBranch(nodeNames[i]);
            }
            return b.getData();
        }
    }
}
