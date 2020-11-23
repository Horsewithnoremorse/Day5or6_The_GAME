using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Day5or6_The_GAME
{
    public class TxtReader
    {
        static string path = @"C:\Users\milto\source\repos\Day5or6_The_GAME\Names.txt";
        static string line;
        public List<string> names = new List<string>();
        public void ReadTxT()
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    names.Add(line);
                }
            }
        }

        
            
    }
}