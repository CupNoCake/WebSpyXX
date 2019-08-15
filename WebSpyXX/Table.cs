using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSpyXX
{
    [Serializable]
    public class DataInfo
    {
        public string Id { get; set; }
        public string Type{get; set;}
        public string SelectValue { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width{ get; set; }
        public int Height { get; set; }
        public Dictionary<string, object> Attr { get; set; }
        public List<DataInfo> Children { get; set; }
    }

    [Serializable]
    public class TaxCell
    {
        public string Id { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public int ColSpan { get; set; }
        public int RowSpan { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Html { get; set; }
        public string ShowAttr { get; set; }
        public Dictionary<string, object> Attr { get; set; }
        public List<DataInfo> DataList { get; set; }
    }
    [Serializable]
    public class Table
    {
        public List<TaxCell> Cells { get; set; }
    }
}
