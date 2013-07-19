using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace ID3
{
    public partial class ID3 : Form
    {
        public ID3()
        {
            InitializeComponent();
        }

        public static string dataDir = "AppData";//数据目录
        public static string decAttrName = "category";//决策属性名称
        public static double floatValue = 0.1;//是否启用浮点值离散化指数
        public static int errNum = 0;//分类错误个数
        public static int skinID = 0;//皮肤索引
        private int skinNum = 3;//皮肤个数
        private DecTree dtr;//记录决策树对象
        private DataTable dt;//记录所选数据

        /// <summary>
        /// 扫描数据源，初始化视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ID3_Load(object sender, EventArgs e)
        {
            trbarFloat.Value = (int)(floatValue * trbarFloat.Maximum);
            lbValue.Text = floatValue * 100 + "%";
            lbStastic.Text = "";
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + ".\\" + dataDir);
            foreach (string file in files)
            {
                if (file.EndsWith(".mdf"))
                    cbDataBase.Items.Add(file.Substring(file.LastIndexOf("\\") + 1));
            }
            if (cbDataBase.Items.Count == 0)//没有合法的文件
            {
                MessageBox.Show("没有数据文件，请在" + dataDir + "目录下存放数据库文件！");
                Close();
            }
            else
            {
                cbDataBase.SelectedIndex = 0;//默认选择第一个文件
            }
        }

        /// <summary>
        /// 数据源变化，更新试图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB(cbDataBase.Text);
            cbTable.DataSource = db.getTbNames();
            if (cbTable.Items.Count == 0)//没有表名
                cbTable.Text = "";
            else
            {
                cbTable.SelectedIndex = 0;//选择第一个表
            }
        }

        /// <summary>
        /// 表名变化，更新视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = new DB(cbDataBase.Text);
            dt = db.getDataTable(cbTable.Text);
            initView(dt);
        }

        /// <summary>
        /// 保证选择的树节点可见,刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.EnsureVisible();
            DataTable data = dtr.getBranchData(tvTree.SelectedNode.FullPath, cbTable.Text);//根据节点路径和表名产生查询字符串
            dgvData.DataSource = null;//刷线旧的列信息，防止gridview列自动排序
            dgvData.DataSource = data;// new DB(cbDataBase.Text).getData(sqlStr);//用查询字符串的查询数据显示
        }

        /// <summary>
        /// 根据数据源和数据表更新视图、决策树
        /// </summary>
        /// <param name="dt"></param>
        private void initView(DataTable dt)
        {
            if (dt == null)
            {
                lbStastic.Text = "";
                return;
            }
            errNum = 0;//清除上次数据
            dgvData.DataSource = dt;//表格数据刷新
            //更新决策树
            tvTree.Nodes.Clear();//清空原本数据
            dtr = new DecTree(dt);
            TreeNode node = dtr.genTree();
            if (node != null)
                tvTree.Nodes.Add(node);
            tvTree.ExpandAll();
            //更新其他信息
            lbValue.Text = floatValue * 100 + "%";
            int allNum = dt.Rows.Count;
            Double val = errNum * 100 / (double)allNum;
            lbStastic.Text = "错误率=" + val.ToString("0.00") + "%(" + errNum + "/" + allNum + ")";
        }

        /// <summary>
        /// 恢复右键操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = tvTree.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    if (tvTree.SelectedNode == node)
                        return;
                    tvTree.SelectedNode = node;
                }
            }
        }

        /// <summary>
        /// 调节精度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trbarFloat_Scroll(object sender, EventArgs e)
        {
            floatValue = trbarFloat.Value / 1.0 / trbarFloat.Maximum;
            initView(dt);
        }

        /// <summary>
        /// 更换皮肤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbSkin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            skinID = (++skinID) % skinNum;//更换皮肤
            initView(dt);
        }

        private void help()
        {
            string text =
@"ID3算法操作步骤：
1.将需要处理的数据库文件.mdf拖放至程序目录AppData文件夹下。
2.打开主程序，程序会自动选择数据源和数据表，也可以手动选择数据，决策树由程序自动计算。
3.用户创建的数据表必须包含名为category（小写）的列，且必须是非数值类型（字符串）。
4.程序运行在.Net Framework环境下，请确保安装了.Net。
5.生成决策树中，叶子节点显示分类后的结果，非叶子节点显示子节点分类依据的测试属性名。
6.中括号中显示产生该分类的测试属性的取值，小括号内和提示信息显示该分类中样本个数。
7.点击节点显示该分类下所有的数据对应的行和列。
8.单击表格列头进行排序，方便查看分类结果。
9.针对含有数值类型的条件属性，可以通过调节相对误差精度来调节决策树的生成。
10.错误率表示在所有条件属性用尽的时候仍不能分类的样本个数及比例。
11.查看规则可以在浏览器打开查看规则。
12.更换皮肤可以更换决策树节点的图像，方便观察决策树结构。
13.点击帮助（F1键）显示当前信息。[Provider:Florian@UPC]";
            MessageBox.Show(text);
        }

        /// <summary>
        /// 显示帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            help();
        }

        /// <summary>
        /// 键盘信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ID3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                help();
            }
        }

        private static int index = 0;//规则序号
        private void lbRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tvTree.Nodes.Count == 0)
                return;
            string filePath = "./" + dataDir + "/" +
                cbDataBase.Text.Substring(0, cbDataBase.Text.IndexOf("."))
                + "_" + cbTable.Text + "_rules.html";
            File.WriteAllText(filePath, "");
            File.AppendAllText(filePath, "<html><title>Rules</title></head>"+
                "<body style='font-family:Courier New;'><h1>Rules</h1><hr>");
            index=0;//初始化
            writeRules(filePath, tvTree.Nodes);
            File.AppendAllText(filePath, "</body></html>");
            runCmd("\""+webBrowserFilePath()+"\" "+Path.GetFullPath(filePath));
        }

        /// <summary>
        /// 将规则输出到文件
        /// </summary>
        /// <param name="path">自动生成的文件路径</param>
        /// <param name="nodes">树节点</param>
        private void writeRules(string path, TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Nodes.Count == 0)//叶子
                {
                    index++;
                    File.AppendAllText(path, str2Html(nodes[i].ToolTipText));
                }
                else
                    writeRules(path, nodes[i].Nodes);
            }
        }

        private string str2Html(string str)
        {
            string html = "<font color='blue'><b>IF</b></font>";
            str = str.Substring(2);//去除IF
            string conds = str.Substring(0, str.IndexOf("THEN")).Trim();//去除THEN
            string rslt = str.Substring(str.IndexOf("THEN") + 4).Trim();
            int pos=0;//记录AND出现位置
            while (pos != -1)//有AND
            {
                pos = conds.IndexOf("AND");
                string item = "";
                if (pos == -1)//最后一项
                    item = conds.Trim();
                else
                {
                    item = conds.Substring(0, pos).Trim();//一个条件项
                    conds = conds.Substring(pos + 3);
                }
                html += "&nbsp;<font color='green'>"+item.Substring(0,item.IndexOf("=")).Trim()+"</font>"
                    + "=" + item.Substring(item.LastIndexOf("=")+1).Trim()+
                    "&nbsp;";
                if (pos != -1)
                    html += "<font color='blue'><b>AND</b></font>";
            }
            html += "<font color='blue'><b>THEN</b></font>&nbsp;";
            if (rslt.Equals("WRONG"))
                html += "<font color='red'><b>WRONG</b></font>";
            else
                html += "<font color='orange'>category</font>" + "="+rslt.Substring(rslt.IndexOf("=")+1);
            return "("+index+")"+html+"<br><br>";
        }

        /// <summary>
        /// 运行一个DOS命令
        /// </summary>
        /// <param name="cmd">目录</param>
        private void runCmd(string cmd)
        {
            Process process = new Process();//实例 
            process.StartInfo.CreateNoWindow = true;//设定不显示窗口 
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "cmd.exe"; //设定程序名   
            process.StartInfo.RedirectStandardInput = true;   //重定向标准输入 
            process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出 
            process.StartInfo.RedirectStandardError = true;//重定向错误输出 
            process.Start();
            process.StandardInput.WriteLine(cmd);//执行的命令
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            process.Close();
        }
        
        /// <summary>
        /// 获取浏览器路径
        /// </summary>
        /// <param name="defaultBrowser">默认浏览器，否则为IE</param>
        /// <returns>浏览器路径</returns>
        string webBrowserFilePath(bool defaultBrowser=true)
        {
            if (defaultBrowser)
            {
                RegistryKey key = Registry.ClassesRoot.OpenSubKey("http\\shell\\open\\command", false);
                String path = key.GetValue("").ToString();
                if (path.Contains("\""))
                {
                    path = path.TrimStart('"');
                    path = path.Substring(0, path.IndexOf('"'));
                }
                key.Close();
                return path;
            }
            else
            {
                return System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), 
                    "Internet Explorer\\iexplore.exe");
            }
        }


    }
}
