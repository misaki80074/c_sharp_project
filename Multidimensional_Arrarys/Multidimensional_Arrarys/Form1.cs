using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multidimensional_Arrarys
{
    public partial class Form1 : Form
    {
        public int[,] result = new int[2,2];
        int[,] A = new int[2,2];
        int[,] B = new int[2,2];
        Calcu calcu = new Calcu();
        public Form1()
        {
            InitializeComponent();
        }

        private void A_1_TextChanged_1(object sender, EventArgs e)
        {
            A[0, 0] = int.Parse(A_1.Text);
        }

        private void A_2_TextChanged_1(object sender, EventArgs e)
        {
            A[0, 1] = int.Parse(A_2.Text);
        }

        private void A_3_TextChanged_1(object sender, EventArgs e)
        {
            A[1, 0] = int.Parse(A_3.Text);
        }

        private void A_4_TextChanged_1(object sender, EventArgs e)
        {
            A[1, 1] = int.Parse(A_4.Text);
        }

        private void B_1_TextChanged_1(object sender, EventArgs e)
        {
            B[0, 0] = int.Parse(B_1.Text);
        }

        private void B_2_TextChanged_1(object sender, EventArgs e)
        {
            B[0, 1] = int.Parse(B_2.Text);
        }

        private void B_3_TextChanged_1(object sender, EventArgs e)
        {
            B[1, 0] = int.Parse(B_3.Text);
        }

        private void B_4_TextChanged_1(object sender, EventArgs e)
        {
            B[1, 1] = int.Parse(B_4.Text);
        }

        private void OutputResult()
        {
            C_1.Text = result[0, 0].ToString();
            C_2.Text = result[0, 1].ToString();
            C_3.Text = result[1, 0].ToString();
            C_4.Text = result[1, 1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <=1; i++)
            {
                for (int j = 0; j <=1; j++)
                {
                    result = calcu.Add(A, B);
                }
            }
            OutputResult();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    result =calcu.Subtract(A, B);
                }
            }
            OutputResult();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    result = calcu.Multiply(A, B);
                }
            }
            OutputResult();
        }
    }
}
