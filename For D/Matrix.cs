using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_D
{
    public partial class Matrix
    {
        private double[,] data;
        private int m;
        public int M { get => this.m; }
        private int n;
        public int N { get => this.n; }
        public Matrix(int m,int n )
        {
            this.m = m;
            this.n = n;
            data = new double[m, n];
        }

        public double this[int x, int y]
        {
            get { return data[x, y]; }
            set { data[x, y] = value; }
        }
        public void ActionOverMatrix(Action<int,int>func)
        {
            for (var i=0; i < this.M;i++)
            {
                for (var j = 0; j < this.N; j++) func(i, j);
            }

        }
        public static Matrix operator*(Matrix data1,Matrix data2)
        {
            if (data1.M != data2.M|| data1.N != data2.N )
            { throw new ArgumentException("matrixes has different size"); }
            var mat = new Matrix(data1.M, data1.N);
            mat.ActionOverMatrix((i, j) =>
            {
                
                    mat[i, j] = data1[i, j] * data2[i, j];
                
            });
            return mat;
        }
        public static Matrix operator *(Matrix data, double d)
        {
           
            var mat = new Matrix(data.M, data.N);
            mat.ActionOverMatrix((i, j) =>
            {
                    mat[i, j] = data[i, j] * d;
               
            });
            return mat;
        }
        public static Matrix operator -(Matrix data1, Matrix data2)
        {
            if (data1.M != data2.M || data1.N != data2.N)
            { throw new ArgumentException("matrixes has different size"); }
            var mat = new Matrix(data1.M, data1.N);
            mat.ActionOverMatrix((i, j) =>
            {
                //for (var x = 0; x < data1.M; x++)
               // {
                    mat[i, j] = data1[i, j] -data2[i, j];
               // }
            });
            return mat;
        }
        public static Matrix operator +(Matrix data1, Matrix data2)
        {
            if (data1.M != data2.M || data1.N != data2.N)
             throw new ArgumentException("matrixes has different size"); 
            var mat = new Matrix(data1.M, data1.N);
            mat.ActionOverMatrix((i, j) =>
            {
               // for (var x = 0; x < data1.M; x++)
               // {
                    mat[i, j] = data1[i, j] + data2[i, j];
               // }
            });
            return mat;
        }
        public static Matrix Cut(Matrix data)
        {
            Matrix res = new Matrix(data.M - 1, data.N);
            for (int i = 0; i < data.M - 1; i++)
            {
                for (int j = 0; j < data.N; j++) res[i, j] = data[i, j];
            }
            return res;
        }
        public static Matrix Diff(Matrix data)
        {
            Matrix res = new Matrix(data.M, data.N);
            for (int i = 0; i < data.M; i++)
            {
                for (int j = 0; j < data.N; j++)
                {
                    if (i == data.M - 1) res[i, j] = 0;
                    else res[i, j] = data[i + 1, j] - data[i, j];
                }
            }
            return res;
        }
        public static Matrix Rev(Matrix data)
        {
            Matrix res = new Matrix(data.M, data.N);
            for (int i = 0; i < data.M; i++)
            {
                for (int j = 0; j < data.N; j++)
                { if (data[i, j] == 0) throw new ArgumentException("/0");
                    res[i, j] = 1 / data[i, j]; }
            }
            return res;
        }
        public static Matrix CumSum(Matrix data)
        {
            Matrix res = new Matrix(data.M, data.N);
            for (int i = 0; i < data.M; i++)
            {
                for (int j = 0; j < data.N; j++)
                {
                    if (i == 0) res[i, j] = data[i, j];
                    else res[i, j] = res[i - 1, j] + data[i, j];
                }
            }
            return res;
        }
        public static (Matrix x,Matrix y,Matrix z) MatrixSeparation(Matrix data)
        {
            Matrix res1 = new Matrix(data.M/3, data.N);
            Matrix res2 = new Matrix(data.M/3, data.N);
            Matrix res3 = new Matrix(data.M/3, data.N);
            int z = 0;
            for (int i = 0; i < data.M-3; i+=3)
            {
                for (int j = 0; j < data.N; j++)
                {
                    res1[z, j] = data[i, j];
                    res2[z, j] = data[i+1, j];
                    res3[z, j] = data[i+2, j];
                    
                }
                z++;
            }
            if (res1.M != res2.M || res1.M != res3.M)
                throw new ArgumentException("MatrixSeparation ended unsuccessfully");
            return (res1, res2, res3);
        }

    }
}
