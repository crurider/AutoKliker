using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Tesseract;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace AutoKliker
{
    public partial class Kliker : Form
    {
        private BackPane backgroundPanel;
        private DataTable dtPositions;
        private DataRow dataRow;
        private Random random;
        private int klikX;
        private int klikY;
        private int r;
        private int counter;
        private int cnt;
        private string clickType;
        private int rowIndex;
        private int startPositionX;
        private int startPositionY;
        private double maxWidth;
        private double maxHeight;
        public CancellationTokenSource tokenSource;
        public CancellationToken token;
        private static string user = Environment.UserName;
        private string imagePath = $"C:\\Users\\{user}\\AppData\\Local\\capture.jpg";
        private string tessdataPath = Environment.GetEnvironmentVariable("TESSDATA_PREFIX");
        private string host;
        private int port;
        private string username;
        private string password;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Kliker() {
            InitializeComponent();
        }

        // Odabir pozicije kursora
        private void btnIzaberi_Click(object sender, EventArgs e) {
            btnIzaberi.Enabled = false;
            WindowState = FormWindowState.Minimized;
            showPanel();
            txtPozicijaX.Text = Program.pozicijaX;
            txtPozicijaY.Text = Program.pozicijaY;
            btnIzaberi.Enabled = true;
        }

        // Prikaz providnog panela za odabir pozicije
        private void showPanel() {
            maxWidth = SystemParameters.VirtualScreenWidth;
            maxHeight = SystemParameters.VirtualScreenHeight;

            backgroundPanel = new BackPane();
            backgroundPanel.Text = "Izaberite poziciju";
            backgroundPanel.Opacity = .40;

            backgroundPanel.Size = new Size((int)maxWidth, (int)maxHeight);
            backgroundPanel.FormBorderStyle = FormBorderStyle.None;
            backgroundPanel.TopMost = true;

            backgroundPanel.ShowDialog();
            this.WindowState = FormWindowState.Normal;
        }

        // Kreiranje skeleta tabele
        private void createTable(DataTable dt) {
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

        // Dodavanje u listu
        private void btnDodaj_Click(object sender, EventArgs e) {
            if (dtPositions == null) {
                dtPositions = new DataTable();
                createTable(dtPositions);
            }
            dataRow = dtPositions.NewRow();
            addRowWithData(dataRow, dtPositions);
        }

        // Dodavanje reda u tabelu
        private void addRowWithData(DataRow dr, DataTable dt) {
            dr["X"] = txtPozicijaX.Text;
            dr["Y"] = txtPozicijaY.Text;
            try {
                dr["OD"] = Convert.ToInt32(txtDelayFrom.Text);
                dr["DO"] = Convert.ToInt32(txtDelayTo.Text);
            }
            catch (Exception) {
                System.Windows.MessageBox.Show("Raspon mora biti u milisekundama!", "Greška kod unosa raspona");
                txtDelayFrom.Text = "";
                txtDelayTo.Text = "";
                return;
            }
            if (rightClickYes.Checked == true) {
                dr["TIP"] = "R";
            }
            else {
                dr["TIP"] = "L";
            }
            dt.Rows.Add(dr);
            dataGrid.DataSource = dt;
            clearFields();
        }

        // Prikazi meni kada se klikne desni klik na red
        private void dataGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                rowIndex = e.RowIndex;
                if (e.RowIndex != -1) {
                    this.dataGrid.ClearSelection();
                    this.dataGrid.Rows[rowIndex].Selected = true;
                    this.ContextMenuStrip = opcijeDesnogKlika;
                }
            }
        }

        // Brisanje reda iz liste
        private void opcijeDesnogKlika_Click(object sender, EventArgs e) {
            if (!this.dataGrid.Rows[rowIndex].IsNewRow) {
                this.dataGrid.Rows.RemoveAt(rowIndex);
            }
        }

        // Refresh polja
        private void clearFields() {
            txtPozicijaX.Text = "";
            txtPozicijaY.Text = "";
            txtDelayFrom.Text = "";
            txtDelayTo.Text = "";
        }

        // Random vreme u opsegu
        private int randomTime(int min, int max) {
            random = new Random();
            return random.Next(min, max);
        }

        // Pomeri kursor na odredjenu poziciju i klikni izabrani klik
        // Spava dok ne dodje random vreme za klik
        private async Task moveCursorAndClick(int x, int y, CancellationToken token) {
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;

            await Task.Run(() => {

                // pozicija kursora pre klika
                if (pocetnaPozicija.Checked) {
                    startPositionX = MousePosition.X;
                    startPositionY = MousePosition.Y;
                }

                Cursor.Position = new Point(x, y);

                if (clickType.Equals("R")) {
                   mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
                }
                else {
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                }

                // vrati na poziciju pre klika
                if (pocetnaPozicija.Checked) {
                    Cursor.Position = new Point(startPositionX, startPositionY);
                }

                // ako je obavestenje cekirano
                if (obavestenje.Checked) {
                    // slikaj prozor
                    getScreenshotAndSave();

                    Thread.Sleep(2000);

                    // uzmi text
                    string dashboardContent = getTextFromActiveWindow(imagePath);

                    // proveri da li postoji tekma
                    // ako postoji stopiraj kliker i posalji notifikaciju
                    if (dashboardContent.ToLower().Contains(txtSearchFor.Text)) {
                        cnt = 0;
                        tokenSource?.Cancel();
                        var config = getEmailParams();
                        sendMail(config);
                    }
                }

                Thread.Sleep(r);

            }, token);
        }

        // Pokreni kliktanje
        private async void btnStart_Click(object sender, EventArgs e) {
            tokenSource = new CancellationTokenSource();
            btnStart.Enabled = false;

            try {
                counter = Int32.Parse(txtBrojPonavljanja.Text);
            }
            catch (Exception) {
                System.Windows.MessageBox.Show("Broj ponavljanja mora biti broj!", "Greška kod unosa broja ponavljanja");
            }

            for (cnt = counter; cnt > 0;) {
                for (int j = 0; j < dtPositions.Rows.Count; j++) {     
                    r = randomTime(Int32.Parse(dtPositions.Rows[j]["OD"].ToString()), Int32.Parse(dtPositions.Rows[j]["DO"].ToString()));
                    Console.WriteLine("Time: " + r);
                    Console.WriteLine("Count: " + cnt);
                    klikX = Int32.Parse(dtPositions.Rows[j]["X"].ToString());
                    klikY = Int32.Parse(dtPositions.Rows[j]["Y"].ToString());
                    clickType = dtPositions.Rows[j]["TIP"].ToString();
                    await moveCursorAndClick(klikX, klikY, token);
                    cnt--;
                }
                if (token.IsCancellationRequested) {
                    btnStart.Enabled = true;
                    throw new TaskCanceledException();
                }
            }
            btnStop_Click(sender, e);
        }

        // Zaustavi kliktanje
        private void btnStop_Click(object sender, EventArgs e) {
            cnt = 0;
            tokenSource?.Cancel();
            btnStart.Enabled = true;
            Cursor.Current = Cursors.Arrow;
        }

        // Screenshot i cuvanje aktivnog prozora
        private void getScreenshotAndSave() {
            var image = ScreenCapture.CaptureActiveWindow();
            image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
            image.Dispose();
        }

        // OCR
        private string getTextFromActiveWindow(string imagePath) {
            var ocr = new TesseractEngine(tessdataPath, "eng", EngineMode.Default);
            var imgToScan = Pix.LoadFromFile(imagePath);
            var page = ocr.Process(imgToScan);
            var text = page.GetText();
            return text;
        }

        // Importovanje parametara za mail
        private IConfigurationRoot getEmailParams() {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"..\.."))
                .AddJsonFile("config\\emailConfig.json");
            return builder.Build();
        }

        // Slanje notifikacije preko mejla
        private void sendMail(IConfigurationRoot config) {
            host = config["SMTP:host"];
            port = Convert.ToInt32(config["SMTP:port"]);
            username = config["SMTP:username"];
            password = config["SMTP:password"];
            string sendTo = txtSendTo.Text;
            string subject = "The game is found in dashboard!";
            string body = "The game is found! Please start working immediately!";

            try {
                using (var client = new SmtpClient(host, port)) {
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = true;
                    client.Send(username, sendTo, subject, body);
                }
            }
            catch (Exception){
                System.Windows.MessageBox.Show("Greška kod slanja maila.");
            }
        }

        // clear placeholder text when click
        private void txtSearchFor_Click(object sender, EventArgs e) {
            txtSearchFor.Text = "";
            txtSearchFor.ForeColor = Color.Black;
        }
        private void txtSendTo_Click(object sender, EventArgs e) {
            txtSendTo.Text = "";
            txtSendTo.ForeColor = Color.Black;
        }
    }
}
