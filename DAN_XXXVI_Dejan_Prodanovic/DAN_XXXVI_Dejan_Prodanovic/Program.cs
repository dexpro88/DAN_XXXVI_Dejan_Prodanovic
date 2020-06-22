using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXVI_Dejan_Prodanovic
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThreads mt = new MyThreads();
            mt.InitializeMatrix(20,20);
            mt.GenerateRandomNumbers();

            foreach (var item in mt.randomNumbers)
            {
                Console.WriteLine(item);
            }

            //mt.PopulateMatrix();
            //for (int i = 0; i < mt.m; i++)
            //{
            //    for (int j = 0; j < mt.n; j++)
            //    {
            //        Console.Write(mt.matrix[i, j]+" ");
            //    }
            //    Console.WriteLine();
            //}
            Console.ReadLine();
        }
    }
}
