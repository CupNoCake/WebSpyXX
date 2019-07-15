using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace chromeTools
{
    public class SeleniumChromeTools : IChromeTools
    {
        public SeleniumChromeTools()
        {
            selenium = null;
        }

        #region 实现接口
        public void Close()
        {
            if (selenium != null)
            {
                selenium.Quit();
            }
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)selenium).ExecuteScript(script, args);
        }

        public object ExecuteScriptFile(string scriptFilePath, params object[] args)
        {
            //读取文件内容
            StreamReader sr = new StreamReader(scriptFilePath, System.Text.Encoding.Default);
            string ls_input = sr.ReadToEnd().TrimStart();
            sr.Close();

            return ((IJavaScriptExecutor)selenium).ExecuteScript(ls_input, args);
        }

        public void Start()
        {
            if (selenium == null)
            {
                ChromeOptions chromeOption = new ChromeOptions();
                chromeOption.AddArgument("lang=zh_CN.UTF-8");
                chromeOption.AddArgument("--start-maximized");

                selenium = new ChromeDriver(chromeOption);
            }       
        }
        #endregion 实现接口

        #region 私有成员变量

        private IWebDriver selenium;

        #endregion 私有成员变量
    }
}
