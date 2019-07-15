using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chromeTools
{
    public interface IChromeTools
    {
        /// <summary>
        /// 启动工具
        /// </summary>
        /// <returns>成功返回true，失败返回false</returns>
        void Start();
        /// <summary>
        /// 执行脚本
        /// </summary>
        /// <param name="script">脚本内容</param>
        /// <param name="args">脚本参数</param>
        /// <returns>返回脚本执行结果</returns>
        object ExecuteScript(string script, params object[] args);
        /// <summary>
        /// 执行脚本文件
        /// </summary>
        /// <param name="scriptFilePath">脚本文件路径</param>
        /// <param name="args">脚本参数</param>
        /// <returns>返回脚本执行结果</returns>
        object ExecuteScriptFile(string scriptFilePath, params object[] args);
        /// <summary>
        /// 关闭工具
        /// </summary>
        void Close();
    }
}
