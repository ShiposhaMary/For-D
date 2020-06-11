using System.IO;
using System.Configuration;

namespace For_D
{
    public partial class Matrix
    { 
        public static Matrix ButterworthFilter(Matrix data)
        {
          
            double A1 = double.Parse(ConfigurationManager.AppSettings["A1"]);
            double A2 = double.Parse(ConfigurationManager.AppSettings["A2"]);
            double A3 = double.Parse(ConfigurationManager.AppSettings["A3"]);
            double B0 = double.Parse(ConfigurationManager.AppSettings["B0"]);
            double B1 = double.Parse(ConfigurationManager.AppSettings["B1"]);
            double B2 = double.Parse(ConfigurationManager.AppSettings["B2"]);
            double B3 = double.Parse(ConfigurationManager.AppSettings["B3"]);
            string path= @"C:\Work\For D\For D\ButterworfRes\"+ Path.GetFileNameWithoutExtension( Matrix.fileName)+".bin";
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
            Matrix res = new Matrix(data.M, data.N);
            for (int i = 3; i < data.M; i++)
            {
                for (int j = 0; j < data.N; j++)
                {
                    res[i, j] = B0 * data[i, j] + B1 * data[i - 1, j] + B2 * data[i - 2, j] + B3 * data[i - 3, j] 
                        - A1 * res[i - 1, j] - A2 * res[i - 2, j] - A3 * res[i - 3, j];
                    writer.Write(res[i, j]);
                }
            }
            writer.Close(); 
            return res;
        }

    }
}
