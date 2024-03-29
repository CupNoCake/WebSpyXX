﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using Newtonsoft.Json;

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

        public string GetCookie()
        {
            try
            {
                return CookieTools.GetCookieInternal(extandedWebBrowser1.Url, false);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return "";
        }

        public void ShowTools()
        {
            panel_tools.Visible = !panel_tools.Visible;
        }

        private void LoadScript(HtmlDocument document, string scriptText)
        {
            //找到head元素
            HtmlElement head = document.GetElementsByTagName("head")[0];
            //创建script标签
            HtmlElement scriptEl = document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            //给script标签加js内容
            element.text = scriptText;
            //将script标签添加到head标签中
            head.AppendChild(scriptEl);
        }

        public void LoadScript(string scriptText)
        {
            if(extandedWebBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                LoadScript(extandedWebBrowser1.Document, scriptText);
            }
        }

        public object ExcuteScript(string script)
        {
            return ExcuteScript(extandedWebBrowser1.Document, script);
        }

        public object ExcuteScript(string script, object[] args)
        {
            return ExcuteScript(extandedWebBrowser1.Document, script, args);
        }

        private object ExcuteScript(HtmlDocument document, string script)
        {
            return document.InvokeScript(script);
        }

        private object ExcuteScript(HtmlDocument document, string script, object[] args)
        {
            return document.InvokeScript(script, args);
        }

        private object ExcuteScriptString(HtmlDocument document, string script)
        {
            var doc = document.DomDocument as IHTMLDocument2;
            var win = doc.parentWindow as IHTMLWindow2;
            string jscode = script;  //这里写JS代码
            return win.execScript(jscode, "javascript");
        }

        private object ExcuteScriptString(string script)
        {
            return ExcuteScriptString(extandedWebBrowser1.Document, script);
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

        private void FindTableAndExport(HtmlDocument document, HtmlElement hEle)
        {
            if(hEle.TagName.Equals("TABLE"))
            {
                string tableHtml = "<html><head><meta charset=\"UTF - 8\"></head><body>";
                tableHtml += hEle.OuterHtml;
                tableHtml += "</body></html>";

                ExcuteScript(document, "tableToExcel", new object[] { tableHtml});
            }
            else
            {
                foreach(HtmlElement hSubEle in hEle.Children)
                {
                    FindTableAndExport(document, hSubEle);
                }
            }
        }

        public void ExportTable(HtmlDocument document)
        {
            if(isCapture && hCaptureEle != null)
            {
                FindTableAndExport(document, hCaptureEle);
            }
        }

        public void CaptureWindow()
        {
            if (extandedWebBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                // 保存图片对话框
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG (*.jpg)|*.jpg|PNG (*.png)|*.png";
                saveFileDialog.ShowDialog();

                Rectangle r = extandedWebBrowser1.Document.Body.ScrollRectangle;

                //extandedWebBrowser1.ScrollBarsEnabled = false;
                // 调节webBrowser的高度和宽度
                extandedWebBrowser1.Height = r.Height;
                extandedWebBrowser1.Width = r.Width;

                Bitmap bitmap = new Bitmap(r.Width, r.Height);  // 创建高度和宽度与网页相同的图片
                ((Control)extandedWebBrowser1).DrawToBitmap(bitmap,r);

               

                bitmap.Save(saveFileDialog.FileName);  // 保存图片
            }
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
                if(extandedWebBrowser1.Url != null)
                    Navigate(extandedWebBrowser1.Url.ToString());
            }
        }

        private void GoPage()
        {
            if (!string.IsNullOrEmpty(cookieTextBox.Text))
            {
                foreach (string c in cookieTextBox.Text.Split(';'))
                {
                    c.Trim();
                    string[] item = c.Split('=');
                    if (item.Length == 2)
                    {
                        CookieTools.InternetSetCookie(urlTextBox.Text, item[0], item[1]);
                    }
                }
            }

            Navigate(urlTextBox.Text);
        }

        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GoPage();
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

            //extandedWebBrowser1.Document.InvokeScript(@"window.external.MyMessageBox('javascript访问C#代码')");
            extandedWebBrowser1.GoBack();
        }

        public event EventHandler PageClose;

        private void ExtandedWebBrowser1_Quit(object sender, EventArgs e)
        {
            isAppExit = true;
            PageClose?.Invoke(this, EventArgs.Empty);
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
            timer1.Stop();
            timer1.Interval = 600000;
            timer1.Start();
            //string cookie = extandedWebBrowser1.Document.Cookie;
            //string cookie = "";
            //int size = 0;
            //GetCookieInternal(new Uri(urlTextBox.Text), false);
            //InternetGetCookie(urlTextBox.Text, "", out cookie, out size);
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
            if (e.MouseButtonsPressed == MouseButtons.Left)
            {
                if (isCapture)
                {
                    string script = @"function tableToExcel(tableHtml){
                        var excelBlob = new Blob([tableHtml], {type: 'application/vnd.ms-excel'});
                        var fileName = 'table.xls';
                        window.navigator.msSaveOrOpenBlob(excelBlob,fileName);
                    }";
                    LoadScript(sender as HtmlDocument, script);
                    ExportTable(sender as HtmlDocument);
                    SetCapture();
                }
            }
        }

        private void ExtandedWebBrowser1_DocClick(object sender, HtmlElementEventArgs e)
        {

        }

        #endregion

        protected void OnStatusTextChange(WebStatusTextEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StatusTextChange?.Invoke(this, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            extandedWebBrowser1.Refresh();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            GoPage();
        }

        private void tb_js_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                string js = tb_js.Text.Trim();
                tb_js.Text = "";
                if (js.Length > 0)
                {
                    tb_result.Text = js;

                    object obj = ExcuteScriptString(js);

                    if (obj != null)
                    {
                        tb_result.Text = obj.ToString();
                    }
                }

                e.Handled = true;
            }
        }
    }
}
