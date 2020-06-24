using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_D
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
      
        [STAThread]
        static void Main()
        {
            int sizeRes = 4;
            int sr = sizeRes;
            Matrix.bfBuffer = new double[7, 103];
           // Matrix.resBuffer = new Matrix(1600, 1103);
            string[] source = Directory.GetFiles(@"C:\Work\duble\");
            foreach (var file in source)
            {
                if (sr == 0)
                {
                    sr = sizeRes;

                }

                if (sr == sizeRes)
                {
                    Matrix.path = @"C:\Work\For D\For D\Resampling\" + Path.GetFileNameWithoutExtension(file) + ".bin";
                    //File.Create(Matrix.path) ;
                    //FileStream fs = new FileStream(Matrix.path, FileMode.Append);
                    //  BinaryWriter sw = new BinaryWriter( fs);
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
        //Application.EnableVisualStyles();
        //Application.SetCompatibleTextRenderingDefault(false);
        //Application.Run(new Form1());
    }
    }

