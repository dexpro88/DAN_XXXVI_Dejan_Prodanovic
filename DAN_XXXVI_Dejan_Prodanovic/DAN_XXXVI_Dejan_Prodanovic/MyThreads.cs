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
        int[] arr;

        public void InitializeMatrix(int m, int n)
        {
            Thread.Sleep(1);
          
            lock (listLock)
            {
                matrix = new int[m, n];
                this.m = m;
                this.n = n;
                Console.WriteLine("Thread1 initilized matrix");
                Monitor.Pulse(listLock);
                
                while (randomNumbers.Count < m * n)
                {
                    Monitor.Wait(listLock);
                }
                PopulateMatrix();
                Console.WriteLine("Thread1 populated matrix with random numbers that Thread2 generated");
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
                Console.WriteLine("Thread2 generated 10000 random numbers");
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
           
            int counter = 0;

            if (File.Exists("../../OddNumbers.txt"))
            {
                System.IO.File.WriteAllText(@"../../OddNumbers.txt", string.Empty);
            }
            arr = new int[m * n];
            
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
            lock (listLock)
            {
                StreamWriter sw = File.AppendText("../../OddNumbers.txt");
                for (int i = 0; i < counter; i++)
                {
                    sw.WriteLine(arr[i]);
                }
                sw.Close();
                Monitor.Pulse(listLock);
            }
               
            Console.WriteLine("Thread3 wrote odd numbers to file");
        }
        public void ReadOddNumbersFromFile()
        {
            try
            {
                lock (listLock)
                {
                    while(arr==null)
                    {
                        Monitor.Wait(listLock);
                    }
                        Console.WriteLine("Thread4 reads odd numbers from a file");
                    using (StreamReader sr = new StreamReader("../../OddNumbers.txt"))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
