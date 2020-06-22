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
            mt.InitializeMatrix();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(mt.matrix[i,j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
