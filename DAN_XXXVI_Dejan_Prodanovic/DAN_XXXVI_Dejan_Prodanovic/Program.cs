﻿using System;
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
           

            Thread t1 = new Thread(()=>mt.InitializeMatrix(100,100));
            Thread t2 = new Thread(mt.GenerateRandomNumbers);

            t2.Start();
            t1.Start();
            
            t1.Join();
            t2.Join();
           

            Thread t3 = new Thread(mt.WriteOddNumbersToFile);
            Thread t4 = new Thread(mt.ReadOddNumbersFromFile);
            t4.Start();
            t3.Start();
          
            t3.Join();
            t4.Join();
            Console.ReadLine();
        }
    }
}
