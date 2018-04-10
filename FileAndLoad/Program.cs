using System;
using System.Collections.Generic;
using System.IO;

namespace FileAndLoad
{
    class Program
    {
        static string SampleFile = "C:\\Temp\\SuperDateSample.txt";

        static void Main(string[] args)
        {
            GenerateTestFile();
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
