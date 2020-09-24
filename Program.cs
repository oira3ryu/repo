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

            //GetConnectionStrings();
            //Console.ReadLine();
            Console.WriteLine(ConfigurationManager.ConnectionStrings["rk_seikyu.Properties.Settings.PostgresConnect"]);
        }

        //static void GetConnectionStrings()
        //{
        //    ConnectionStringSettingsCollection settings =
        //        ConfigurationManager.ConnectionStrings;

        //    if (settings != null)
        //    {
        //        foreach (ConnectionStringSettings cs in settings)
        //        {
        //            //Console.WriteLine(cs.Name);
        //            //Console.WriteLine(cs.ProviderName);
        //            Console.WriteLine(cs.ConnectionString);
        //        }
        //    }
        //}

        //// Retrieves a connection string by name.
        //// Returns null if the name is not found.
        //static string GetConnectionStringByName(string name)
        //{
        //    // Assume failure.
        //    string returnValue = null;

        //    // Look for the name in the connectionStrings section.
        //    ConnectionStringSettings settings =
        //        ConfigurationManager.ConnectionStrings[name];

        //    // If found, return the connection string.
        //    if (settings != null)
        //        returnValue = settings.ConnectionString;

        //    return returnValue;
        //}
    }
}
