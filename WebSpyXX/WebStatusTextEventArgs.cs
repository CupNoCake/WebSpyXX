using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSpyXX
{
    public class WebStatusTextEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public string Text { get; }

        public WebStatusTextEventArgs(string text)
          : base()
        {
            Text = text;
        }
    }
}
