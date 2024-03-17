using LAC.Models;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using static LAC.Classes.League_Client.PathFinder;

namespace LAC.Classes
{
    internal class GameFileManager
    {
        public static bool DoFilesExist(params string[] filePaths)
        {
            try
            {
                foreach (var filePath in filePaths)
                {
                    if (!File.Exists(filePath)) File.Create(filePath).Close();
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Error creating files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CheckClientInfo()
        {
            var checks = new List<ClientInfoType>
            {
                ClientInfoType.DirectoryPath,
                ClientInfoType.GameCfg,
                ClientInfoType.LeagueClientExe,
                ClientInfoType.LeagueClientSettings,
                ClientInfoType.LCUAccountPreferences,
                ClientInfoType.LCULocalPreferences,
                ClientInfoType.PerksPerferences,
                ClientInfoType.PersistedSettings,
            };

            var settingsExistsList = new List<(ClientInfoType, bool)>
            {
                (ClientInfoType.DirectoryPath, Settings.DirectoryPathExists),
                (ClientInfoType.GameCfg, Settings.GameCfgExists),
                (ClientInfoType.LeagueClientExe, Settings.LeagueClientExists),
                (ClientInfoType.LeagueClientSettings, Settings.LeagueClientSettingsExists),
                (ClientInfoType.LCUAccountPreferences, Settings.LcuAccountPreferencesExists),
                (ClientInfoType.LCULocalPreferences, Settings.LcuLocalPreferencesExists),
                (ClientInfoType.PerksPerferences, Settings.PerksPreferencesExists),
                (ClientInfoType.PersistedSettings, Settings.PersistedSettingsExists),
            };

            foreach (var clientInfoType in checks)
            {
                var filePath = ClientInfo(clientInfoType);
                var fileExists = FileOrDirectoryExists(filePath);

                var matchingSettingTuple = settingsExistsList.Find(tuple => tuple.Item1 == clientInfoType);
                matchingSettingTuple.Item2 = fileExists;
            }
        }

        public static bool SetGameSettingsAndAttributes(string region)
        {
            try
            {
                var gameCfgFilePath = ClientInfo(ClientInfoType.GameCfg);
                var persistedSettingsFilePath = ClientInfo(ClientInfoType.PersistedSettings);
                var leagueClientSettingsFilePath = ClientInfo(ClientInfoType.LeagueClientSettings);

                if (Settings.PersistedSettingsExists)
                    SetFileAttributes((gameCfgFilePath, Settings.PersistedSettingsExists ? FileAttributes.ReadOnly : FileAttributes.Normal),
                        (persistedSettingsFilePath, Settings.PersistedSettingsExists ? FileAttributes.ReadOnly : FileAttributes.Normal));

                UpdateLeagueClientSettings(leagueClientSettingsFilePath, region);
                return true;
            }
            catch
            {
                MessageBox.Show("Error setting game settings and attributes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static void SetFileAttributes(params (string FilePath, FileAttributes Attributes)[] fileAttributesList)
        {
            foreach (var (FilePath, Attributes) in fileAttributesList)
            {
                File.SetAttributes(FilePath, Attributes);
            }
        }

        private static void UpdateLeagueClientSettings(string filePath, string region)
        {
            try
            {
                var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
                var serializer = new SerializerBuilder().Build();
                var settings = deserializer.Deserialize<Client>(File.ReadAllText(filePath));
                settings.Install.Globals.Region = region;
                settings.Install.Globals.Locale = "en_GB";
                File.WriteAllText(filePath, serializer.Serialize(settings));
            }
            catch
            {
                MessageBox.Show($"Error updating LeagueClientSettings at {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool FileOrDirectoryExists(string path) => File.Exists(path) || Directory.Exists(path);
    }
}