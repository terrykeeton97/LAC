using System.Windows.Forms;

namespace LAC.Interface.Forms
{
    public partial class Container : Form
    {
        private readonly UserControl _userControl;

        public Container(UserControl userControl, string title)
        {
            InitializeComponent();
            _userControl = userControl;
            ShowControl(_userControl);
            Text = title;
        }

        private void ShowControl(UserControl control)
        {
            Controls.Clear();
            control.Dock = DockStyle.Fill;
            Controls.Add(control);
        }
    }
}