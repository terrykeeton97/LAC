using System.Diagnostics;
using System.Windows.Forms;

namespace LAC.Classes.League_Client
{
    internal class ClientController
    {
        public static Process StartClient()
        {
            var clientExePath = PathFinder.ClientInfo(PathFinder.ClientInfoType.LeagueClientExe);
            using (var process = new Process())
            {
                process.StartInfo.FileName = clientExePath;
                process.Start();
                return process;
            }
        }

        public static bool IsClientRunning()
        {
            var processes = Process.GetProcessesByName("LeagueClient");
            return processes.Length > 0;
        }

        public static bool IsRiotClientRunning()
        {
            var processes = Process.GetProcessesByName("Riot Client");
            return processes.Length > 0;
        }

        public static void KillAllLeagueProcesses()
        {
            try
            {
                foreach (var processName in ProcessNames)
                {
                    var processes = Process.GetProcessesByName(processName);
                    foreach (var process in processes)
                    {
                        using (var elevatedProcess = new Process())
                        {
                            elevatedProcess.StartInfo.FileName = "cmd.exe";
                            elevatedProcess.StartInfo.Arguments = $"/c taskkill /F /PID {process.Id}";
                            elevatedProcess.StartInfo.Verb = "runas";
                            elevatedProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            elevatedProcess.Start();
                            elevatedProcess.WaitForExit();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to kill all League processes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static readonly string[] ProcessNames = { "LeagueClient", "LeagueClientUx", "LeagueClientUxRender", "LeagueClientUxLock", "RiotClientUx", "RiotClientCrashHandler", "Riot Client" };
    }
}