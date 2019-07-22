using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using System.Security.Permissions;
using System.Drawing;

namespace ExtandedUserControl
{
    public class ExtandedWebBrowser : WebBrowser
    {

        #region 私有变量
        SHDocVw.IWebBrowser2 axIWebBrowser2;
        AxHost.ConnectionPointCookie cookie;
        WebBrowserExtendedEvents events;
        #endregion

        #region override method
        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code. 
        /// Called by the control when the underlying ActiveX control is created. 
        /// </summary>
        /// <param name="nativeActiveXObject"></param>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void AttachInterfaces(object nativeActiveXObject)
        {
            axIWebBrowser2 = (SHDocVw.IWebBrowser2)nativeActiveXObject;
            axIWebBrowser2.Silent = true;
            base.AttachInterfaces(nativeActiveXObject);
        }

        /// <summary>
        /// This method supports the .NET Framework infrastructure and is not intended to be used directly from your code. 
        /// Called by the control when the underlying ActiveX control is discarded. 
        /// </summary>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void DetachInterfaces()
        {
            axIWebBrowser2 = null;
            base.DetachInterfaces();
        }

        /// <summary>
        /// This method will be called to give you a chance to create your own event sink
        /// </summary>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void CreateSink()
        {
            // Make sure to call the base class or the normal events won't fire
            base.CreateSink();
            events = new WebBrowserExtendedEvents(this);
            cookie = new AxHost.ConnectionPointCookie(this.ActiveXInstance, events, typeof(SHDocVw.DWebBrowserEvents2));
        }

        /// <summary>
        /// Detaches the event sink
        /// </summary>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void DetachSink()
        {
            if (null != cookie)
            {
                cookie.Disconnect();
                cookie = null;
            }

            base.DetachSink();
        }

        /// <summary>
        /// Overridden
        /// </summary>
        /// <param name="m">The <see cref="Message"/> send to this procedure</param>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                //case (int)WindowsMessages.WM_DESTROY:
                    //OnQuit();
                    //break;
                case (int)WindowsMessages.WM_PARENTNOTIFY:
                    {
                        int X = (int)m.WParam & 0xFFFF;
                        if (X == 0x2/*WM_DESTROY*/)//若收到该消息，引发WindowClosed事件
                        {
                            OnQuit();
                        }
                    }
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }

        #endregion

        #region event definition

        /// <summary>
        /// Fires when downloading of a document begins
        /// </summary>
        public event EventHandler Downloading;

        /// <summary>
        /// Fires when downloading is completed
        /// </summary>
        /// <remarks>
        /// Here you could start monitoring for script errors. 
        /// </remarks>
        public event EventHandler DownloadComplete;

        /// <summary>
        /// Fires before navigation occurs in the given object (on either a window or frameset element).
        /// </summary>
        public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNavigate;

        /// <summary>
        /// Raised when a new window is to be created. Extends DWebBrowserEvents2::NewWindow2 with additional information about the new window.
        /// </summary>
        public event EventHandler<BrowserExtendedNavigatingEventArgs> StartNewWindow;

        /// <summary>
        /// Raised when StatusText is to be changed.
        /// </summary>
        public event EventHandler<StatusTextEventArgs> StatusTextChange;

        /// <summary>
        /// Raised when Title is to be changed.
        /// </summary>
        public event EventHandler<TitleEventArgs> TitleChange;

        /// <summary>
        /// Raised when the browser application quits
        /// </summary>
        /// <remarks>
        /// Do not confuse this with DWebBrowserEvents2.Quit... That's something else.
        /// </remarks>
        public event EventHandler Quit;

        public event EventHandler<HtmlElementEventArgs> DocMouseMove;
        public event EventHandler<HtmlElementEventArgs> DocMouseDown;
        public event EventHandler<HtmlElementEventArgs> DocClick;

        #endregion

