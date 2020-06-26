using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_D
{
    static class Program
    {
        public static int sr;
        public static int sizeRes;
        public static string resultDerictory;


        [STAThread]
        public static void Main()
        {
            Run();
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Run()
        {
            Matrix.A1 = double.Parse(ConfigurationManager.AppSettings["A1"]);
            Matrix.A2 = double.Parse(ConfigurationManager.AppSettings["A2"]);
            Matrix.A3 = double.Parse(ConfigurationManager.AppSettings["A3"]);
            Matrix.B0 = double.Parse(ConfigurationManager.AppSettings["B0"]);
            Matrix.B1 = double.Parse(ConfigurationManager.AppSettings["B1"]);
            Matrix.B2 = double.Parse(ConfigurationManager.AppSettings["B2"]);
            Matrix.B3 = double.Parse(ConfigurationManager.AppSettings["B3"]);
            Matrix.matrixM = int.Parse(ConfigurationManager.AppSettings["matrixM"]);
            Matrix.matrixN = int.Parse(ConfigurationManager.AppSettings["matrixN"]);
            sizeRes = int.Parse(ConfigurationManager.AppSettings["sizeRes"]);
            resultDerictory = ConfigurationManager.AppSettings.Get("resultDirectory");
            sr = sizeRes;
            Matrix.bfBuffer = new double[6, Matrix.matrixN];
            // string[] source = Directory.GetFiles(ConfigurationManager.AppSettings.Get("sourceDirectory"));
            // foreach (var file in source)
            string source = ConfigurationManager.AppSettings.Get("sourceDirectory");
            using (FileSystemWatcher watcher = new FileSystemWatcher(source))
            {
                watcher.NotifyFilter = NotifyFilters.FileName;
                watcher.Filter = "";
                watcher.Created += OnChanged;
                watcher.EnableRaisingEvents = true;
                while (Console.Read() != 'e') ;
            }
        }
      
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string name = e.Name;
            string fullPath = e.FullPath;
            if (sr == 0)
            {
                sr = sizeRes;

            }

            if (sr == sizeRes)
            {
                Matrix.path = resultDerictory + name + ".bin";

            }
            
            Matrix matrix = Matrix.Reading(fullPath);
            var ph = Matrix.MatrixSeparation(matrix);
            var ph1 = ph.x;
            var ph2 = ph.y;
            var ph3 = ph.z;
            var df = Matrix.DemodulRefl(ph1, ph2, ph3);
            var bf = Matrix.ButterworthFilter(df);
            Matrix.Resampling(bf);
            File.Delete(fullPath);
            sr--;

        }
    }
}

