using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_D
{
    static class Program
    {
        
        
      
        [STAThread]
        static void Main()
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
            int sizeRes = int.Parse(ConfigurationManager.AppSettings["sizeRes"]);
            int sr = sizeRes;
            Matrix.bfBuffer = new double[6, Matrix.matrixN];
            string[] source = Directory.GetFiles(ConfigurationManager.AppSettings.Get("sourceDirectory"));
            foreach (var file in source)
            {
                if (sr == 0)
                {
                    sr = sizeRes;

                }

                if (sr == sizeRes)
                {
                    Matrix.path = @"C:\Work\For D\For D\Resampling\" + Path.GetFileNameWithoutExtension(file) + ".bin";
                    
                }
                Matrix matrix = Matrix.Reading(file);
                var ph = Matrix.MatrixSeparation(matrix);
                var ph1 = ph.x;
                var ph2 = ph.y;
                var ph3 = ph.z;
                var df = Matrix.DemodulRefl(ph1, ph2, ph3);
                var bf = Matrix.ButterworthFilter(df);
                Matrix.Resampling(bf);
                sr--;
            }
        }
       
    }
}

