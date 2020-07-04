using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection()
            {
                double.Parse(ConfigurationManager.AppSettings["A1"]).ToString(),
                double.Parse(ConfigurationManager.AppSettings["A2"]).ToString(),
                double.Parse(ConfigurationManager.AppSettings["A3"]).ToString(),
                double.Parse(ConfigurationManager.AppSettings["B0"]).ToString(),
                double.Parse(ConfigurationManager.AppSettings["B1"]).ToString(),
                double.Parse(ConfigurationManager.AppSettings["B2"]).ToString(),
                double.Parse(ConfigurationManager.AppSettings["B3"]).ToString(),
                int.Parse(ConfigurationManager.AppSettings["matrixM"]).ToString(),
                int.Parse(ConfigurationManager.AppSettings["matrixN"]).ToString()
            };
            textBox1.AutoCompleteCustomSource = auto;
            textBox2.AutoCompleteCustomSource = auto;
            textBox3.AutoCompleteCustomSource = auto;
            textBox4.AutoCompleteCustomSource = auto;
            textBox5.AutoCompleteCustomSource = auto;
            textBox6.AutoCompleteCustomSource = auto;
            textBox7.AutoCompleteCustomSource = auto;
            textBox10.AutoCompleteCustomSource = auto;
            textBox11.AutoCompleteCustomSource = auto;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox10.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox10.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox11.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox11.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {  
            if (checkBox1.Checked == true)
            {
                Matrix.A1 = double.Parse(ConfigurationManager.AppSettings["A1"]);
                Matrix.A2 = double.Parse(ConfigurationManager.AppSettings["A2"]);
                Matrix.A3 = double.Parse(ConfigurationManager.AppSettings["A3"]);
                Matrix.B0 = double.Parse(ConfigurationManager.AppSettings["B0"]);
                Matrix.B1 = double.Parse(ConfigurationManager.AppSettings["B1"]);
                Matrix.B2 = double.Parse(ConfigurationManager.AppSettings["B2"]);
                Matrix.B3 = double.Parse(ConfigurationManager.AppSettings["B3"]);
                Matrix.matrixM = int.Parse(ConfigurationManager.AppSettings["matrixM"]);
                Matrix.matrixN = int.Parse(ConfigurationManager.AppSettings["matrixN"]);
                Program.resultDerictory = ConfigurationManager.AppSettings.Get("resultDirectory");
                Program.source = ConfigurationManager.AppSettings.Get("sourceDirectory");
                Program.sizeRes = int.Parse(ConfigurationManager.AppSettings["sizeRes"]);

            }
            else
            {
                Matrix.A1 = double.Parse(textBox1.Text);
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
            }
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
