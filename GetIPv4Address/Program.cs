using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetIPv4Address
{
    static class Portal
    {


        public static GlobalControl gc = new GlobalControl();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen.Splasher.Show(typeof(SplashScreen.frmSplash));

            gc.MainDialog = new MainForm();
            gc.MainDialog.StartPosition = FormStartPosition.CenterScreen;

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(gc.MainDialog);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (DialogResult.Yes == MessageBox.Show(message,"确认", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }
    }
}
