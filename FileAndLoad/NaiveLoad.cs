using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace FileAndLoad
{
    public class NaiveLoad
    {
        public void LoadFile(string FileName)
        {
            //TODO Dataase load
            using (StreamReader r = new StreamReader(FileName))
            {
                while (r.Peek()!=-1)
                {
                    string[] line = r.ReadLine().Split(',');
                }
            }

        }
    }
}
