using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ID3
{
    class Divs
    {
        private List<Div> ds;//所有划分
        private bool isStr;//划分的元素是数值还是串
        private string colIndex;//划分面向列的索引

        public Divs(bool type,string index)
        {
            isStr = type;
            colIndex = index;
            ds = new List<Div>();
        }

        public List<Div> Ds
        {
            get { return ds; }
        }

        /// <summary>
        /// 尝试添加元素到每个划分，失败后创建新的划分
        /// </summary>
        /// <param name="elem">要划分的元素</param>
        public void add(DataRow elem)
        {
            int dsNum=ds.Count;
            int i=0;
            for(;i<dsNum;i++)
            {
                if (ds[i].add(elem))
                    break;
            }
            if (i >= dsNum)//没有对应的等价类
                ds.Add(new Div(elem,colIndex,isStr));
        }

        /// <summary>
        /// 求解划分本身的信息熵，为决策属性服务
        /// </summary>
        /// <param name="allNum">记录个数</param>
        /// <returns>决策信息熵</returns>
        public double getInfoEntropy(double allNum)
        {
            double sum = 0;
            foreach (Div d in ds)
            {
                int size = d.size();
                sum += -size / allNum * Math.Log(size / allNum, 2);
            }
            return sum;
        }

        /// <summary>
        /// 获取条件划分平均的信息熵
        /// </summary>
        /// <param name="allNum">样本总数</param>
        /// <param name="dec">决策划分</param>
        /// <returns>条件信息熵</returns>
        public double getInfoEntropy(double allNum,Divs dec)
        {
            double sum = 0;
            foreach (Div d in ds)
            {
                int size = d.size();
                double rEntr = getRelativeInfoEntropy(d, dec);//获取划分值
                sum += size / allNum * rEntr;//加权平均
            }
            return sum;
        }

        /// <summary>
        /// 计算一个划分对于决策划分的信息熵
        /// </summary>
        /// <param name="d">一个划分</param>
        /// <param name="dec">决策划分</param>
        /// <returns>相对信息熵</returns>
        private double getRelativeInfoEntropy(Div d,Divs dec)
        {
            double sum = 0;
            double size = d.size();//单个划分的个数
            int decNum=dec.ds.Count;//决策划分个数
            for (int i = 0; i < decNum; i++)
            {
                int num=dec.ds[i].interNum(d);
                if (num != 0)//只计算有效数据
                {
                    sum += -num / size * Math.Log(num / size, 2);
                }
            }
            return sum;
        }


        /// <summary>
        /// 打印调试划分信息
        /// </summary>
        /// <returns>信息结果</returns>
        public string printDivs()
        {
            String msg=(colIndex + "[string=" + isStr + "]:");
            foreach (Div d in ds)
                msg+=(d.size() + " ");
            msg += "\n";
            return msg;
        }
    }
}
