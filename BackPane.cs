using System.Windows.Forms;

namespace AutoKliker
{
    public partial class BackPane : Form
    {
        public BackPane()
        {
            InitializeComponent();
        }

        private void BackPane_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Program.pozicijaX = MousePosition.X.ToString();
                Program.pozicijaY = MousePosition.Y.ToString();
                this.Close();
            }
        }
    }
}
