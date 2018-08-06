using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_LisenceFileTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LicenseChecker lc = new LicenseChecker();
            string message = string.Empty;
            bool isCheck = lc.Check("授权文件[北京客户+CPU序列号].dat", out message);
            if (!isCheck)
            {
                MessageBox.Show(message);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
