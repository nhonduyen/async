using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetNow()
        {
            return DateTime.Now.ToString();
        }

        private double CalculateBigNumber()
        {
            double result = 0;
            for (int i = 0; i < 10000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    result += i;
                }
            }
            return result;
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            label1.Text = label2.Text = "";

            label2.Text = await Task.FromResult<string>(GetNow());
            Func<double> function = new Func<double>(() => CalculateBigNumber());
            double result = await Task.Factory.StartNew(function);
            label1.Text = result.ToString();
        }
    }
}
