using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_D
{
    public partial class Form1 : Form
    {
        CancellationTokenSource tokenSource;
        CancellationToken cancellationToken;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {   Matrix.A1 = double.Parse(textBox1.Text);
            Matrix.A2 = double.Parse(textBox2.Text);
            Matrix.A3 = double.Parse(textBox3.Text);
            Matrix.B0 = double.Parse(textBox4.Text);
            Matrix.B1 = double.Parse(textBox5.Text);
            Matrix.B2 = double.Parse(textBox6.Text);
            Matrix.B3 = double.Parse(textBox7.Text);
            Program.source = textBox8.Text.ToString();
            Program.resultDerictory = textBox9.Text.ToString();
            Matrix.matrixM = int.Parse(textBox10.Text);
            Matrix.matrixN = int.Parse(textBox11.Text);
            Program.sizeRes = int.Parse(textBox12.Text);
            tokenSource = new CancellationTokenSource();
            cancellationToken = tokenSource.Token;
           await Task.Run(()=> Program.Run(cancellationToken ),cancellationToken);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }
    }
}
