using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PoolWizard
{
    public partial class Form2 : Form
    {
        // VARIABLES
        static string userName = Program.getComputerName();
        static string folder = @"C:\Users\" + userName + @"\Desktop\Minado\Monero\";
        static string fileName = "exe.bat";
        static string path = @"C:\Users\" + userName + @"\Desktop\Minado\Monero\exe.bat";

        public Form2()
        {
            InitializeComponent();
            bool previo = Program.checkFile(path);
            
            startForm2();
            startCorner();

            
            if (previo == true)
            {
                this.Close();
            }
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
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
            Properties.Settings.Default.Save();
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        // Control de lo que ocurre cuando se minimiza
        private void Form2_Resize(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Funcionando minimizado.";
                notifyIcon1.BalloonTipTitle = "Estado";
                notifyIcon1.ShowBalloonTip(200);
            }
        }

        // Cuando se pulsa, vuelve a aparecer la ventana
        void MenuShow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            startCorner();
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        // Cuando se pulsa, se cierra el programa
        void MenuExit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Program.formClosing();
            Environment.Exit(0);
        }

        // Genera el contenido de la ventana Form2
        void startForm2()
        {
            this.notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
            this.notifyIcon1.ContextMenuStrip.Items.Add("Mostrar", null, this.MenuShow_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add("Salir", null, this.MenuExit_Click);

            string bat = File.ReadAllText(@"C:\Users\" + userName + @"\Desktop\Minado\Monero\exe.bat");

            string wallet = bat.Substring(85, 95);
            string user = bat.Substring(199);

            wallet = Program.SpliceText(wallet, 20);

            cartera.Text = "Cartera: " + wallet;
            usuario.Text = "Usuario: " + user;
        }

        // Genera la ventana en la izquieda inferior derecha
        void startCorner()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width + 10,
                                      workingArea.Bottom - Size.Height + 10);
        }

        // Genera el acceso directo en inicio o lo borra, dependiendo del valor del checkbox, que se almacena en config
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string inicio = @"C:\Users\" + userName + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\PoolWizard.lnk";
            string rutaAct = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

            if (checkBox1.Checked == true)
            {
                bool enInicio = Program.checkFile(inicio);
                if (!enInicio == true)
                {
                    Program.createShortcut(inicio, rutaAct);
                }
            }
            else
            {
                bool enInicio = Program.checkFile(inicio);
                if (enInicio == true)
                {
                    File.Delete(inicio);
                }
            }
        }
    }
}
