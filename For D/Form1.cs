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
            
            Matrix matrix=Matrix.Reading( @"C:\Work\04-06-2020_15-56-01\1232042816.17.stage0");
            var ph = Matrix.MatrixSeparation(matrix);
            var ph1 = ph.x;
            var ph2 = ph.y;
            var ph3 = ph.z;
            var df = Matrix.DemodulRefl(ph1, ph2, ph3);
            for (int j = 0; j < df.M; j++)
            {
                //chart1.Series[0].Points.AddXY(j, ph1[0,j]);
                //chart1.Series[1].Points.AddXY(j, ph2[0,j]);
                //chart1.Series[2].Points.AddXY(j, ph3[0,j]);
                chart1.Series[3].Points.AddXY(j, df[j, 0]);
            }
            
        }
    }
}
