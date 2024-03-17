using LAC.Classes;
using LAC.Interface.Forms;
using System;
using System.IO;
using System.Windows.Forms;

namespace LAC
{
    internal static class Program
    {
        public static Main main;

        [STAThread]
        private static void Main()
        {
            Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            main = new Main();
            Application.Run(main);
        }

        private static void Init()
        {
            Directory.CreateDirectory(Settings.basePath);
            GameFileManager.CheckClientInfo();
            GameFileManager.DoFilesExist(Settings.accountData);

            if (Properties.Settings.Default.Key == string.Empty)
            {
                Properties.Settings.Default.Key = Utils.Generate(50);
                Properties.Settings.Default.Save();
            }
        }
    }
}