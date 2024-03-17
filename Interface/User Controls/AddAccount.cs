using LAC.Classes.Json;
using LAC.Models;
using System.Windows.Forms;

namespace LAC.Interface.User_Controls
{
    public partial class AddAccount : UserControl
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, System.EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var summoner = new Summoner
            {
                Username = textBoxUsername.Text,
                Password = textBoxPassword.Text,
                SummonerName = textBoxSummonerName.Text,
                Server = comboBoxServer.Text,
            };

            CredentialsHandler.AddOrUpdateCredentials(summoner);
            Program.main.UpdateDGV();
            FindForm().Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text)
                || string.IsNullOrWhiteSpace(textBoxPassword.Text)
                || string.IsNullOrWhiteSpace(textBoxSummonerName.Text)
                || string.IsNullOrEmpty(comboBoxServer.Text))
                return false;

            return true;
        }
    }
}