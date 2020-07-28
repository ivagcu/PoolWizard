using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace PoolWizard
{
    public partial class Form1 : Form
    {
        // DECLARACION DE VARIABLES

        static string userName = Program.getComputerName();
        static string path = @"C:\Users\" + userName + @"\Desktop\Minado\Monero\exe.bat";
        static string folder = @"C:\Users\" + userName + @"\Desktop\Minado\Monero\";
        static string fileName = "exe.bat";
        static string pool = "xmrpool.eu:9999";

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InfoUP_Click(object sender, EventArgs e){}

        private void btnInfo_Click(object sender, EventArgs e)
        {
            var psi = Program.checkBrowser();
            psi.Arguments = "http://www.google.com/";
            System.Diagnostics.Process.Start(psi);
                
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if ((textBoxUsuario.TextLength >= 10) && (textBoxWallet.TextLength == 95) && (textBoxUsuario.Text.Contains("@")))
            {
                
                // Nombre de pool y datos obtenidos en los textboxes
                string wallet = textBoxWallet.Text;
                string user = textBoxUsuario.Text;

                Program.createFolder(folder, userName);
                Program.createBat(pool, wallet, user, userName, folder, fileName);

                Program.startMining(folder, fileName);

                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Close();

            }
            else if (textBoxWallet.TextLength != 95)
            {
                MessageBox.Show("Introduce una cartera de Monero válida de 95 caracteres.");
            }
            else if ((textBoxUsuario.TextLength < 10) || (!textBoxUsuario.Text.Contains("@")))
            {
                MessageBox.Show("Introduce un correo válido.");
            }
        }
        
        private void PoolWizardX_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.formClosing();
        }
    }
}

    


