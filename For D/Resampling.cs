using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_D
{
    public partial class Matrix
    {
      public static  Matrix resBuffer;
        
        public static Matrix Resampling(Matrix data)
        { int z = 0;
            for (int i = 0; i < data.M-10; i+=10)
            {
                for (int j = 0; j < data.N; j++)
                {
                    resBuffer[z, j] = (data[i, j] + data[i + 1, j] + data[i + 2, j] + data[i + 3, j] +
                        data[i + 4, j] + data[i + 5, j] + data[i + 6, j] + data[i + 7, j] + data[i + 8, j] + data[i + 9, j]) / 10;

                }
                z++;
            }
            return resBuffer;
        }
    }
}
