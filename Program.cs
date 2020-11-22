using System;
using System.IO;
using System.Collections.Generic;

namespace Day5or6_The_GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> names = new List<string> ();

            string path = @"C:\Users\milto\source\repos\Day5or6_The_GAME\Names.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    names.Add(line);
                    //Console.WriteLine(names[index]);
                    index++;
                }
            }

            List<Fighter> fighters = new List<Fighter>();
            foreach (string nameFighter in names)
            {
                fighters.Add(new Fighter(nameFighter));
            }
            for (int i = 0; i < names.Count; i++)
            {
                //fighters[i].GetInfo();
            }

            Squad HighElves = new Squad();
            HighElves.SquadFighters = new List<Fighter>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(names.Count);
                HighElves.SquadFighters.Add(new Fighter(names[index]));
                Console.WriteLine(HighElves.SquadFighters[i].Name);
            }


        }
    }
}
