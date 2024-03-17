using LAC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LAC.Classes.Json
{
    internal class CredentialsHandler
    {
        private static List<Summoner> Summoner;

        public static Summoner GetAccount(string username)
        {
            if (Summoner == null)
                LoadCredentials();

            return Summoner.FirstOrDefault(account => string.Equals(account.Username, username, StringComparison.OrdinalIgnoreCase));
        }

        public static void LoadCredentials()
        {
            if (File.Exists(Settings.accountData))
            {
                var json = File.ReadAllText(Settings.accountData);
                Summoner = JsonConvert.DeserializeObject<List<Summoner>>(json);
                return;
            }
            Summoner = new List<Summoner>();
            SaveCredentials(); // Save the empty list to create the JSON file
        }

        internal static void AddOrUpdateCredentials(Summoner credentials)
        {
            if (Summoner == null) LoadCredentials();
            if (Summoner == null) Summoner = new List<Summoner>();

            credentials.Username = credentials.Username;
            credentials.Password = Encryption.Encrypt(credentials.Password);
            credentials.SummonerName = credentials.SummonerName;
            credentials.Server = credentials.Server;

            var existingCredential = Summoner.FirstOrDefault(x => string.Equals(x.Username, credentials.Username, StringComparison.OrdinalIgnoreCase));

            if (existingCredential != null)
            {
                existingCredential.SummonerName = credentials.SummonerName;
                existingCredential.Password = credentials.Password;
                existingCredential.Server = credentials.Server;
                SaveCredentials();
                return;
            }

            Summoner.Add(credentials);
            SaveCredentials();
        }

        internal static void RemoveCredentials(string username, bool saveCredentials = true)
        {
            if (Summoner == null)
                LoadCredentials();

            var currentCredential = Summoner.FirstOrDefault(credential => credential.Username == username);
            if (currentCredential == null) return;

            Summoner.Remove(currentCredential);

            if (saveCredentials)
                SaveCredentials();
        }

        private static void SaveCredentials()
        {
            File.WriteAllText(Settings.accountData, JsonConvert.SerializeObject(Summoner, Formatting.Indented));
        }
    }
}