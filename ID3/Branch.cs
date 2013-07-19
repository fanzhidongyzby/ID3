using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ID3
{
    class Branch
    {
        private List<DataRow> rows;//有效数据行
        private List<DataColumn> cols;//有效数据列
        private int decPos;//决策属性索引
        private List<Divs> allDivs;//记录所有属性的划分
        private int testAttrIndex;//记录测试属性索引
        private double infoIncValue;//信息增益最大值
        private List<Branch> nextBranches;//子分支记录
        private string label;//记录产生该分支的数据支路
        private string nodeName;//该分支节点的名称
        private string rule;//规则式



        public Branch(List<DataRow> rs, List<DataColumn> cs, int pos, string lb, string r)
        {
            rows = rs;
            cols = cs;
            decPos = pos;
            allDivs = new List<Divs>();
            testAttrIndex = -1;
            infoIncValue = 0;
            nextBranches = new List<Branch>();
            label = lb;
            rule = r;
        }

        /// <summary>
        /// 按照属性将数据划分
        /// </summary>
        private void divAllAttr()
        {
            int rNum = rows.Count;//记录个数
            int cNum = cols.Count;//属性个数
            for (int j = 0; j < cNum; j++)
            {
                bool isStr = cols[j].DataType.ToString().Equals("System.String");
                Divs divs = new Divs(isStr, cols[j].ColumnName);//新建一个属性的划分，按照列索引有序
                allDivs.Add(divs);
                for (int i = 0; i < rNum; i++)
                {
                    divs.add(rows[i]);
                }
            }
            /*
            String msg = "";
            foreach (Divs ds in allDivs)
                msg += ds.printDivs();
            MessageBox.Show(msg+"dec="+cols[decPos].ColumnName+"\n");
            */
        }

        /// <summary>
        /// 根据最大信息增益原则选择测试属性
        /// </summary>
        /// <returns>是否获得测试属性</returns>
        private bool getTestAttr()
        {
            int cNum = cols.Count;//属性个数
            int rNum = rows.Count;//样本个数
            double decValue = allDivs[decPos].getInfoEntropy(rNum);//决策属性信息熵
            if (decValue == 0)
                return false;
            for (int i = 0; i < cNum; i++)
            {
                if (i == decPos) continue;//跳过决策属性
                double condVal = allDivs[i].getInfoEntropy(rNum, allDivs[decPos]);
                double incVal = decValue - condVal;//信息增益
                if (incVal >= infoIncValue)
                {
                    infoIncValue = incVal;
                    testAttrIndex = i;
                }
            }
            if (testAttrIndex == -1)//不能继续划分【可能是最后一个属性了】
                return false;
            return true;
        }

        /// <summary>
        /// 递归产生下一个树
        /// </summary>
        /// <returns>节点</returns>
        public TreeNode divide()
        {
            divAllAttr();
            TreeNode tvNode;
            if (!getTestAttr())//不能继续划分了,划分完毕或者没有条件属性
            {
                int imgIndex = ID3.skinID*3+1;
                //检测所有决策属性是否相同，是否划分正确
                int num = rows.Count;
                bool flag = true;
                if (num > 1)//不止一个记录，测试
                {
                    string dec = rows[0][cols[decPos].ColumnName].ToString().Trim();
                    for (int i = 1; i < num; i++)
                    {
                        if (!rows[i][cols[decPos].ColumnName].ToString().Trim().Equals(dec))
                            flag = false;//未通过验证
                    }
                }
                if (flag)
                {
                    nodeName = rows[0][cols[decPos].ColumnName].ToString().Trim();
                    rule += " THEN " + ID3.decAttrName + "=" + nodeName;
                }
                else
                {
                    nodeName = "";
                    imgIndex = ID3.skinID * 3 + 2;
                    ID3.errNum += rows.Count;
                    rule += " THEN WRONG";
                }
                if (!label.Equals(""))
                    nodeName += "[" + label + "]";
                nodeName += "(" + rows.Count + ")";
                tvNode = new TreeNode(nodeName, imgIndex, imgIndex);
                if(!rule.Equals("IF"))
                    tvNode.ToolTipText = rule;
                return tvNode;
            }
            //继续构造下一次划分
            List<DataColumn> cs = new List<DataColumn>();
            int cNum = cols.Count;
            for (int i = 0; i < cNum; i++)
            {
                if (i != testAttrIndex)//去除测试属性
                    cs.Add(cols[i]);
            }
            int pos = decPos;//决策属性索引
            if (testAttrIndex < decPos)//删除属性在决策属性之前
                pos = decPos - 1;//测试属性偏移减小
            List<Div> ds = allDivs[testAttrIndex].Ds;
            int dNum = ds.Count;//分类个数
            List<TreeNode> nodeList = new List<TreeNode>();
            string nextRule=rule;
            if(!rule.Equals("IF"))
                nextRule+=" AND";
            for (int i = 0; i < dNum; i++)
            {
                string cond=cols[testAttrIndex].ColumnName + "=" + allDivs[testAttrIndex].Ds[i].Label;//一个分支条件
                Branch br = new Branch(ds[i].Elems, cs, pos,cond, nextRule+" "+cond);//产生分支
                nextBranches.Add(br);//添加分支
                TreeNode node = br.divide();//继续划分
                nodeList.Add(node);
            }
            nodeName = cols[testAttrIndex].ColumnName;
            if (!label.Equals(""))
                nodeName += "[" + label + "]";
            nodeName += "(" + rows.Count + ")";
            int picIndex = ID3.skinID * 3;
            tvNode = new TreeNode(nodeName, picIndex,picIndex, nodeList.ToArray());
            if (!rule.Equals("IF"))
                tvNode.ToolTipText = rule;
            return tvNode;
        }



        /// <summary>
        /// 根据提供的路径名返回指定的分支
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Branch nextBranch(string name)
        {
            for (int i = 0; i < nextBranches.Count; i++)
            {
                if (nextBranches[i].nodeName.Equals(name))
                    return nextBranches[i];
            }
            return null;
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            DataColumn dc;
            for (int i = 0; i < cols.Count; i++)
            {
                dc = new DataColumn(cols[i].ColumnName);
                dt.Columns.Add(dc);
            }
            DataRow dr;
            for (int i = 0; i < rows.Count; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < cols.Count; j++)
                {
                    string colName=cols[j].ColumnName;
                    dr[colName] = Convert.ChangeType(rows[i][colName],cols[j].DataType);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
