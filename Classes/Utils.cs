using LAC.Interface.Forms;
using LAC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAC.Classes
{
    internal class Utils
    {
        public static Form ShowDialog(Form parent, UserControl control, string title, bool isDialog = true)
        {
            var container = new Container(control, title)
            {
                Owner = parent
            };

            container.FormClosed += (sender, e) =>
            {
                if (parent is Main main) main.UpdateDGV();
            };

            if (!isDialog)
            {
                container.Show();
                return container;
            }

            using (container)
            {
                container.ShowDialog();
            }
            return container;
        }

        public static void LoadAccountMapFromJson(DataGridView dataGridView)
        {
            var accountDataJson = File.ReadAllText(Settings.accountData);
            var accountList = JsonConvert.DeserializeObject<List<Summoner>>(accountDataJson);

            if (accountList == null) return;

            dataGridView.Rows.Clear();

            foreach (var account in accountList)
            {
                var row = new DataGridViewRow();
                var cellValues = new Dictionary<string, object>()
                {
                    { "Username", account.Username },
                    { "SummonerName", account.SummonerName },
                    { "Server", account.Server },
                };

                foreach (var data in cellValues)
                {
                    var cell = new DataGridViewTextBoxCell
                    {
                        Value = data.Value
                    };
                    row.Cells.Add(cell);
                }

                dataGridView.Rows.Add(row);
            }
        }

        public static string Generate(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}