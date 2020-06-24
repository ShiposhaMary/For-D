using System.IO;
using System.Configuration;
using System;

namespace For_D
{
    public partial class Matrix
    {
        public static double[,] bfBuffer;
        public static double A1;
        public static double A2;
        public static double A3;
        public static double B0;
        public static double B1;
        public static double B2;
        public static double B3;
        public static Matrix ButterworthFilter(Matrix data)
        {
            int size = data.M - 3;
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
                    if (i >= size)
                    {
                        bfBuffer[data.M-i-1, j] = res[i, j];
                        bfBuffer[ data.M-i+ 2, j] = data[i, j];
                    }   
                }
                
            } 
            return res;
        }

    }
}
