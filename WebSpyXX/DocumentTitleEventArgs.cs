using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSpyXX
{
    public class DocumentTitleEventArgs : EventArgs
    {

        public string Title { get; }

        public DocumentTitleEventArgs(string title) : base()
        {
            Title = title;
        }
    }
}
