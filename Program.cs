using System;
using System.IO;
using System.Collections.Generic;

namespace Day5or6_The_GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[10];

            string path = @"C:\Users\milto\source\repos\Day5or6_The_GAME\Names.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    names[index] = line;
                    Console.WriteLine(names[index]);
                    index++;
                }
            }
            List<Fighter> fighters = new List<Fighter>();

            foreach (string nameFighter in names)
            {
                //nyashok.FoodsInFridge.Add(new Food() { Name = "Fish", Weight = 200, Price = 50 });
                fighters.Add(new Fighter(nameFighter));
            }
            fighters[0].GetInfo;

        }
    }
}
