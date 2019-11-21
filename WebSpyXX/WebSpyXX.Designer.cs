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
            this.tsmi_loadjs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_options = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_capture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_captureWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.json工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_jtot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ttox = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_getCookie = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_setCookie = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_newPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_closeCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_closeOther = new System.Windows.Forms.ToolStripMenuItem();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.tsmi_execjs = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
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
            this.tsmi_loadjs,
            this.tsmi_options,
            this.tsmi_capture,
            this.tsmi_captureWeb,
            this.json工具ToolStripMenuItem,
            this.tsmi_ttox,
            this.tsmi_getCookie,
            this.tsmi_setCookie,
            this.tsmi_execjs});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // tsmi_loadjs
            // 
            this.tsmi_loadjs.Name = "tsmi_loadjs";
            this.tsmi_loadjs.Size = new System.Drawing.Size(180, 22);
            this.tsmi_loadjs.Text = "加载脚本文件";
            this.tsmi_loadjs.Click += new System.EventHandler(this.tsmi_loadjs_Click);
            // 
            // tsmi_options
            // 
            this.tsmi_options.Name = "tsmi_options";
            this.tsmi_options.Size = new System.Drawing.Size(180, 22);
            this.tsmi_options.Text = "配置";
            this.tsmi_options.Click += new System.EventHandler(this.tsmi_options_Click);
            // 
            // tsmi_capture
            // 
            this.tsmi_capture.Name = "tsmi_capture";
            this.tsmi_capture.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmi_capture.Size = new System.Drawing.Size(180, 22);
            this.tsmi_capture.Text = "抓取";
            this.tsmi_capture.Click += new System.EventHandler(this.Tsmi_capture_Click);
            // 
            // tsmi_captureWeb
            // 
            this.tsmi_captureWeb.Name = "tsmi_captureWeb";
            this.tsmi_captureWeb.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.tsmi_captureWeb.Size = new System.Drawing.Size(180, 22);
            this.tsmi_captureWeb.Text = "截图";
            this.tsmi_captureWeb.Click += new System.EventHandler(this.tsmi_captureWeb_Click);
            // 
            // json工具ToolStripMenuItem
            // 
            this.json工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_jtot});
            this.json工具ToolStripMenuItem.Name = "json工具ToolStripMenuItem";
            this.json工具ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.json工具ToolStripMenuItem.Text = "json工具";
            // 
            // tsmi_jtot
            // 
            this.tsmi_jtot.Name = "tsmi_jtot";
            this.tsmi_jtot.Size = new System.Drawing.Size(127, 22);
            this.tsmi_jtot.Text = "json转xls";
            this.tsmi_jtot.Click += new System.EventHandler(this.tsmi_jtot_Click);
            // 
            // tsmi_ttox
            // 
            this.tsmi_ttox.Enabled = false;
            this.tsmi_ttox.Name = "tsmi_ttox";
            this.tsmi_ttox.Size = new System.Drawing.Size(180, 22);
            this.tsmi_ttox.Text = "提取表单";
            this.tsmi_ttox.Click += new System.EventHandler(this.tsmi_ttox_Click);
            // 
            // tsmi_getCookie
            // 
            this.tsmi_getCookie.Name = "tsmi_getCookie";
            this.tsmi_getCookie.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tsmi_getCookie.Size = new System.Drawing.Size(180, 22);
            this.tsmi_getCookie.Text = "获取cookie";
            this.tsmi_getCookie.Click += new System.EventHandler(this.tsmi_getCookie_Click);
            // 
            // tsmi_setCookie
            // 
            this.tsmi_setCookie.Name = "tsmi_setCookie";
            this.tsmi_setCookie.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.tsmi_setCookie.Size = new System.Drawing.Size(180, 22);
            this.tsmi_setCookie.Text = "设置cookie";
            this.tsmi_setCookie.Click += new System.EventHandler(this.tsmi_setCookie_Click);
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
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite4.Location = new System.Drawing.Point(0, 438);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(764, 0);
            this.dockSite4.TabIndex = 6;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 25);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 391);
            this.dockSite1.TabIndex = 3;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(764, 25);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 391);
            this.dockSite2.TabIndex = 4;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 438);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(764, 0);
            this.dockSite8.TabIndex = 10;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 0);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 438);
            this.dockSite5.TabIndex = 7;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(764, 0);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 438);
            this.dockSite6.TabIndex = 8;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(764, 0);
            this.dockSite7.TabIndex = 9;
            this.dockSite7.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(764, 0);
            this.dockSite3.TabIndex = 5;
            this.dockSite3.TabStop = false;
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            this.superTabControl1.CloseButtonOnTabsVisible = true;
            this.superTabControl1.ContextMenuStrip = this.contextMenuStrip1;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 25);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(764, 391);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 11;
            this.superTabControl1.Text = "superTabControl1";
            this.superTabControl1.TabItemClose += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs>(this.superTabControl1_TabItemClose);
            this.superTabControl1.TabRemoved += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabRemovedEventArgs>(this.superTabControl1_TabRemoved);
            // 
            // tsmi_execjs
            // 
            this.tsmi_execjs.Name = "tsmi_execjs";
            this.tsmi_execjs.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.tsmi_execjs.Size = new System.Drawing.Size(180, 22);
            this.tsmi_execjs.Text = "执行js";
            this.tsmi_execjs.Click += new System.EventHandler(this.tsmi_execjs_Click);
            // 
            // WebSpyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 438);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
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
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_loadjs;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_options;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_newPage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_closeCurrent;
        private System.Windows.Forms.ToolStripMenuItem tsmi_closeOther;
        private System.Windows.Forms.ToolStripMenuItem tsmi_capture;
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_captureWeb;
        private System.Windows.Forms.ToolStripMenuItem json工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_jtot;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ttox;
        private System.Windows.Forms.ToolStripMenuItem tsmi_getCookie;
        private System.Windows.Forms.ToolStripMenuItem tsmi_setCookie;
        private System.Windows.Forms.ToolStripMenuItem tsmi_execjs;
    }
}

