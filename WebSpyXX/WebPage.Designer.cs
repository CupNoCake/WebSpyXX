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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.extandedWebBrowser1 = new ExtandedUserControl.ExtandedWebBrowser();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 32);
            this.panel1.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.urlTextBox);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(120, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel6.Size = new System.Drawing.Size(422, 32);
            this.panel6.TabIndex = 3;
            // 
            // urlTextBox
            // 
            this.urlTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.urlTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.urlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlTextBox.Location = new System.Drawing.Point(0, 5);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(422, 21);
            this.urlTextBox.TabIndex = 0;
            this.urlTextBox.Enter += new System.EventHandler(this.UrlTextBox_Enter);
            this.urlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlTextBox_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(542, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(151, 32);
            this.panel5.TabIndex = 2;
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
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(693, 404);
            this.panel3.TabIndex = 7;
            // 
            // extandedWebBrowser1
            // 
            this.extandedWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extandedWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.extandedWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.extandedWebBrowser1.Name = "extandedWebBrowser1";
            this.extandedWebBrowser1.ScriptErrorsSuppressed = true;
            this.extandedWebBrowser1.Size = new System.Drawing.Size(693, 404);
            this.extandedWebBrowser1.TabIndex = 2;
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
            // WebPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "WebPage";
            this.Size = new System.Drawing.Size(693, 436);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private ExtandedUserControl.ExtandedWebBrowser extandedWebBrowser1;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button forwardBtn;
    }
}
