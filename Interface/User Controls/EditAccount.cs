using LAC.Classes;
using LAC.Classes.Json;
using LAC.Models;
using System.Windows.Forms;

namespace LAC.Interface.User_Controls
{
    public partial class EditAccount : UserControl
    {
        private Summoner originalSummoner;

        public EditAccount(Summoner summoner)
        {
            InitializeComponent();
            originalSummoner = summoner;
            PopulateFields(summoner);
        }

        private void PopulateFields(Summoner summoner)
        {
            textBoxUsername.Text = summoner.Username;
            textBoxPassword.Text = Encryption.Decrypt(summoner.Password);
            textBoxSummonerName.Text = summoner.SummonerName;
            comboBoxServer.Text = summoner.Server;
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

        private void ButtonEdit_Click(object sender, System.EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            originalSummoner.Username = textBoxUsername.Text;
            originalSummoner.Password = textBoxPassword.Text;
            originalSummoner.SummonerName = textBoxSummonerName.Text;
            originalSummoner.Server = comboBoxServer.Text;

            CredentialsHandler.AddOrUpdateCredentials(originalSummoner);

            FindForm().Close();
        }
    }
}
