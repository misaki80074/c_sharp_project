using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multidimensional_Arrarys
{
    internal class Calcu
    {
        int[,] C = new int[2,2];
        public int[,] Add(int[,] a, int[,] b)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    C[x, y] = a[x, y] + b[x, y];
                }
            }
            return C;
            
        }

        public int[,] Subtract(int[,] a, int[,] b)
        {
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    C[x, y] = a[x, y] - b[x, y];
                }
            }
            return C;
        }

        public int[,] Multiply(int[,] a, int[,] b)
        {
            for(int x = 0;x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    C[x, y] = a[x, 0] * b[0, y] + a[x, 1] * b[1, y];
                }
            }
            return C;
        }
    }
}
