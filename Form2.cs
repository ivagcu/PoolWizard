using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PoolWizard
{
    public partial class Form2 : Form
    {
        // VARIABLES
        static string userName = Program.getComputerName();
        static string folder = @"C:\Users\" + userName + @"\Desktop\Minado\Monero\";
        static string fileName = "exe.bat";

        public Form2()
        {
            InitializeComponent();

            this.notifyIcon1.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.Items.Add("Show", null, this.MenuShow_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add("Hide", null, this.MenuHide_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, this.MenuExit_Click);

            string userName = Program.getComputerName();
            string bat = File.ReadAllText(@"C:\Users\" + userName + @"\Desktop\Minado\Monero\exe.bat");

            string wallet = bat.Substring(85, 95);
            string user = bat.Substring(199);

            wallet = Program.SpliceText(wallet, 20);

            cartera.Text = "Cartera: " + wallet;
            usuario.Text = "Usuario: " + user;

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Program.formClosing();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool minando = Program.checkMiner();
            if (minando == false)
            {
                infoWorking.Text = "OFF";
                infoWorking.ForeColor = Color.Red;
                Program.startMining(folder, fileName);
            }
            else 
            {
                infoWorking.Text = "ON";
                infoWorking.ForeColor = Color.Green;
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            var psi = Program.checkBrowser();
            psi.Arguments = "http://www.google.com/";
            System.Diagnostics.Process.Start(psi);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Funcionando minimizado.";
                notifyIcon1.BalloonTipTitle = "Estado";
                notifyIcon1.ShowBalloonTip(500);
            }
        }

        void MenuShow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        void MenuHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }

        void MenuExit_Click(object sender, EventArgs e)
        {
            Program.formClosing();
            Environment.Exit(0);
        }
    }
}
