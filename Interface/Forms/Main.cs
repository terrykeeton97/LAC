using LAC.Classes;
using LAC.Classes.Json;
using LAC.Classes.LCU;
using LAC.Interface.User_Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAC.Interface.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void AddMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ShowDialog(ActiveForm, new AddAccount(), "Add Account");
        }

        private async void LoadMenuItem_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private async Task Login()
        {
            if (dataGridView.SelectedRows.Count < 1) return;

            var riotClient = new RiotClientService();
            var account = CredentialsHandler.GetAccount(dataGridView.SelectedRows[0].Cells["usernameColumn"].Value.ToString());
            GameFileManager.SetGameSettingsAndAttributes(account.Server);
            await riotClient.Login(account.Username, account.Password);

            Close();
        }

        public void UpdateDGV() => Utils.LoadAccountMapFromJson(dataGridView);

        private void DataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = dataGridView.HitTest(e.X, e.Y).RowIndex;

                if (rowIndex >= 0)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[rowIndex].Selected = true;
                    clickMenu.Show(dataGridView, e.Location);
                }
            }
        }

        private void DataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            loadClickMenu.PerformClick();
        }

        private async void LoadClickMenu_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private void EditClickMenu_Click(object sender, EventArgs e)
        {
            var username = dataGridView.SelectedRows[0].Cells["usernameColumn"].Value.ToString();
            var summoner = CredentialsHandler.GetAccount(username);

            if (summoner != null)
            {
                Utils.ShowDialog(ActiveForm, new EditAccount(summoner), "Edit Account");
                UpdateDGV();
            }
        }

        private void DeleteClickMenu_Click(object sender, EventArgs e)
        {
            var username = dataGridView.SelectedRows[0].Cells["usernameColumn"].Value.ToString();
            CredentialsHandler.RemoveCredentials(username, true);
            UpdateDGV();
        }
    }
}