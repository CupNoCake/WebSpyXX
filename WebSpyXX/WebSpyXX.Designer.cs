namespace WebSpyXX
{
    partial class WebSpyForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载脚本文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_options = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_capture = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_newPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_closeCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_closeOther = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 416);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(749, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.工具ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载脚本文件ToolStripMenuItem,
            this.tsmi_options,
            this.tsmi_capture});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 加载脚本文件ToolStripMenuItem
            // 
            this.加载脚本文件ToolStripMenuItem.Name = "加载脚本文件ToolStripMenuItem";
            this.加载脚本文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.加载脚本文件ToolStripMenuItem.Text = "加载脚本文件";
            // 
            // tsmi_options
            // 
            this.tsmi_options.Name = "tsmi_options";
            this.tsmi_options.Size = new System.Drawing.Size(148, 22);
            this.tsmi_options.Text = "配置";
            this.tsmi_options.Click += new System.EventHandler(this.tsmi_options_Click);
            // 
            // tsmi_capture
            // 
            this.tsmi_capture.Name = "tsmi_capture";
            this.tsmi_capture.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmi_capture.Size = new System.Drawing.Size(148, 22);
            this.tsmi_capture.Text = "抓取";
            this.tsmi_capture.Click += new System.EventHandler(this.Tsmi_capture_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_newPage,
            this.tsmi_closeCurrent,
            this.tsmi_closeOther});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
            // 
            // tsmi_newPage
            // 
            this.tsmi_newPage.Name = "tsmi_newPage";
            this.tsmi_newPage.Size = new System.Drawing.Size(160, 22);
            this.tsmi_newPage.Text = "打开新的标签页";
            this.tsmi_newPage.Click += new System.EventHandler(this.Tsmi_newPage_Click);
            // 
            // tsmi_closeCurrent
            // 
            this.tsmi_closeCurrent.Name = "tsmi_closeCurrent";
            this.tsmi_closeCurrent.Size = new System.Drawing.Size(160, 22);
            this.tsmi_closeCurrent.Text = "关闭当前页面";
            this.tsmi_closeCurrent.Click += new System.EventHandler(this.Tsmi_closeCurrent_Click);
            // 
            // tsmi_closeOther
            // 
            this.tsmi_closeOther.Name = "tsmi_closeOther";
            this.tsmi_closeOther.Size = new System.Drawing.Size(160, 22);
            this.tsmi_closeOther.Text = "关闭其他页面";
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 391);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 5;
            // 
            // WebSpyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 438);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WebSpyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WebSpyForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载脚本文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_options;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_newPage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_closeCurrent;
        private System.Windows.Forms.ToolStripMenuItem tsmi_closeOther;
        private System.Windows.Forms.ToolStripMenuItem tsmi_capture;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

