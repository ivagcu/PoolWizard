using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

            Program.loadForm();
            Application.Run();
        }

        /****************************/
        /****************************/
        /**** METODOS A EJECUTAR ****/
        /****************************/
        /****************************/

        /****************************/
        /**** MÉTODOS DE CHEQUEO ****/
        /****************************/

        // CHECKMINER
        // Se comprueba si el minero está en marcha
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

        

        // CHECKFILE
        // Se comprueba si existe un fichero creado previamente para una ruta dada
        public static bool checkFile(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**************************************************/
        /**** MÉTODOS DE CREACIÓN DE CARPETAS/FICHEROS ****/
        /**************************************************/

        // CREATEFOLDER
        // Si la carpeta contenedora del software no existe, se crea
        public static void createFolder(string folder, string userName)
        {
            if (!Directory.Exists(folder))
            {
                string escritorio = @"C:\Users\" + userName + @"\Desktop\";
                string path = System.IO.Path.Combine(escritorio, "Minado");
                path = System.IO.Path.Combine(path, "Monero");
                System.IO.Directory.CreateDirectory(path);
            }
        }

        // CREATEBAT
        // Crea un bat según los parámetros introducidos por el usuario
        public static void createBat(string pool, string wallet, string user, string userName, string folder, string fileName)
        {
            string batLoc = "xmrig.exe --donate-level 1 --max-cpu-usage 50 --cpu-priority 0 -o " + pool + " -u " + wallet + " -k --tls --rig-id " + user;
            string fullPathLoc = folder + fileName;
            File.WriteAllText(fullPathLoc, batLoc);
        }

        // CREATESHORTCUT
        // Crea un acceso directo a la aplicación
        public static void createShortcut(string shortcutLocation, string targetFileLocation)
        {
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "My shortcut description";   // The description of the shortcut
            shortcut.IconLocation = @"c:\myicon.ico";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;           // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }

        /***********************************/
        /**** MÉTODOS DE CARGA O CIERRE ****/
        /***********************************/

        // LOADFORM
        // Dependiendo del valor de Checkbat, se carga una ventana u otra
        public static void loadForm()
        {
            bool previo = Program.checkFile(path);
            if (previo == true)
            {
                Form2 form2 = new Form2();
                form2.Show();
                
                /*
                string message = "Se utilizará esta configuración. Puedes cambiarla en cualquier momento. ";
                string caption = "Ficheros creados previamente.";

                MessageBox.Show(message, caption);
                */
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Show();
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


        /****************************/
        /**** MÉTODOS AUXILIARES ****/
        /****************************/

        // SPLICETEXT
        // Divide el texto dado en la cantidad de lineas dichas
        public static string SpliceText(string text, int lineLength)
        {
            return Regex.Replace(text, "(.{" + lineLength + "})", "$1" + Environment.NewLine);
        }

        // GETCOMPUTERNAME
        // Devuelve un string con el nombre del usuario que está usando el equipo
        public static string getComputerName()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] tokens = userName.Split('\\');
            userName = tokens[1];

            return userName;
        }
    }
}
