using System;
using System.IO;

namespace LAC.Classes
{
    internal class Settings
    {
        public static readonly string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LAC");
        public static readonly string accountData = Path.Combine(basePath, "data.json");

        public static bool DirectoryPathExists;
        public static bool GameCfgExists;
        public static bool LeagueClientExists;
        public static bool LeagueClientSettingsExists;
        public static bool LcuAccountPreferencesExists;
        public static bool LcuLocalPreferencesExists;
        public static bool PerksPreferencesExists;
        public static bool PersistedSettingsExists;

        public static string RiotToken { get; set; }
        public static ushort RiotPort { get; set; }
    }
}