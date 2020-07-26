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
    public partial class PoolWizardX : Form
    {
        public PoolWizardX()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void InfoUP_Click(object sender, EventArgs e)
        {

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Comprobar los navegadores que tiene instalados el usuario
                RegistryKey browserKeys;
                //on 64bit the browsers are in a different location
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
                if (browserKeys == null)
                    browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");

                string[] browserNames = browserKeys.GetSubKeyNames();
                var psi = new System.Diagnostics.ProcessStartInfo("iexplore.exe");

                foreach (String s in browserNames)
                {
                    if (s.Contains("Chrome"))
                    psi = new System.Diagnostics.ProcessStartInfo("chrome.exe");
                }

                psi.Arguments = "http://www.google.com/";
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if ((textBoxUsuario.TextLength > 5) && (textBoxWallet.TextLength > 20) && (textBoxUsuario.Text.Contains("@")))
            {

                //SACAR NOMBRE DE USUARIO DEL EQUIPO
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string[] tokens = userName.Split('\\');
                userName = tokens[1];

                //CREAR FICHERO
                //OBTENER DATOS DE TEXTBOXES
                string pool = "xmrpool.eu:9999";
                string wallet = textBoxWallet.Text;
                string user = textBoxUsuario.Text;

                //GENERAR STRING CON EL CONTENIDO DEL BAT
                string batLoc = "xmrig.exe --donate-level 1 --max-cpu-usage 50 --cpu-priority 0 -o " + pool + " -u " + wallet + " -k --tls --rig-id " + user;
                string batIni = @"C:\Users\" + userName + @"\Desktop\Dollars4Free\xmrig.exe --donate-level 1 --max-cpu-usage 50 --cpu-priority 0 -o " + pool + " -u " + wallet + " -k --tls --rig-id " + user;

                // Folder, where a file is created.  
                // Make sure to change this folder to your own folder  
                string folder = @"C:\Users\" + userName + @"\Desktop\Minado\Monero\";
                // Filename  
                string fileName = "exe.bat";
                // Fullpath. You can direct hardcode it if you like.  
                string fullPathLoc = folder + fileName;
                string fullPathIni = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\exe.bat";
                // If the file does not exists, it will create a new file.  
                // This method automatically opens the file, writes to it, and closes file  
                //AÑADIR FICHEROS BAT A CARPETA LOCAL Y A INICIO
                File.WriteAllText(fullPathLoc, batLoc);
                File.WriteAllText(fullPathIni, batIni);

                //ARRANCAR PROCESO DE MINADO
                string strCmdText = "/C cd " + folder + "&& " + fileName;
                ProcessStartInfo pStartInfo = new ProcessStartInfo("CMD.exe", strCmdText);
                pStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process p = new Process();
                p.StartInfo = pStartInfo;
                p.Start();

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

            //ACCIONES A REALIZAR AL CERRAR LA VENTANA
            bool minando = false;
            Process[] mineros;
            mineros = Process.GetProcessesByName("xmrig");
            
            //COMPROBAR SI SE ESTÁ MINANDO
            foreach(Process proc in mineros)
            {
                minando = true;
            }

            //SI SE ESTÁ MINANDO, CERRAR PROGRAMA DE MINADO
            if(minando == true)
            {
                System.Diagnostics.Process.Start("cmd.exe", "/c taskkill /F /IM xmrig.exe /T");
            }

        }
    }
}

    


