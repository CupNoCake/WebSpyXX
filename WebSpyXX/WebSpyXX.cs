using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using mshtml;

namespace WebSpyXX
{
    public partial class WebSpyForm : Form
    {
        public WebSpyForm()
        {
            InitializeComponent();
        }

        #region 浏览器设置

        /// <summary>  
        /// 修改注册表信息来兼容当前程序  
        /// </summary>  
        static void SetWebBrowserFeatures(int ieVersion)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            //获取程序及名称  
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //得到浏览器的模式的值  
            uint ieMode = GetEmulationMode(ieVersion);
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
            //设置浏览器对应用程序（appName）以什么模式（ieMode）运行  
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, ieMode, RegistryValueKind.DWord);
            //不晓得设置有什么用  
            Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
                appName, 1, RegistryValueKind.DWord);
        }
        /// <summary>  
        /// 获取浏览器的版本  
        /// </summary>  
        /// <returns></returns>  
        static int GetBrowserVersion()
        {
            int browserVersion = 0;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }
            //如果小于7  
            if (browserVersion < 7)
            {
                throw new ApplicationException("不支持的浏览器版本!");
            }
            return browserVersion;
        }
        /// <summary>  
        /// 通过版本得到浏览器模式的值  
        /// </summary>  
        /// <param name="browserVersion"></param>  
        /// <returns></returns>  
        static uint GetEmulationMode(int browserVersion)
        {
            UInt32 mode = 11000; // Internet Explorer 11
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Internet Explorer 7
                    break;
                case 8:
                    mode = 8000; // Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10.  
                    break;
                case 11:
                    mode = 11000; // Internet Explorer 11  
                    break;
            }
            return mode;
        }

        /// <summary>
        /// 查询系统环境是否支持IE8以上版本
        /// </summary>
        public static bool IfWindowsSupport()
        {
            bool isWin7 = Environment.OSVersion.Version.Major > 6;
            bool isSever2008R2 = Environment.OSVersion.Version.Major == 6
                && Environment.OSVersion.Version.Minor >= 1;

            if (!isWin7 && !isSever2008R2)
            {
                return false;
            }
            else return true;
        }


        #endregion

        #region 页面操作
        private void NewPage(string url)
        {
            WebPage webPage = new WebPage();
            webPage.Dock = DockStyle.Fill;
            webPage.Name = "webPage";
            webPage.NewWindow += WebPage_NewWindow;
            webPage.StatusTextChange += WebPage_StatusTextChange;
            webPage.DocumentTitleChange += WebPage_DocumentTitleChange;
            webPage.PageClose += WebPage_PageClose;
            

            TabPage tabPage = new TabPage("新标签页");
            tabPage.Controls.Add(webPage);
           
            if (tabControl1.TabPages.Count > 0)
            {
                tabControl1.TabPages.Insert(tabControl1.SelectedIndex + 1, tabPage);
            }
            else
            {
                tabControl1.TabPages.Add(tabPage);
            }

            if (tabControl1.SelectedTab != tabPage)
                tabControl1.SelectTab(tabPage);

            webPage.Navigate(url);
        }

        private void ClosePage(int index)
        {
            if(index >= 0 && index < tabControl1.TabPages.Count)
            {
                if (tabControl1.TabPages.Count > 1)
                {
                    (tabControl1.TabPages[index].Controls[0] as WebPage).Close();
                    tabControl1.TabPages.RemoveAt(index);

                    if (index == tabControl1.TabPages.Count)
                    {
                        tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
                    }
                    else
                    {
                        tabControl1.SelectedIndex = index;
                    }
                }
                else
                    Close();
            }
            
        }

        private void SetCapture(int index)
        {
            if (index >= 0 && index < tabControl1.TabPages.Count)
            {
                (tabControl1.TabPages[index].Controls[0] as WebPage).SetCapture();
            }
        }
        #endregion

        #region 窗体事件函数
        private void Form1_Load(object sender, EventArgs e)
        {
            int ieVersion = GetBrowserVersion();
            if (IfWindowsSupport())
            {
                SetWebBrowserFeatures(ieVersion < 11 ? ieVersion : 11);
            }
            else
            {
                // 如果不支持IE8 则修改为当前系统的IE版本
                SetWebBrowserFeatures(ieVersion < 7 ? 7 : ieVersion);
            }

            NewPage(null);
        }

        private void WebSpyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                (tabPage.Controls[0] as WebPage).Close();
            }
        }

        private void WebPage_StatusTextChange(object sender, WebStatusTextEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Text;
        }

        private void WebPage_NewWindow(object sender, NewWindowEventArgs e)
        {
            NewPage(e.Url);
        }

        private void WebPage_DocumentTitleChange(object sender, DocumentTitleEventArgs e)
        {
            TabPage tabPage = (sender as Control).Parent as TabPage;
            tabPage.Text = e.Title;
        }

        private void WebPage_PageClose(object sender, EventArgs e)
        {
            for (int index = 0; index < tabControl1.TabPages.Count; index++)
            {
                if (sender == tabControl1.TabPages[index].Controls[0])
                {
                    ClosePage(index);
                    break;
                }
            }
        }

        private void Tsmi_newPage_Click(object sender, EventArgs e)
        {
            NewPage(null);
        }

        private void Tsmi_closeCurrent_Click(object sender, EventArgs e)
        {
            ClosePage(tabControl1.SelectedIndex);
        }

        private void Tsmi_capture_Click(object sender, EventArgs e)
        {
            SetCapture(tabControl1.SelectedIndex);
        }

        #endregion

        private void tsmi_options_Click(object sender, EventArgs e)
        {
            SettingDlg dlg = new SettingDlg();

            dlg.ShowDialog();
        }
    }
}
