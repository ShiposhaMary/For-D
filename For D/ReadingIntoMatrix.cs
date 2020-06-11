using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_D
{
    public partial class Matrix
    {
        public static string fileName;
        public static Matrix Reading(string path)
        {
        fileName = path;
        BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open));
        var a = reader.ReadUInt32();
        reader.ReadBytes((int) a);
         var c = (int)reader.ReadUInt32();

        Matrix matrix = new Matrix(5952,103);
            for (int j = 0; j < 103; j++)
            {
                for (int i = 0; i <5952; i++)
                {
                    matrix[i, j] = (int)reader.ReadUInt16();
                }
            }
            reader.Close();
            return matrix;
            
        }

    }
}

    

