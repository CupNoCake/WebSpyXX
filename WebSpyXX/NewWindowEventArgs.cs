using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSpyXX
{
    public class NewWindowEventArgs : EventArgs
    {
        public string Url { get; }

        public NewWindowEventArgs(string url):base()
        {
            Url = url;
        }
    }
}
