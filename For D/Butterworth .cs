using System.IO;
using System.Configuration;
using System;

namespace For_D
{
    public partial class Matrix
    {
        public static double[,] bfBuffer;
        
        
        public static Matrix ButterworthFilter(Matrix data)
        {
          
            double A1 = double.Parse(ConfigurationManager.AppSettings["A1"]);
            double A2 = double.Parse(ConfigurationManager.AppSettings["A2"]);
            double A3 = double.Parse(ConfigurationManager.AppSettings["A3"]);
            double B0 = double.Parse(ConfigurationManager.AppSettings["B0"]);
            double B1 = double.Parse(ConfigurationManager.AppSettings["B1"]);
            double B2 = double.Parse(ConfigurationManager.AppSettings["B2"]);
            double B3 = double.Parse(ConfigurationManager.AppSettings["B3"]);
            int size = data.M - 3;
            //string path= @"C:\Work\For D\For D\ButterworfRes\"+ Path.GetFileNameWithoutExtension( Matrix.fileName)+".bin";
            //BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
            Matrix res = new Matrix(data.M, data.N);

            for (int i = 3; i < data.M; i++)
            {
                for (int j = 0; j < data.N; j++)
                {
                    
                        res[0, j] = B0 * data[0, j] + B1 * bfBuffer[5, j] + B2 * bfBuffer[4, j] + B3 * bfBuffer[3, j]
                                                - A1 * bfBuffer[2, j] - A2 * bfBuffer[1, j] - A3 * bfBuffer[0, j];
                    
                        res[1, j] = B0 * data[1, j] + B1 * data[0, j] + B2 * bfBuffer[5, j] + B3 * bfBuffer[4, j]
                                                - A1 * res[0, j] - A2 * bfBuffer[2, j] - A3 * bfBuffer[1, j];
                    
                        res[2, j] = B0 * data[2, j] + B1 * data[1, j] + B2 * data[0, j] + B3 * bfBuffer[5, j]
                                                - A1 * res[1, j] - A2 * res[0, j] - A3 * bfBuffer[2, j];
                    
                        res[i, j] = B0 * data[i, j] + B1 * data[i - 1, j] + B2 * data[i - 2, j] + B3 * data[i - 3, j]
                            - A1 * res[i - 1, j] - A2 * res[i - 2, j] - A3 * res[i - 3, j];
                    // writer.Write(res[i, j]);
                    if (i >= size)
                    {
                        bfBuffer[data.M-i-1, j] = res[i, j];
                        bfBuffer[ data.M-i+ 2, j] = data[i, j];
                    }   
                }
                
            }
           // writer.Close(); 
            return res;
        }

    }
}
