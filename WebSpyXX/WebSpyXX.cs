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
        bool isAppExit;
        public WebSpyForm()
        {
            InitializeComponent();
            isAppExit = false;
            //localCb.SelectedIndex = 1;
            //int ieVersion = GetBrowserVersion();
            //if (IfWindowsSupport())
            //{
            //    SetWebBrowserFeatures(ieVersion < 11 ? ieVersion : 11);
            //}
            //else
            //{
            //    如果不支持IE8 则修改为当前系统的IE版本
            //SetWebBrowserFeatures(ieVersion < 7 ? 7 : ieVersion);
            //}
        }

        

        private void startBtn_Click(object sender, EventArgs e)
        {
            //LoadScript("function sayHello() { alert('hello') }");
            //ExcuteScript("sayHello");
            //Navigate(@"https://etax.fujian.chinatax.gov.cn");
            //Thread.Sleep(3000);
            //webBrowser1.Document.GetElementById("kw").SetAttribute("value", "云账房");
            //webBrowser1.Document.GetElementById("su").InvokeMember("click");
            //object retObj = webBrowser1.Document.InvokeScript("var text = document.getElementById(\"kw\").value;return text;");
            //retObj.ToString();
            //string text = ((IJavaScriptExecutor)selenium).ExecuteScript("var input = document.getElementById(\"kw\").value;return input").ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isAppExit = true;
            //if (extandedWebBrowser1.IsBusy)
            //{
            //    extandedWebBrowser1.Stop();
            //}

        }

        //private void btnCapture_Click(object sender, EventArgs e)
        //{

        //}
        //private void browseBtn_Click(object sender, EventArgs e)
        //{
        //    //string fileName = string.Empty; //文件名
        //    //打开文件
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.DefaultExt = "js";
        //    dlg.Filter = "JavaScript Files|*.js|All Files|*.*";
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //        jsText.Text = dlg.FileName;
        //    //if (fileName == null)
        //    //return;
        //}
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

        private void WebSpyXX_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void webPage1_StatusTextChange(object sender, WebStatusTextEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Text;
        }
    }
}
