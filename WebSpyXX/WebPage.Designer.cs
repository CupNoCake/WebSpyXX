namespace WebSpyXX
{
    partial class WebPage
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.capturePanel = new System.Windows.Forms.Panel();
            this.idLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tagNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_go = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cookieTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.extandedWebBrowser1 = new ExtandedUserControl.ExtandedWebBrowser();
            this.panel_tools = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_js = new System.Windows.Forms.TabPage();
            this.tb_js = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tb_result = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.capturePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_tools.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp_js.SuspendLayout();
            this.SuspendLayout();
            // 
            // capturePanel
            // 
            this.capturePanel.Controls.Add(this.idLabel);
            this.capturePanel.Controls.Add(this.label3);
            this.capturePanel.Controls.Add(this.tagNameLabel);
            this.capturePanel.Controls.Add(this.label1);
            this.capturePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.capturePanel.Location = new System.Drawing.Point(0, 0);
            this.capturePanel.Name = "capturePanel";
            this.capturePanel.Size = new System.Drawing.Size(844, 24);
            this.capturePanel.TabIndex = 8;
            this.capturePanel.Visible = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(173, 6);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(0, 12);
            this.idLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "id:";
            // 
            // tagNameLabel
            // 
            this.tagNameLabel.AutoSize = true;
            this.tagNameLabel.Location = new System.Drawing.Point(62, 6);
            this.tagNameLabel.Name = "tagNameLabel";
            this.tagNameLabel.Size = new System.Drawing.Size(0, 12);
            this.tagNameLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "tagName:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 32);
            this.panel1.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.urlTextBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(120, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel6.Size = new System.Drawing.Size(467, 32);
            this.panel6.TabIndex = 3;
            // 
            // urlTextBox
            // 
            this.urlTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.urlTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTextBox.Location = new System.Drawing.Point(0, 5);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(467, 21);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Enter += new System.EventHandler(this.UrlTextBox_Enter);
            this.urlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlTextBox_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_go);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.cookieTextBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(587, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(257, 32);
            this.panel5.TabIndex = 2;
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(6, 3);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(43, 23);
            this.btn_go.TabIndex = 2;
            this.btn_go.Text = "转到";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cookie";
            // 
            // cookieTextBox
            // 
            this.cookieTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cookieTextBox.Location = new System.Drawing.Point(102, 3);
            this.cookieTextBox.Name = "cookieTextBox";
            this.cookieTextBox.Size = new System.Drawing.Size(150, 21);
            this.cookieTextBox.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.refreshBtn);
            this.panel4.Controls.Add(this.backBtn);
            this.panel4.Controls.Add(this.forwardBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 32);
            this.panel4.TabIndex = 1;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(71, 3);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(39, 23);
            this.refreshBtn.TabIndex = 2;
            this.refreshBtn.Text = "刷新";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(3, 3);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(28, 23);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "←";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.Location = new System.Drawing.Point(37, 3);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(28, 23);
            this.forwardBtn.TabIndex = 0;
            this.forwardBtn.Text = "→";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.ForwardBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.extandedWebBrowser1);
            this.panel3.Controls.Add(this.panel_tools);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(844, 457);
            this.panel3.TabIndex = 10;
            // 
            // extandedWebBrowser1
            // 
            this.extandedWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extandedWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.extandedWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.extandedWebBrowser1.Name = "extandedWebBrowser1";
            this.extandedWebBrowser1.ScriptErrorsSuppressed = true;
            this.extandedWebBrowser1.Size = new System.Drawing.Size(844, 281);
            this.extandedWebBrowser1.TabIndex = 3;
            this.extandedWebBrowser1.StartNavigate += new System.EventHandler<ExtandedUserControl.BrowserExtendedNavigatingEventArgs>(this.ExtandedWebBrowser1_StartNavigate);
            this.extandedWebBrowser1.StartNewWindow += new System.EventHandler<ExtandedUserControl.BrowserExtendedNavigatingEventArgs>(this.ExtandedWebBrowser1_StartNewWindow);
            this.extandedWebBrowser1.StatusTextChange += new System.EventHandler<ExtandedUserControl.StatusTextEventArgs>(this.ExtandedWebBrowser1_StatusTextChange);
            this.extandedWebBrowser1.TitleChange += new System.EventHandler<ExtandedUserControl.TitleEventArgs>(this.ExtandedWebBrowser1_TitleChange);
            this.extandedWebBrowser1.Quit += new System.EventHandler(this.ExtandedWebBrowser1_Quit);
            this.extandedWebBrowser1.DocMouseMove += new System.EventHandler<System.Windows.Forms.HtmlElementEventArgs>(this.ExtandedWebBrowser1_DocMouseMove);
            this.extandedWebBrowser1.DocMouseDown += new System.EventHandler<System.Windows.Forms.HtmlElementEventArgs>(this.ExtandedWebBrowser1_DocMouseDown);
            this.extandedWebBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.ExtandedWebBrowser1_DocumentCompleted);
            this.extandedWebBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.ExtandedWebBrowser1_Navigated);
            // 
            // panel_tools
            // 
            this.panel_tools.Controls.Add(this.tabControl1);
            this.panel_tools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_tools.Location = new System.Drawing.Point(0, 281);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(844, 176);
            this.panel_tools.TabIndex = 0;
            this.panel_tools.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_js);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(844, 176);
            this.tabControl1.TabIndex = 0;
            // 
            // tp_js
            // 
            this.tp_js.Controls.Add(this.tb_js);
            this.tp_js.Controls.Add(this.panel7);
            this.tp_js.Controls.Add(this.tb_result);
            this.tp_js.Location = new System.Drawing.Point(4, 22);
            this.tp_js.Name = "tp_js";
            this.tp_js.Padding = new System.Windows.Forms.Padding(3);
            this.tp_js.Size = new System.Drawing.Size(836, 150);
            this.tp_js.TabIndex = 0;
            this.tp_js.Text = "Console";
            this.tp_js.UseVisualStyleBackColor = true;
            // 
            // tb_js
            // 
            this.tb_js.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_js.Location = new System.Drawing.Point(3, 23);
            this.tb_js.Multiline = true;
            this.tb_js.Name = "tb_js";
            this.tb_js.Size = new System.Drawing.Size(830, 75);
            this.tb_js.TabIndex = 5;
            this.tb_js.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_js_KeyDown);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(830, 20);
            this.panel7.TabIndex = 4;
            // 
            // tb_result
            // 
            this.tb_result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_result.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_result.Location = new System.Drawing.Point(3, 98);
            this.tb_result.Multiline = true;
            this.tb_result.Name = "tb_result";
            this.tb_result.Size = new System.Drawing.Size(830, 49);
            this.tb_result.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WebPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.capturePanel);
            this.Name = "WebPage";
            this.Size = new System.Drawing.Size(844, 513);
            this.capturePanel.ResumeLayout(false);
            this.capturePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel_tools.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tp_js.ResumeLayout(false);
            this.tp_js.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel capturePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label tagNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cookieTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_go;
        private ExtandedUserControl.ExtandedWebBrowser extandedWebBrowser1;
        private System.Windows.Forms.Panel panel_tools;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_js;
        private System.Windows.Forms.TextBox tb_js;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tb_result;
    }
}
