using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace PoolWizard
{
    static class Program
    {
        static string userName = Program.getComputerName();
        static string path = @"C:\Users\" + userName + @"\Desktop\Minado\Monero\exe.bat";

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.checkForm();
        }

        /****************************/
        /**** METODOS A EJECUTAR ****/
        /****************************/

        /**** MÉTODOS DE CHEQUEO ****/

        // GETCOMPUTERNAME
        // Devuelve un string con el nombre del usuario que está usando el equipo
        public static string getComputerName()
        {

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] tokens = userName.Split('\\');
            userName = tokens[1];

            return userName;

        }

        // CHECKBROSER
        // Comprobar los navegadores que tiene instalados el usuario 
        // para abrir la web de info con chrome, mozilla o internet explorer
        // y devuelve el psi con la cadena de caracteres del proceso que
        // inicia el navegador
        public static System.Diagnostics.ProcessStartInfo checkBrowser()
        {

            try
            {
                RegistryKey browserKeys;
                //Hacer comprobacion en 32 bits o 64 bits
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
                if (browserKeys == null)
                {
                    browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                }
                    
                string[] browserNames = browserKeys.GetSubKeyNames();
                var psi = new System.Diagnostics.ProcessStartInfo("iexplore.exe");

                foreach (String s in browserNames)
                {
                    if (s.Contains("Chrome"))
                        psi = new System.Diagnostics.ProcessStartInfo("chrome.exe");
                    else if (s.Contains("Mozilla"))
                        psi = new System.Diagnostics.ProcessStartInfo("mozilla.exe");
                }
               return psi;
            }

            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
                return null;
            }

            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
                return null;
            }

        }

        // CREATEFOLDER
        // Si la carpeta contenedora del software no existe, se crea
        public static void createFolder (string folder, string userName)
        {
            if(!Directory.Exists(folder))
                {
                    string escritorio = @"C:\Users\" + userName + @"\Desktop\";
                    string path = System.IO.Path.Combine(escritorio, "Minado");
                    path = System.IO.Path.Combine(path, "Monero");
                    System.IO.Directory.CreateDirectory(path);

                }
        }

        // CHECKBAT
        // Se comprueba si existe un bat creado previamente
        public static bool checkBat(string path)
        {
            
             if(File.Exists(path))
             {
                 string message = "Existen ficheros de configuración. ¿Usar esta configuración?";
                 string caption = "Ficheros creados previamente.";
                 MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                 DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    return true;
                }
             }
            return false;
        }

        public static void checkForm()
        {
            bool previo = Program.checkBat(path);
            if (previo == true)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else
            {
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
        }

        // FORMCLOSING
        // Acciones a realizar al cerrar cualquier ventana de la aplicación
        public static void formClosing()
        {

            bool minando = false;
            Process[] mineros;
            mineros = Process.GetProcessesByName("xmrig");
            
            // Se comprueba si el software está en marcha
            foreach(Process proc in mineros)
            {
                minando = true;
            }

            //Si se está minando, cerrará el programa de minado
            if(minando == true)
            {
                System.Diagnostics.Process.Start("cmd.exe", "/c taskkill /F /IM xmrig.exe /T");
            }

        }

        // CREATEBAT
        // Crea un bat según los parámetros introducidos por el usuario
	    public static void createBat(string pool, string wallet, string user, string userName, string folder, string fileName)
        {
            
            string batLoc = "xmrig.exe --donate-level 1 --max-cpu-usage 50 --cpu-priority 1 -o " + pool + " -u " + wallet + " -k --tls --rig-id " + user;
            string fullPathLoc = folder + fileName;
            File.WriteAllText(fullPathLoc, batLoc);
            
            /***** Para crear el archivo en la carpeta de inicio *****/

            //string batIni = @"C:\Users\" + userName + @"\Desktop\Dollars4Free\xmrig.exe --donate-level 1 --max-cpu-usage 50 --cpu-priority 1 -o " + pool + " -u " + wallet + " -k --tls --rig-id " + user;
            //string fullPathIni = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\exe.bat";
            //File.WriteAllText(fullPathIni, batIni);
           
        }

        // STARTMINING 
        // Empieza el proceso de minado arrancando el bat creado previamente
        public static void startMining(string folder, string fileName)
        {
            
            string strCmdText = "/C cd " + folder + "&& " + fileName;
            ProcessStartInfo pStartInfo = new ProcessStartInfo("CMD.exe", strCmdText);
            pStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = new Process();
            p.StartInfo = pStartInfo;
            p.Start();

        }
        // SPLICETEXT
        // Divide el texto dado en la cantidad de lineas dichas
        public static string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }

        public static bool checkMiner()
        {
            bool minando = false;
            Process[] mineros;
            mineros = Process.GetProcessesByName("xmrig");

            // Se comprueba si el software está en marcha
            foreach (Process proc in mineros)
            {
                minando = true;
            }

            return minando;
        }
    }
}
