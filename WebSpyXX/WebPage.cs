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
        private bool isCapture;
        private string captureCssText;
        private HtmlElement hCaptureEle;

        public event EventHandler<DocumentTitleEventArgs> DocumentTitleChange;
        public event EventHandler<WebStatusTextEventArgs> StatusTextChange;

        public WebPage()
        {
            InitializeComponent();
            
            isAppExit = false;
            isRun = false;
            isCapture = false;
            captureCssText = null;
            hCaptureEle = null;
            
        }

        #region 私有方法
        private void UpdateAddressText()
        {
            if (extandedWebBrowser1.Url != null)
                urlTextBox.Text = extandedWebBrowser1.Url.ToString();
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
        #endregion

        #region method
        public void Navigate(String address)
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
                if (isRun)
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
        public void Close()
        {
            isAppExit = true;
        }

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

        public void SetCapture()
        {
            if (isCapture)
            {
                if (hCaptureEle != null)
                {
                    IHTMLElement iCaptureEle = (IHTMLElement)hCaptureEle.DomElement;
                    iCaptureEle.style.cssText = captureCssText;
                    //iCaptureEle.style.border = "";
                    hCaptureEle = null;
                }

                tagNameLabel.Text = "";
                idLabel.Text = "";
            }

            isCapture = !isCapture;
            capturePanel.Visible = !capturePanel.Visible;
        }
        #endregion

        #region 窗体事件函数
        //private void 

        private void ExtandedWebBrowser1_StatusTextChange(object sender, ExtandedUserControl.StatusTextEventArgs e)
        {
            OnStatusTextChange(new WebStatusTextEventArgs(e.Text));
        }


        private void ExtandedWebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            UpdateAddressText();
        }

        public event EventHandler<NewWindowEventArgs> NewWindow;

        private void ExtandedWebBrowser1_StartNewWindow(object sender, ExtandedUserControl.BrowserExtendedNavigatingEventArgs e)
        {
            e.Cancel = true;
            //Navigate(e.Url.ToString());
            NewWindow?.Invoke(this, new NewWindowEventArgs(e.Url.ToString()));
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
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

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(urlTextBox.Text);
            }
        }

        private void UrlTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                (sender as TextBox).SelectAll();
            });
        }

        private void ForwardBtn_Click(object sender, EventArgs e)
        {
            extandedWebBrowser1.GoForward();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {

            extandedWebBrowser1.Document.InvokeScript(@"window.external.MyMessageBox('javascript访问C#代码')");
            extandedWebBrowser1.GoBack();
        }

        private void ExtandedWebBrowser1_Quit(object sender, EventArgs e)
        {
            isAppExit = true;
        }


        private void ExtandedWebBrowser1_StartNavigate(object sender, ExtandedUserControl.BrowserExtendedNavigatingEventArgs e)
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

        private void ExtandedWebBrowser1_TitleChange(object sender, ExtandedUserControl.TitleEventArgs e)
        {
            DocumentTitleChange?.Invoke(this, new DocumentTitleEventArgs(e.Title));
        }

        private void ExtandedWebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        #endregion

        protected void OnStatusTextChange(WebStatusTextEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StatusTextChange?.Invoke(this, e);
        }

        private void ExtandedWebBrowser1_DocMouseMove(object sender, HtmlElementEventArgs e)
        {
            if (isCapture)
            {
                HtmlElement hEle = (sender as HtmlDocument).GetElementFromPoint(e.ClientMousePosition);

                if (hCaptureEle == hEle || hEle == null)
                {
                    return;
                }

                if (hCaptureEle != null)
                {
                    IHTMLElement iCaptureEle = (IHTMLElement)hCaptureEle.DomElement;
                    iCaptureEle.style.cssText = captureCssText;
                }


                hCaptureEle = hEle;
                IHTMLElement iht = (IHTMLElement)hEle.DomElement;
                captureCssText = iht.style.cssText;
                iht.style.cssText = "border:1px solid red";//"background: rgba(135, 206, 250, 0.5)";

                tagNameLabel.Text = hCaptureEle.TagName;
                idLabel.Text = hCaptureEle.Id;
            }
        }

        private void ExtandedWebBrowser1_DocMouseDown(object sender, HtmlElementEventArgs e)
        {
            if(e.MouseButtonsPressed == MouseButtons.Left)
            {
                if(isCapture)
                {
                    SetCapture();

                }
            }
        }
    }
}
