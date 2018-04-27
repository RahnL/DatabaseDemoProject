using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Microsoft.Exten­sions.Configuration;

namespace FileAndLoad
{
    class Program
    {
        static string SampleFile = "C:\\Temp\\SuperDateSample.txt";
        static IConfiguration Configuration { get; set; }
        static string connString;

        static void Main(string[] args)
        {
            LoadConfiguration();

            GenerateTestFile();

            LoadNaiveTest();
            LoadTypeTest();
        }

        private static void LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsetting.json");

            Configuration = builder.Build();
            connString = Configuration["database"].ToString();
        }

        private static void LoadNaiveTest()
        {
            Console.WriteLine("Starting Naive Load Test");

            Stopwatch stopwatchNaive = new Stopwatch();
            stopwatchNaive.Start();
            NaiveLoad nl = new NaiveLoad(connString);
            nl.LoadFileByRecord(SampleFile);
            stopwatchNaive.Stop();

            Console.WriteLine("Naive Load took {0} milliseconds.", stopwatchNaive.ElapsedMilliseconds);
        }

        private static void LoadTypeTest()
        {
            Console.WriteLine("Starting Type Load Test");

            Stopwatch stopwatchType= new Stopwatch();
            stopwatchType.Start();
            TypeLoad nl = new TypeLoad(connString);
            nl.LoadByType(SampleFile);
            stopwatchType.Stop();

            Console.WriteLine("Type Load took {0} milliseconds.", stopwatchType.ElapsedMilliseconds);
        }
        static void GenerateTestFile()
        {
            if (File.Exists(SampleFile))
                return;

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
