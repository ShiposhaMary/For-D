using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           Matrix.bfBuffer = new double[7, 103];
           Matrix.resBuffer = new Matrix(600,103);
            string[] source = Directory.GetFiles(@"C:\Work\duble\");
            foreach (var file in source)
            {
                Matrix matrix = Matrix.Reading(file);
                var ph = Matrix.MatrixSeparation(matrix);
                var ph1 = ph.x;
                var ph2 = ph.y;
                var ph3 = ph.z;
                var df = Matrix.DemodulRefl(ph1, ph2, ph3);
                var bf = Matrix.ButterworthFilter(df);
                var sm = Matrix.Resampling(bf);
                for (int j = 0; j < 1984; j++)
                {
                    // chart1.Series[0].Points.AddXY(j, matrix[0,j]);
                    chart1.Series[1].Points.AddXY(j, df[j, 0]);
                    chart1.Series[2].Points.AddXY(j, bf[j, 0]);
                }
                for (int j = 0; j <sm.M; j++)
                    chart2.Series[0].Points.AddXY(j, sm[j, 0]);
               
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
