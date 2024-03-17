using LAC.Classes.League_Client;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAC.Classes.LCU
{
    internal class RiotClientService
    {
        private HttpClient _httpClient;

        public RiotClientService()
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) => true
            };

            _httpClient = new HttpClient(handler);
        }

        public async Task Login(string username, string password)
        {
            if (ClientController.IsClientRunning())
            {
                ClientController.KillAllLeagueProcesses();
                await Task.Delay(2000); //Give the processes a bit more time to exit to avoid start issues
            }

            ClientController.StartClient();
            await WaitForRiotClientReady();

            if (ConnectToRiotClient())
            {
                var loginBody = $"{{\"username\":\"{username}\",\"password\":\"{Encryption.Decrypt(password)}\",\"persistLogin\":false}}";
                var response = await MakeRiotRequestWithJson("PUT", "rso-auth/v1/session/credentials", loginBody);

                if (response.Contains("auth_failure"))
                {
                    MessageBox.Show("AUTH FAILURE\nIncorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Disconnect();
        }

        private async Task WaitForRiotClientReady()
        {
            while (!ClientController.IsRiotClientRunning() || Imports.FindWindow("Chrome_WidgetWin_1", "Riot Client") == IntPtr.Zero)
            {
                await Task.Delay(2000);
            }
        }

        private async Task<string> MakeRiotRequestWithJson(string method, string endpoint, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
            {
                var putResult = await _httpClient.PutAsync(endpoint, content);
                return await putResult.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

        private bool ConnectToRiotClient()
        {
            try
            {
                var extractedValues = GetRiotClientPortAndAuthKey();
                if (extractedValues.Any(value => string.IsNullOrEmpty(value)))
                    throw new Exception("Unable to get league auth key and port");

                Settings.RiotToken = extractedValues[1];
                Settings.RiotPort = ushort.Parse(extractedValues[0]);
                var apiUri = $"https://127.0.0.1:{Settings.RiotPort}/";

                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Settings.RiotToken);
                _httpClient.BaseAddress = new Uri(apiUri);

                return true;
            }
            catch
            {
                Disconnect();
            }

            return false;
        }

        public void Disconnect()
        {
            if (_httpClient != null)
                _httpClient = null;      
        }

        private string[] GetRiotClientPortAndAuthKey()
        {
            var result = new string[3];
            var wholeCommandLine = GetRiotClientCommandLineArgs();
            var splitSpaces = wholeCommandLine.Split(' ');
            foreach (var commandLineArg in splitSpaces)
            {
                if (commandLineArg.Contains("="))
                {
                    var key = commandLineArg.Split('=')[0];
                    var value = commandLineArg.Split('=')[1];

                    if (key == "--app-port")
                    {
                        result[0] = value;
                    }
                    else if (key == "--remoting-auth-token")
                    {
                        var Token = value;
                        result[1] = Convert.ToBase64String(Encoding.ASCII.GetBytes($"riot:{Token}"));
                    }
                    else if (key == "--app-pid")
                    {
                        result[2] = value;
                    }
                }
            }
            return result;
        }

        private string GetRiotClientCommandLineArgs()
        {
            using (var process = new Process())
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c wmic PROCESS WHERE name='Riot Client.exe' GET commandline";
                process.Start();

                return process.StandardOutput.ReadToEnd();
            }
        }
    }
}