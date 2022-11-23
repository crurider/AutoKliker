using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AutoKliker
{
    public partial class Kliker : Form
    {
        private BackPane backgroundPanel;
        private DataTable dtPositions;
        private DataRow dataRow;
        private Random random;
        private uint klikX;
        private uint klikY;
        private int r;
        private int counter;
        private int cnt;
        private string clickType;
        private int rowIndex;
        public CancellationTokenSource source; 

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Kliker()
        {
            InitializeComponent();
        }

        // Odabir pozicije kursora
        private void btnIzaberi_Click(object sender, EventArgs e)
        {
            btnIzaberi.Enabled = false;
            WindowState = FormWindowState.Minimized;
            showPanel();
            txtPozicijaX.Text = Program.pozicijaX;
            txtPozicijaY.Text = Program.pozicijaY;
            btnIzaberi.Enabled = true;
        }

        // Prikaz providnog panela za odabir pozicije
        private void showPanel()
        {
            double maxWidth = SystemParameters.VirtualScreenWidth;
            double maxHeight = SystemParameters.VirtualScreenHeight;

            backgroundPanel = new BackPane();
            backgroundPanel.Text = "Izaberite poziciju";
            backgroundPanel.Opacity = .40;

            backgroundPanel.Size = new Size((int)maxWidth, (int)maxHeight);
            backgroundPanel.FormBorderStyle = FormBorderStyle.None;
            backgroundPanel.TopMost = true;

            backgroundPanel.ShowDialog();
            this.WindowState = FormWindowState.Normal;
        }

        // Dodavanje u listu
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (dtPositions == null)
            {
                dtPositions = new DataTable();
                createTable(dtPositions);
            }
            dataRow = dtPositions.NewRow();
            addRowWithData(dataRow, dtPositions);
        }

        // Kreiranje skeleta tabele
        private void createTable(DataTable dt)
        {
            DataColumn kolonaX = dt.Columns.Add("X");
            kolonaX.ReadOnly = true;
            DataColumn kolonaY = dt.Columns.Add("Y");
            kolonaY.ReadOnly = true;
            DataColumn kolonaOd = dt.Columns.Add("OD", typeof(Int32));
            kolonaOd.ReadOnly = true;
            DataColumn kolonaDo = dt.Columns.Add("DO", typeof(Int32));
            kolonaDo.ReadOnly = true;
            DataColumn kolonaTip = dt.Columns.Add("TIP");
            kolonaTip.ReadOnly = true;
        }

        // Popuni red
        private void addRowWithData(DataRow dr, DataTable dt)
        {
            dr["X"] = txtPozicijaX.Text;
            dr["Y"] = txtPozicijaY.Text;
            try
            {
                dr["OD"] = Convert.ToInt32(txtDelayFrom.Text);
                dr["DO"] = Convert.ToInt32(txtDelayTo.Text);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Raspon mora biti u milisekundama!", "Greška kod unosa raspona");
                txtDelayFrom.Text = "";
                txtDelayTo.Text = "";
                return;
                
            }
            if (rightClickYes.Checked == true)
            {
                dr["TIP"] = "R";
            }
            else
            {
                dr["TIP"] = "L";
            }
            dt.Rows.Add(dr);
            dataGrid.DataSource = dt;
            clearFields();
        }

        // Refresh polja
        private void clearFields()
        {
            txtPozicijaX.Text = "";
            txtPozicijaY.Text = "";
            txtDelayFrom.Text = "";
            txtDelayTo.Text = "";
        }

        // Pomeri kursor na odredjenu poziciju i klikni izabrani klik
        // Spava dok ne dodje random vreme za klik
        private Task moveCursorAndClick(uint x, uint y)
        {
            source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            return Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(r);
                this.Invoke((Action)delegate
                {
                    this.Cursor = new Cursor(Cursor.Current.Handle);
                });

                if (token.IsCancellationRequested)
                {
                    System.Windows.Forms.MessageBox.Show("Kliktanje stopirano!", "Obaveštenje");
                    return;
                }

                Cursor.Position = new Point((int)x, (int)y);
                if (clickType.Equals("R"))
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
                }
                else
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                }
            }, token);
        }

        // Random vreme u opsegu
        private int randomTime(int min, int max)
        {
            random = new Random();
            return random.Next(min, max);
        }
        
        // Pokreni kliktanje
        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            try
            {
                counter = Int32.Parse(txtBrojPonavljanja.Text);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Broj ponavljanja mora biti broj!", "Greška kod unosa broja ponavljanja");
            }
            this.WindowState = FormWindowState.Minimized;
            for (cnt = counter; cnt > 0;)
            {
                for (int j = 0; j < dtPositions.Rows.Count; j++)
                {     
                    r = randomTime(Int32.Parse(dtPositions.Rows[j]["OD"].ToString()), Int32.Parse(dtPositions.Rows[j]["DO"].ToString()));
                    Console.WriteLine("Time: " + r);
                    Console.WriteLine("Count: " + cnt);
                    klikX = uint.Parse(dtPositions.Rows[j]["X"].ToString());
                    klikY = uint.Parse(dtPositions.Rows[j]["Y"].ToString());
                    clickType = dtPositions.Rows[j]["TIP"].ToString();
                    await moveCursorAndClick(klikX, klikY);
                    cnt--;
                }
            }
            btnStop_Click(sender, e);
        }

        // stop clicking
        private void btnStop_Click(object sender, EventArgs e)
        {
            cnt = 0;
            source?.Cancel();
            btnStart.Enabled = true;
            this.WindowState = FormWindowState.Normal;
            Cursor.Current = Cursors.Default;
        }

        // prikazi meni kada se klikne desni klik na red
        private void dataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.dataGrid.ClearSelection();
                    this.dataGrid.Rows[rowIndex].Selected = true;
                    this.ContextMenuStrip = opcijeDesnogKlika;
                }
            }
        }

        // brisanje reda iz liste
        private void opcijeDesnogKlika_Click(object sender, EventArgs e)
        {
            if (!this.dataGrid.Rows[rowIndex].IsNewRow)
            {
                this.dataGrid.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
