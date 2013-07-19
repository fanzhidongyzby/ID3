using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ID3
{
    class Div
    {
        private bool isStr;//数据类型
        private string label;//划分标签
        private List<DataRow> elems;//划分中的数据
        private string colIndex;//划分面向列的索引

        public Div(DataRow elem, string index, bool type)
        {
            isStr = type;
            colIndex = index;
            label = elem[colIndex].ToString().Trim();
            elems = new List<DataRow>();
            elems.Add(elem);
        }

        public string Label
        {
            get { return label; }
        }
        public List<DataRow> Elems
        {
            get { return elems; }
        }

        /// <summary>
        /// 先验证标签，再添加元素
        /// </summary>
        /// <param name="elem">测试元素</param>
        /// <returns>是否添加成功</returns>
        public bool add(DataRow elem)
        {
            string val = elem[colIndex].ToString().Trim();
            bool acc = false;//是否接受
            if (isStr)//串类型
            {
                acc = val.Equals(label);
            }
            else
            {
                double curVal = Convert.ToDouble(val), lbVal = Convert.ToDouble(label);
                acc = (Math.Abs(curVal - lbVal) / lbVal <= ID3.floatValue);//误差允许
            }
            if (acc)
                elems.Add(elem);
            return acc;
        }

        /// <summary>
        /// 求解划分相对于当前划分的交集个数，为决策划分服务
        /// </summary>
        /// <param name="d">给定的划分</param>
        /// <returns>和决策划分的交集个数</returns>
        public int interNum(Div d)
        {
            int sum = 0;
            int size = d.size();
            for (int i = 0; i < size; i++)
            {
                if (d.elems[i][colIndex].ToString().Trim().Equals(label))//匹配当前标签
                    sum++;
            }
            return sum;
        }

        /// <summary>
        /// 返回划分元素的个数
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            return elems.Count;
        }
    }
}
