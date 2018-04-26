using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace FileAndLoad
{
    class Program
    {
        static string SampleFile = "C:\\Temp\\SuperDateSample.txt";

        static void Main(string[] args)
        {
            GenerateTestFile();

            LoadNaiveTest();
        }

        private static void LoadNaiveTest()
        {
            Console.WriteLine("Starting Naive Load Test");

            Stopwatch stopwatchNaive = new Stopwatch();
            stopwatchNaive.Start();
            NaiveLoad nl = new NaiveLoad();
            nl.LoadFile(SampleFile);
            stopwatchNaive.Stop();

            Console.WriteLine("Naive Load took {0} milliseconds.", stopwatchNaive.ElapsedMilliseconds);
        }

        static void GenerateTestFile()
        {
            int numRecords = 500000;    //Over 50MB file. Play with it to make bigger/smaller.
            
            using (StreamWriter w = new StreamWriter(SampleFile))
            {
                for (int i = 0; i < numRecords; i++)
                {
                    w.WriteLine(new SuperDataElement().ToString());
                }
            }
        }

        
    }
}
