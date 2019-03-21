using System;
using System.Windows.Forms;
using System.Configuration;

namespace rk_seikyu
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_seikyu());

            Console.WriteLine(ConfigurationManager.ConnectionStrings["rk_seikyu.Properties.Settings.PostgresConnect"]);
        }
    }
}
