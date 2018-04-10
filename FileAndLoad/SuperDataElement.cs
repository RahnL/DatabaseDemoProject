using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndLoad
{
    public class SuperDataElement
    {
        public string S1;
        public string S2;
        public DateTime Dt1;
        public DateTime Dt2;
        public int N1;
        public int N2;
        //Constuctor
        public SuperDataElement()
        {
            // A couple  strings
            this.S1 = GetRandomString(25);
            this.S2 = GetRandomString(50);

            // A couple random numbers from 1 to 100
            this.N1 = new Random().Next(0, 100);
            this.N2 = new Random().Next(0, 100);

            // 2 Random dates in the last 100 days
            this.Dt1 = DateTime.Now.AddDays(-N1);
            this.Dt2 = DateTime.Now.AddDays(-N2);
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", this.S1, this.S2, this.N1, this.N2, this.Dt1, this.Dt2);
        }
        // from https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
        private string GetRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
