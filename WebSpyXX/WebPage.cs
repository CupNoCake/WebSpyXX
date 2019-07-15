using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;

namespace WebSpyXX
{
    public partial class WebPage : UserControl
    {
        bool isRun;
        bool isAppExit;
        public WebPage()
        {
            InitializeComponent();
            isAppExit = false;
            isRun = false;
        }

        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "https://" + address;
            }
            try
            {
                if(isRun)
                {
                    extandedWebBrowser1.Stop();
                    isRun = false;
                }

                extandedWebBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            } 
        }

        private void UpdateAddressText()
        {
            if(extandedWebBrowser1.Url != null)
                urlTextBox.Text = extandedWebBrowser1.Url.ToString();
        }


        #region method
        public void LoadScript(string scriptText)
        {
            //找到head元素
            HtmlElement head = extandedWebBrowser1.Document.GetElementsByTagName("head")[0];
            //创建script标签
            HtmlElement scriptEl = extandedWebBrowser1.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            //给script标签加js内容
            element.text = scriptText;
            //将script标签添加到head标签中
            head.AppendChild(scriptEl);
        }

        public void ExcuteScript(string script)
        {
            extandedWebBrowser1.Document.InvokeScript(script);
        }
        #endregion

        private void extandedWebBrowser1_StatusTextChange(object sender, ExtandedUserControl.StatusTextEventArgs e)
        {
            OnStatusTextChange(new WebStatusTextEventArgs(e.Text));
        }

        private void extandedWebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            UpdateAddressText();
            
            //string s = extandedWebBrowser1.DocumentTitle;
        }

        private void extandedWebBrowser1_StartNewWindow(object sender, ExtandedUserControl.BrowserExtendedNavigatingEventArgs e)
        {
            e.Cancel = true;
            Navigate(e.Url.ToString());
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (isRun)
            {
                extandedWebBrowser1.Stop();
                isRun = false;
            }
            else
            {
                Navigate(extandedWebBrowser1.Url.ToString());
            }
        }

        private void urlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(urlTextBox.Text);
            }
        }

        private void urlTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                (sender as TextBox).SelectAll();
            });
        }

        public event EventHandler<WebStatusTextEventArgs> StatusTextChange;

        protected void OnStatusTextChange(WebStatusTextEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StatusTextChange?.Invoke(this, e);
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            extandedWebBrowser1.GoForward();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            extandedWebBrowser1.GoBack();
        }

        private void extandedWebBrowser1_Quit(object sender, EventArgs e)
        {
            isAppExit = true;
        }


        private void extandedWebBrowser1_StartNavigate(object sender, ExtandedUserControl.BrowserExtendedNavigatingEventArgs e)
        {
            if (!isRun)
            {
                isRun = true;
                refreshBtn.Text = "停止";

                BeginInvoke((Action)delegate
                {
                    WaitWebResult();
                });
            }
        }

        private void WaitWebResult()
        {
            // 等待网页加载完成

            do
            {
                Application.DoEvents();

                if (isAppExit)
                    return;
            }
            while (extandedWebBrowser1.ReadyState != WebBrowserReadyState.Complete && isRun);

            isRun = false;
            refreshBtn.Text = "刷新";
        }
    }
}
