using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_D
{
    public partial class Matrix
    {
        public static Matrix DemodulRefl(Matrix y1,Matrix y2,Matrix y3)
        {
           Matrix bias= y1 + y2 + y3;
           Matrix sm1=y1-bias*0.333;
           Matrix sm2 = y2 - bias * 0.333;
           Matrix sm3 = y3 - bias * 0.333;
           Matrix scale = (sm1 * sm1 + sm2 * sm2 + sm3 * sm3)*1.157;
            for (int i=0;i<scale.M;i++)
            {
                for (int j=0;j<scale.N;j++)
                {
                    if (scale[i, j] < 0.0001) scale[i, j] = 0.0001;
                }
            }
            Matrix si = sm1 * (-0.5) + sm2 + sm3 * (-0.5);
            Matrix sq = sm1 * (-0.866) + sm3 * (-0.866);
           
            Matrix s = (si * Diff(sq) - sq * Diff(si) )* Rev(scale);
            return CumSum(s);

        }

    }
}
