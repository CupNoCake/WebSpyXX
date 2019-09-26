using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSpyXX
{
    public partial class CookieDlg : Form
    {
        public CookieDlg()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            if (!string.IsNullOrEmpty(cookieTb.Text) && !string.IsNullOrEmpty(urlTb.Text))
            {
                foreach (string c in cookieTb.Text.Split(';'))
                {
                    c.Trim();
                    string[] item = c.Split('=');
                    if (item.Length == 2)
                    {
                        bRet = CookieTools.InternetSetCookie(urlTb.Text, item[0], item[1]);

                        if (!bRet)
                            break;

                        
                    }
                }
            }

            MessageBox.Show(bRet ? "设置成功！" : "设置失败！");
        }
    }
}
