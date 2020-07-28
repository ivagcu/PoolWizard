using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Program.formClosing();
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
    }
}
