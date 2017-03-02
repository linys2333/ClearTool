using System;
using System.Windows.Forms;
using ClearTool.Business.DS;
using ClearTool.Properties;
using LysExtend;

namespace ClearTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.InitPath($@"{Application.StartupPath}\Log\");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SettingForm());
        }
    }
}
