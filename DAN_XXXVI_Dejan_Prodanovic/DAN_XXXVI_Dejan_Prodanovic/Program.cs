using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXVI_Dejan_Prodanovic
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThreads mt = new MyThreads();
            //mt.InitializeMatrix(20,20);
            //mt.GenerateRandomNumbers();

            Thread t1 = new Thread(()=>mt.InitializeMatrix(20,20));
            Thread t2 = new Thread(mt.GenerateRandomNumbers);

            t2.Start();
            t1.Start();
            
            t1.Join();
            t2.Join();
            for (int i = 0; i < mt.m; i++)
            {
                for (int j = 0; j < mt.n; j++)
                {
                    Console.Write(mt.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            mt.WriteOddNumbersToFile();
            Console.ReadLine();
        }
    }
}
