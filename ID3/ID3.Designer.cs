namespace ID3
{
    partial class ID3
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ID3));
            this.tvTree = new System.Windows.Forms.TreeView();
            this.imglTree = new System.Windows.Forms.ImageList(this.components);
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cbDataBase = new System.Windows.Forms.ComboBox();
            this.lbDbName = new System.Windows.Forms.Label();
            this.lbTbName = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.spConView = new System.Windows.Forms.SplitContainer();
            this.trbarFloat = new System.Windows.Forms.TrackBar();
            this.lbFloat = new System.Windows.Forms.Label();
            this.lbValue = new System.Windows.Forms.Label();
            this.lbStastic = new System.Windows.Forms.Label();
            this.lbSkin = new System.Windows.Forms.LinkLabel();
            this.lbHelp = new System.Windows.Forms.LinkLabel();
            this.lbRule = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spConView)).BeginInit();
            this.spConView.Panel1.SuspendLayout();
            this.spConView.Panel2.SuspendLayout();
            this.spConView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbarFloat)).BeginInit();
            this.SuspendLayout();
            // 
            // tvTree
            // 
            this.tvTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvTree.BackColor = System.Drawing.Color.White;
            this.tvTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvTree.FullRowSelect = true;
            this.tvTree.HideSelection = false;
            this.tvTree.ImageIndex = 0;
            this.tvTree.ImageList = this.imglTree;
            this.tvTree.Indent = 25;
            this.tvTree.ItemHeight = 30;
            this.tvTree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tvTree.Location = new System.Drawing.Point(3, 3);
            this.tvTree.Name = "tvTree";
            this.tvTree.SelectedImageIndex = 0;
            this.tvTree.ShowNodeToolTips = true;
            this.tvTree.ShowPlusMinus = false;
            this.tvTree.ShowRootLines = false;
            this.tvTree.Size = new System.Drawing.Size(237, 574);
            this.tvTree.TabIndex = 0;
            this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            this.tvTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTree_MouseDown);
            // 
            // imglTree
            // 
            this.imglTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglTree.ImageStream")));
            this.imglTree.TransparentColor = System.Drawing.Color.White;
            this.imglTree.Images.SetKeyName(0, "3130.ico");
            this.imglTree.Images.SetKeyName(1, "7141.ico");
            this.imglTree.Images.SetKeyName(2, "7139.ico");
            this.imglTree.Images.SetKeyName(3, "32.ico");
            this.imglTree.Images.SetKeyName(4, "33.ico");
            this.imglTree.Images.SetKeyName(5, "37 (2).ico");
            this.imglTree.Images.SetKeyName(6, "37.ico");
            this.imglTree.Images.SetKeyName(7, "312.ico");
            this.imglTree.Images.SetKeyName(8, "36.ico");
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(684, 574);
            this.dgvData.TabIndex = 1;
            // 
            // cbDataBase
            // 
            this.cbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataBase.FormattingEnabled = true;
            this.cbDataBase.Location = new System.Drawing.Point(95, 5);
            this.cbDataBase.Name = "cbDataBase";
            this.cbDataBase.Size = new System.Drawing.Size(93, 20);
            this.cbDataBase.TabIndex = 2;
            this.cbDataBase.SelectedIndexChanged += new System.EventHandler(this.cbDataBase_SelectedIndexChanged);
            // 
            // lbDbName
            // 
            this.lbDbName.AutoSize = true;
            this.lbDbName.Location = new System.Drawing.Point(12, 9);
            this.lbDbName.Name = "lbDbName";
            this.lbDbName.Size = new System.Drawing.Size(77, 12);
            this.lbDbName.TabIndex = 3;
            this.lbDbName.Text = "选择数据源：";
            // 
            // lbTbName
            // 
            this.lbTbName.AutoSize = true;
            this.lbTbName.Location = new System.Drawing.Point(194, 9);
            this.lbTbName.Name = "lbTbName";
            this.lbTbName.Size = new System.Drawing.Size(77, 12);
            this.lbTbName.TabIndex = 3;
            this.lbTbName.Text = "选择数据表：";
            // 
            // cbTable
            // 
            this.cbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(277, 5);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(102, 20);
            this.cbTable.TabIndex = 4;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // spConView
            // 
            this.spConView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spConView.BackColor = System.Drawing.Color.White;
            this.spConView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spConView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spConView.Location = new System.Drawing.Point(14, 31);
            this.spConView.Margin = new System.Windows.Forms.Padding(0);
            this.spConView.Name = "spConView";
            // 
            // spConView.Panel1
            // 
            this.spConView.Panel1.Controls.Add(this.tvTree);
            // 
            // spConView.Panel2
            // 
            this.spConView.Panel2.Controls.Add(this.dgvData);
            this.spConView.Size = new System.Drawing.Size(939, 584);
            this.spConView.SplitterDistance = 247;
            this.spConView.SplitterWidth = 1;
            this.spConView.TabIndex = 5;
            // 
            // trbarFloat
            // 
            this.trbarFloat.AutoSize = false;
            this.trbarFloat.Location = new System.Drawing.Point(459, 4);
            this.trbarFloat.Maximum = 100;
            this.trbarFloat.Name = "trbarFloat";
            this.trbarFloat.Size = new System.Drawing.Size(175, 20);
            this.trbarFloat.TabIndex = 6;
            this.trbarFloat.Scroll += new System.EventHandler(this.trbarFloat_Scroll);
            // 
            // lbFloat
            // 
            this.lbFloat.AutoSize = true;
            this.lbFloat.Location = new System.Drawing.Point(399, 9);
            this.lbFloat.Name = "lbFloat";
            this.lbFloat.Size = new System.Drawing.Size(65, 12);
            this.lbFloat.TabIndex = 7;
            this.lbFloat.Text = "误差精度：";
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Location = new System.Drawing.Point(635, 9);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(11, 12);
            this.lbValue.TabIndex = 8;
            this.lbValue.Text = "%";
            // 
            // lbStastic
            // 
            this.lbStastic.AutoSize = true;
            this.lbStastic.Location = new System.Drawing.Point(664, 9);
            this.lbStastic.Name = "lbStastic";
            this.lbStastic.Size = new System.Drawing.Size(59, 12);
            this.lbStastic.TabIndex = 3;
            this.lbStastic.Text = "错误率=0%";
            // 
            // lbSkin
            // 
            this.lbSkin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSkin.AutoSize = true;
            this.lbSkin.Location = new System.Drawing.Point(852, 8);
            this.lbSkin.Name = "lbSkin";
            this.lbSkin.Size = new System.Drawing.Size(53, 12);
            this.lbSkin.TabIndex = 9;
            this.lbSkin.TabStop = true;
            this.lbSkin.Text = "更换皮肤";
            this.lbSkin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbSkin_LinkClicked);
            // 
            // lbHelp
            // 
            this.lbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHelp.AutoSize = true;
            this.lbHelp.Location = new System.Drawing.Point(922, 8);
            this.lbHelp.Name = "lbHelp";
            this.lbHelp.Size = new System.Drawing.Size(29, 12);
            this.lbHelp.TabIndex = 10;
            this.lbHelp.TabStop = true;
            this.lbHelp.Text = "帮助";
            this.lbHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbHelp_LinkClicked);
            // 
            // lbRule
            // 
            this.lbRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRule.AutoSize = true;
            this.lbRule.Location = new System.Drawing.Point(780, 8);
            this.lbRule.Name = "lbRule";
            this.lbRule.Size = new System.Drawing.Size(53, 12);
            this.lbRule.TabIndex = 11;
            this.lbRule.TabStop = true;
            this.lbRule.Text = "查看规则";
            this.lbRule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbRule_LinkClicked);
            // 
            // ID3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 627);
            this.Controls.Add(this.lbRule);
            this.Controls.Add(this.lbHelp);
            this.Controls.Add(this.lbSkin);
            this.Controls.Add(this.lbValue);
            this.Controls.Add(this.lbFloat);
            this.Controls.Add(this.trbarFloat);
            this.Controls.Add(this.spConView);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.lbStastic);
            this.Controls.Add(this.lbTbName);
            this.Controls.Add(this.lbDbName);
            this.Controls.Add(this.cbDataBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ID3";
            this.Text = "ID3(by Florian)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ID3_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ID3_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.spConView.Panel1.ResumeLayout(false);
            this.spConView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spConView)).EndInit();
            this.spConView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trbarFloat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvTree;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cbDataBase;
        private System.Windows.Forms.Label lbDbName;
        private System.Windows.Forms.Label lbTbName;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.SplitContainer spConView;
        private System.Windows.Forms.ImageList imglTree;
        private System.Windows.Forms.TrackBar trbarFloat;
        private System.Windows.Forms.Label lbFloat;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.Label lbStastic;
        private System.Windows.Forms.LinkLabel lbSkin;
        private System.Windows.Forms.LinkLabel lbHelp;
        private System.Windows.Forms.LinkLabel lbRule;
    }
}

