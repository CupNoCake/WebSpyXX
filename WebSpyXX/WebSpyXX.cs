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
using DevComponents.DotNetBar;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            

            //TabPage tabPage = new TabPage("新标签页");
            //tabPage.Controls.Add(webPage);

            SuperTabControlPanel panel = new SuperTabControlPanel();
            panel.Dock = DockStyle.Fill;
            panel.Controls.Add(webPage);

            superTabControl1.Controls.Add(panel);

            SuperTabItem tabItem = new SuperTabItem();
            tabItem.AttachedControl = panel;
            tabItem.Text = "新标签页";
            
            panel.TabItem = tabItem;

            //tabControl1.Tabs.Add(tabItem);


            if (superTabControl1.Tabs.Count > 0)
            {
                superTabControl1.Tabs.Insert(superTabControl1.SelectedTabIndex + 1, tabItem);
            }
            else
            {
                superTabControl1.Tabs.Add(tabItem);
            }

            if (superTabControl1.SelectedTab != tabItem)
                superTabControl1.SelectedTab = tabItem;

            webPage.Navigate(url);
        }

        private void ClosePage(int index)
        {
            if(index >= 0 && index < superTabControl1.Tabs.Count)
            {
                if (superTabControl1.Tabs.Count > 1)
                {
                    ((superTabControl1.Tabs[index] as SuperTabItem).AttachedControl.Controls[0] as WebPage).Close();
                    superTabControl1.Tabs.RemoveAt(index);

                    if (index == superTabControl1.Tabs.Count)
                    {
                        superTabControl1.SelectedTabIndex = superTabControl1.Tabs.Count - 1;
                    }
                    else
                    {
                        superTabControl1.SelectedTabIndex = index;
                    }
                }
                else
                    Close();
            }
            
        }

        //private void ClosePage(TabItem tabItem)
        //{
        //    if (index >= 0 && index < tabControl1.Tabs.Count)
        //    {
        //        if (tabControl1.Tabs.Count > 1)
        //        {
        //            (tabControl1.Tabs[index].AttachedControl.Controls[0] as WebPage).Close();
        //            tabControl1.Tabs.RemoveAt(index);

        //            if (index == tabControl1.Tabs.Count)
        //            {
        //                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
        //            }
        //            else
        //            {
        //                tabControl1.SelectedTabIndex = index;
        //            }
        //        }
        //        else
        //            Close();
        //    }

        //}

        private void SetCapture(int index)
        {
            if (index >= 0 && index < superTabControl1.Tabs.Count)
            {
                ((superTabControl1.Tabs[index] as SuperTabItem).AttachedControl.Controls[0] as WebPage).SetCapture();
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
            foreach (SuperTabItem tabItem in superTabControl1.Tabs)
            {
                (tabItem.AttachedControl.Controls[0] as WebPage).Close();
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
            SuperTabControlPanel panel = (sender as Control).Parent as SuperTabControlPanel;
            panel.TabItem.Text = e.Title;
        }

        private void WebPage_PageClose(object sender, EventArgs e)
        {
            for (int index = 0; index < superTabControl1.Tabs.Count; index++)
            {
                if (sender == (superTabControl1.Tabs[index] as SuperTabItem).AttachedControl.Controls[0])
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
            ClosePage(superTabControl1.SelectedTabIndex);
        }

        private void Tsmi_capture_Click(object sender, EventArgs e)
        {
            SetCapture(superTabControl1.SelectedTabIndex);
        }

        #endregion

        private void tsmi_options_Click(object sender, EventArgs e)
        {
            SettingDlg dlg = new SettingDlg();

            dlg.ShowDialog();
        }

        private void superTabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            //ClosePage(superTabControl1.Tabs.IndexOf(e.Tab));

            ((e.Tab as SuperTabItem).AttachedControl.Controls[0] as WebPage).Close();
        }

        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            
        }

        private void superTabControl1_TabRemoved(object sender, SuperTabStripTabRemovedEventArgs e)
        {
            if (superTabControl1.Tabs.Count == 0)
                Close();
        }

        private void tsmi_captureWeb_Click(object sender, EventArgs e)
        {
            if (superTabControl1.Tabs.Count > 0)
                (superTabControl1.SelectedTab.AttachedControl.Controls[0] as WebPage).CaptureWindow();
        }

        private void tsmi_jtot_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "打开";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                Table table = JsonConvert.DeserializeObject<Table>(json);
                Excel excel = new Excel();
                excel.Create();
                excel.CreateSheetByTable(table);
            }
        }

        private void tsmi_loadjs_Click(object sender, EventArgs e)
        {
            int index = superTabControl1.SelectedTabIndex;
            if (index >= 0 && index < superTabControl1.Tabs.Count)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "JavaScript files (*.js)|*.js";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "打开";
                openFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
                if (DialogResult.OK == openFileDialog.ShowDialog())
                {
                    string js = File.ReadAllText(openFileDialog.FileName);

                    ((superTabControl1.Tabs[index] as SuperTabItem).AttachedControl.Controls[0] as WebPage).LoadScript(js);
                    tsmi_ttox.Enabled = true;
                }
                
            }
        }

        private void tsmi_ttox_Click(object sender, EventArgs e)
        {
            int index = superTabControl1.SelectedTabIndex;
            if (index >= 0 && index < superTabControl1.Tabs.Count)
            {
                string json = ((superTabControl1.Tabs[index] as SuperTabItem).AttachedControl.Controls[0] as WebPage).ExcuteScript("yzf_get_table").ToString();

                if(json != null)
                {
                    File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "/table.json", json);
                    Table table = JsonConvert.DeserializeObject<Table>(json);

                    Excel excel = new Excel();
                    excel.Create();
                    excel.CreateSheetByTable(table);
                }
            }
               
        }

        private void tsmi_getCookie_Click(object sender, EventArgs e)
        {
            int index = superTabControl1.SelectedTabIndex;
            if (index >= 0 && index < superTabControl1.Tabs.Count)
            {
                string cookie = ((superTabControl1.Tabs[index] as SuperTabItem).AttachedControl.Controls[0] as WebPage).GetCookie();

                if(cookie.Length > 0)
                {
                    Clipboard.SetText(cookie);
                    MessageBox.Show("cookie已复制到剪切板");
                }
                
            }
        }

        private void tsmi_setCookie_Click(object sender, EventArgs e)
        {
            CookieDlg dlg = new CookieDlg();

            dlg.ShowDialog(this);
        }

        private void tsmi_execjs_Click(object sender, EventArgs e)
        {
            int index = superTabControl1.SelectedTabIndex;
            if (index >= 0 && index < superTabControl1.Tabs.Count)
            {
                ((superTabControl1.Tabs[index] as SuperTabItem).AttachedControl.Controls[0] as WebPage).ShowTools();
            }
        }
    }
}