        #region 事件触发函数
        /// <summary>
        /// Raises the <see cref="Downloading"/> event
        /// </summary>
        /// <param name="e">Empty <see cref="EventArgs"/></param>
        /// <remarks>
        /// You could start an animation or a notification that downloading is starting
        /// </remarks>
        protected void OnDownloading(EventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            Downloading?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="DownloadComplete"/> event
        /// </summary>
        /// <param name="e">Empty <see cref="EventArgs"/></param>
        protected virtual void OnDownloadComplete(EventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            DownloadComplete?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="StartNewWindow"/> event
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
        protected void OnStartNewWindow(BrowserExtendedNavigatingEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StartNewWindow?.Invoke(this, e);

        }

        /// <summary>
        /// Raises the <see cref="StartNavigate"/> event
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when BrowserExtendedNavigatingEventArgs is null</exception>
        protected void OnStartNavigate(BrowserExtendedNavigatingEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StartNavigate?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="StatusTextChange"/> event
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="ArgumentNullException">Thrown when StatusTextEventArgs is null</exception>
        protected void OnStatusTextChange(StatusTextEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StatusTextChange?.Invoke(this, e);

        }

        /// <summary>
        /// Raises the <see cref="TitleChange"/> event
        /// </summary>
        /// <param name="e"></param>
        /// <exception cref="ArgumentNullException">Thrown when TitleEventArgs is null</exception>
        protected void OnTitleChange(TitleEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            TitleChange?.Invoke(this, e);

        }

        /// <summary>
        /// Raises the <see cref="Quit"/> event
        /// </summary>
        protected void OnQuit()
        {
            Quit?.Invoke(this, EventArgs.Empty);
        }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        private void InitDocumentEvent(HtmlDocument doc)
        {
            doc.MouseMove += Document_MouseMove;
            doc.MouseDown += Document_MouseDown;
            doc.Click += Document_Click;

            for (int i = 0; i < doc.Window.Frames.Count; i++)
            {
                InitDocumentEvent(doc.Window.Frames[i].Document);
            }
        }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected void OnDocumentComplete()
        {
            //InitDocumentEvent(Document);
        }

       

        #endregion

        private void Document_MouseMove(object sender, HtmlElementEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");
            DocMouseMove?.Invoke(sender, e);
        }

        private void Document_MouseDown(object sender, HtmlElementEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");
            DocMouseDown?.Invoke(sender, e);
        }

        private void Document_Click(object sender, HtmlElementEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");
            DocClick?.Invoke(sender, e);
        }

        #region 属性
        /// <summary>
        /// Returns the automation object for the web browser
        /// </summary>
        public object Application
        {
            get { return axIWebBrowser2.Application; }
        }
        #endregion

        #region The Implementation of DWebBrowserEvents2 for firing extra events

        //This class will capture events from the WebBrowser
        class WebBrowserExtendedEvents : SHDocVw.DWebBrowserEvents2
        {
            public WebBrowserExtendedEvents() { }

            ExtandedWebBrowser _Browser;
            public WebBrowserExtendedEvents(ExtandedWebBrowser browser) { _Browser = browser; }

            #region DWebBrowserEvents2 Members
            public void StatusTextChange(string Text)
            {
                StatusTextEventArgs args = new StatusTextEventArgs(Text);
                _Browser.OnStatusTextChange(args);
            }

            public void ProgressChange(int Progress, int ProgressMax)
            {
                //throw new NotImplementedException();
            }

            public void CommandStateChange(int Command, bool Enable)
            {
                //throw new NotImplementedException();
            }

            public void DownloadBegin()
            {
                _Browser.OnDownloading(EventArgs.Empty);
            }

            public void DownloadComplete()
            {
                _Browser.OnDownloadComplete(EventArgs.Empty);
            }

            public void TitleChange(string Text)
            {
                _Browser.OnTitleChange(new TitleEventArgs(Text));
            }

            public void PropertyChange(string szProperty)
            {
                //throw new NotImplementedException();
            }

            public void BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
            {
                Uri urlUri = new Uri(URL.ToString());

                string tFrame = null;
                if (TargetFrameName != null)
                    tFrame = TargetFrameName.ToString();

                BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(pDisp, urlUri, tFrame, UrlContext.None);
                _Browser.OnStartNavigate(args);

                Cancel = args.Cancel;
                pDisp = args.AutomationObject;
            }

            public void NewWindow2(ref object ppDisp, ref bool Cancel)
            {
                BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(ppDisp, null, null, UrlContext.None);
                _Browser.OnStartNewWindow(args);
                Cancel = args.Cancel;
                ppDisp = args.AutomationObject;
            }

            public void NavigateComplete2(object pDisp, ref object URL)
            {
                //throw new NotImplementedException();
            }

            public void DocumentComplete(object pDisp, ref object URL)
            {
                _Browser.OnDocumentComplete();
                //throw new NotImplementedException();
            }

            public void OnQuit()
            {
                //throw new NotImplementedException();
            }

            public void OnVisible(bool Visible)
            {
                //throw new NotImplementedException();
            }

            public void OnToolBar(bool ToolBar)
            {
                //throw new NotImplementedException();
            }

            public void OnMenuBar(bool MenuBar)
            {
                //throw new NotImplementedException();
            }

            public void OnStatusBar(bool StatusBar)
            {
                //throw new NotImplementedException();
            }

            public void OnFullScreen(bool FullScreen)
            {
                //throw new NotImplementedException();
            }

            public void OnTheaterMode(bool TheaterMode)
            {
                //throw new NotImplementedException();
            }

            public void WindowSetResizable(bool Resizable)
            {
                //throw new NotImplementedException();
            }

            public void WindowSetLeft(int Left)
            {
                //throw new NotImplementedException();
            }

            public void WindowSetTop(int Top)
            {
                //throw new NotImplementedException();
            }

            public void WindowSetWidth(int Width)
            {
                //throw new NotImplementedException();
            }

            public void WindowSetHeight(int Height)
            {
                //throw new NotImplementedException();
            }

            public void WindowClosing(bool IsChildWindow, ref bool Cancel)
            {
                //throw new NotImplementedException();
            }

            public void ClientToHostWindow(ref int CX, ref int CY)
            {
                //throw new NotImplementedException();
            }

            public void SetSecureLockIcon(int SecureLockIcon)
            {
                //throw new NotImplementedException();
            }

            public void FileDownload(bool ActiveDocument, ref bool Cancel)
            {
                //throw new NotImplementedException();
            }

            public void NavigateError(object pDisp, ref object URL, ref object Frame, ref object StatusCode, ref bool Cancel)
            {
                //throw new NotImplementedException();
            }

            public void PrintTemplateInstantiation(object pDisp)
            {
                //throw new NotImplementedException();
            }

            public void PrintTemplateTeardown(object pDisp)
            {
                //throw new NotImplementedException();
            }

            public void UpdatePageStatus(object pDisp, ref object nPage, ref object fDone)
            {
                //throw new NotImplementedException();
            }

            public void PrivacyImpactedStateChange(bool bImpacted)
            {
                //throw new NotImplementedException();
            }

            public void NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
            {
                BrowserExtendedNavigatingEventArgs args = new BrowserExtendedNavigatingEventArgs(ppDisp, new Uri(bstrUrl), null, (UrlContext)dwFlags);
                _Browser.OnStartNewWindow(args);
                Cancel = args.Cancel;
                ppDisp = args.AutomationObject;
            }

            public void SetPhishingFilterStatus(int PhishingFilterStatus)
            {
                //throw new NotImplementedException();
            }

            public void WindowStateChanged(uint dwWindowStateFlags, uint dwValidFlagsMask)
            {
                //throw new NotImplementedException();
            }

            public void NewProcess(int lCauseFlag, object pWB2, ref bool Cancel)
            {
                //throw new NotImplementedException();
            }

            public void ThirdPartyUrlBlocked(ref object URL, uint dwCount)
            {
                //throw new NotImplementedException();
            }

            public void RedirectXDomainBlocked(object pDisp, ref object StartURL, ref object RedirectURL, ref object Frame, ref object StatusCode)
            {
                //throw new NotImplementedException();
            }

            public void BeforeScriptExecute(object pDispWindow)
            {
                //throw new NotImplementedException();
            }

            public void WebWorkerStarted(uint dwUniqueID, string bstrWorkerLabel)
            {
                //throw new NotImplementedException();
            }

            public void WebWorkerFinsihed(uint dwUniqueID)
            {
                //throw new NotImplementedException();
            }

            #endregion
        }

        #endregion
    }
}
