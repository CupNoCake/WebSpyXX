using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSpyXX
{
    public class WebStatusTextEventArgs : EventArgs
    {
        private string _text;

        /// <summary>
        /// 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public string Text
        {
            get { return _text; }
        }

        public WebStatusTextEventArgs(string text)
          : base()
        {
            _text = text;
        }
    }
}
