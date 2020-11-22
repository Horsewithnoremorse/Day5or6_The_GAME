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

            //List<Fighter> fighters = new List<Fighter>();
            //foreach (string nameFighter in names)
            //{
            //    fighters.Add(new Fighter(nameFighter));
            //}
            //for (int i = 0; i < names.Count; i++)
            //{
            //    fighters[i].GetInfo();
            //}

            Squad HighElves = new Squad() { SquadName = "HighElves" };
            HighElves.SquadFighters = new List<Fighter>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(names.Count);
                HighElves.SquadFighters.Add(new Fighter(names[index]));
            }

            Squad WoodElves = new Squad() { SquadName = "WoodElf" };
            WoodElves.SquadFighters = new List<Fighter>();
            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(names.Count);
                WoodElves.SquadFighters.Add(new Fighter(names[index]));
            }

            Squad MountainOrks = new Squad() { SquadName = "MountainOrks" };
            MountainOrks.SquadFighters = new List<Fighter>();
            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(names.Count);
                MountainOrks.SquadFighters.Add(new Fighter(names[index]));
            }

            Squad SaromanOkrs = new Squad() {SquadName = "SaromanOkrs"};
            SaromanOkrs.SquadFighters = new List<Fighter>();
            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(names.Count);
                SaromanOkrs.SquadFighters.Add(new Fighter(names[index]));
            }

            Fraction Elves = new Fraction() { FractionName = "Elves" };
            Elves.FractionSquads = new List<Squad>();
            Elves.FractionSquads.Add(HighElves);
            Elves.FractionSquads.Add(WoodElves);

            Fraction Orks = new Fraction() { FractionName = "Orks" };
            Orks.FractionSquads = new List<Squad>();
            Orks.FractionSquads.Add(MountainOrks);
            Orks.FractionSquads.Add(SaromanOkrs);

            Elves.GetInfo();
            Orks.GetInfo();

        }
    }
}
