using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace For_D
{
    public partial class Matrix
    {
        public static int matrixM;
        public static int matrixN;

        public static Matrix Reading(string filename)
        {
            Thread.Sleep(100);  
            BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open));
            var a = reader.ReadUInt32();
            reader.ReadBytes((int)a);
            var c = (int)reader.ReadUInt32();

            Matrix matrix = new Matrix(matrixM, matrixN);
            for (int j = 0; j < matrixN; j++)
            {
                for (int i = 0; i < matrixM; i++)
                {
                    matrix[i, j] = (int)reader.ReadUInt16();

                }
            }
            reader.Close();
            return matrix;    
        }

    }
}

    

