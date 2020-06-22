using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXVI_Dejan_Prodanovic
{
    class MyThreads
    {
        public int[,] matrix;
        public List<int> randomNumbers = new List<int>();
        public int m, n;
        Random rnd = new Random();
        readonly object listLock = new object();

        public void InitializeMatrix(int m, int n)
        {
            Thread.Sleep(1);
            lock (listLock)
            {
                matrix = new int[m, n];
                this.m = m;
                this.n = n;
                Monitor.Pulse(listLock);
                
                while (randomNumbers.Count < m * n)
                {
                    Monitor.Wait(listLock);
                }
                PopulateMatrix();
            }
           
        }

        public void GenerateRandomNumbers()
        {
            lock (listLock)
            {
              
                Monitor.Wait(listLock, Timeout.Infinite);
                for (int i = 0; i < matrix.Length; i++)
                {
                    randomNumbers.Add(rnd.Next(10, 100));
                }
                
                Monitor.Pulse(listLock);
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

        public void WriteOddNumbersToFile()
        {
            int[] arr = new int[m*n];
            int counter = 0;

            if (File.Exists("../../OddNumbers.txt"))
            {
                System.IO.File.WriteAllText(@"../../OddNumbers.txt", string.Empty);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] % 2 != 0)
                    {
                        arr[counter++] = (matrix[i, j]);
                    }
                }
            }
            StreamWriter sw = File.AppendText("../../OddNumbers.txt");
            for (int i = 0; i < counter; i++)
            {  
               sw.WriteLine(arr[i]);               
            }
            sw.Close();
        }
    }
}
