using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXVI_Dejan_Prodanovic
{
    class MyThreads
    {
        public int[,] matrix;
        public List<int> randomNumbers = new List<int>();
        public int m, n;
        Random rnd = new Random();

        public void InitializeMatrix(int m, int n)
        {
            matrix = new int[m, n];
            this.m = m;
            this.n = n;
        }

        public void GenerateRandomNumbers()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                randomNumbers.Add(rnd.Next(10,100));
            }
        }

        public void PopulateMatrix()
        {
            int counter = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = randomNumbers[counter++];
                }
            }
        }
    }
}
