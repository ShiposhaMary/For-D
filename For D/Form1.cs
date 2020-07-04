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
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConfigurationManager.RefreshSection("appSettings");

            textBox1.Text = ConfigurationManager.AppSettings["A1"];
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = ConfigurationManager.AppSettings["A2"];
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = ConfigurationManager.AppSettings["A3"];
            textBox3.ForeColor = Color.Gray;
            textBox4.Text = ConfigurationManager.AppSettings["B0"];
            textBox4.ForeColor = Color.Gray;
            textBox5.Text = ConfigurationManager.AppSettings["B1"];
            textBox5.ForeColor = Color.Gray;
            textBox6.Text = ConfigurationManager.AppSettings["B2"];
            textBox6.ForeColor = Color.Gray;
            textBox7.Text = ConfigurationManager.AppSettings["B3"];
            textBox7.ForeColor = Color.Gray;
            textBox8.Text = ConfigurationManager.AppSettings["sourceDirectory"];
            textBox8.ForeColor = Color.Gray;
            textBox9.Text = ConfigurationManager.AppSettings["resultDirectory"];
            textBox9.ForeColor = Color.Gray;
            textBox10.Text = ConfigurationManager.AppSettings["matrixM"];
            textBox10.ForeColor = Color.Gray;
            textBox11.Text = ConfigurationManager.AppSettings["matrixN"];
            textBox11.ForeColor = Color.Gray;
            textBox12.Text = ConfigurationManager.AppSettings["sizeRes"];
            textBox12.ForeColor = Color.Gray;

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection()
            {
                ConfigurationManager.AppSettings["A1"],
               ConfigurationManager.AppSettings["A2"],
                ConfigurationManager.AppSettings["A3"],
                ConfigurationManager.AppSettings["B0"],
                ConfigurationManager.AppSettings["B1"],
               ConfigurationManager.AppSettings["B2"],
                ConfigurationManager.AppSettings["B3"],
               ConfigurationManager.AppSettings["matrixM"],
               ConfigurationManager.AppSettings["matrixN"],
               ConfigurationManager.AppSettings["sourceDirectory"],
               ConfigurationManager.AppSettings["resultDirectory"],
               ConfigurationManager.AppSettings["sizeRes"]
            };
            textBox1.AutoCompleteCustomSource = auto;
            textBox2.AutoCompleteCustomSource = auto;
            textBox3.AutoCompleteCustomSource = auto;
            textBox4.AutoCompleteCustomSource = auto;
            textBox5.AutoCompleteCustomSource = auto;
            textBox6.AutoCompleteCustomSource = auto;
            textBox7.AutoCompleteCustomSource = auto;
            textBox8.AutoCompleteCustomSource = auto;
            textBox9.AutoCompleteCustomSource = auto;
            textBox10.AutoCompleteCustomSource = auto;
            textBox11.AutoCompleteCustomSource = auto;
            textBox12.AutoCompleteCustomSource = auto;
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
            textBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox8.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox9.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox9.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox10.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox10.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox11.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox11.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox12.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox12.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }

        private async void button1_Click(object sender, EventArgs e)
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
           
            tokenSource = new CancellationTokenSource();
            cancellationToken = tokenSource.Token;
           await Task.Run(()=> Program.Run(cancellationToken ),cancellationToken);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox3.ForeColor = Color.Black;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox4.ForeColor = Color.Black;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = null;
            textBox5.ForeColor = Color.Black;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = null;
            textBox6.ForeColor = Color.Black;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = null;
            textBox7.ForeColor = Color.Black;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = null;
            textBox8.ForeColor = Color.Black;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox9.Text = null;
            textBox9.ForeColor = Color.Black;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBox10.Text = null;
            textBox10.ForeColor = Color.Black;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox11.Text = null;
            textBox11.ForeColor = Color.Black;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox12.Text = null;
            textBox12.ForeColor = Color.Black;
        }
    }
}
