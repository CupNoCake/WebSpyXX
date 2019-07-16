using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtandedUserControl
{
     public class TitleEventArgs : EventArgs
    {
        public string Title { get; }

        public TitleEventArgs(string title) : base()
        {
            Title = title;
        }
    }
}
