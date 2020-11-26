using System;
using System.Collections.Generic;
using System.Text;

namespace Day5or6_The_GAME
{
    public class Squad  
    {
        List<string> Abilities = new List<string>
        {
            "Berserk",
            "Priest",
            "Mage",
            "Warior"
        };
        public List<string> FighterNames { get; set; }
        public string SquadName { get; set; }
        public List<Fighter> SquadFighters { get; set; }
        public void AddFighters(int squadSize)
        {
            SquadFighters = new List<Fighter>();
            Random rand = new Random();
            for (int i = 0; i < squadSize; i++)
            {
                int index = rand.Next(FighterNames.Count);
                SquadFighters.Add(new Fighter(FighterNames[index]));
            }
            int a = rand.Next(FighterNames.Count);
            int b = rand.Next(FighterNames.Count);
            int c = rand.Next(FighterNames.Count);
            int d = rand.Next(FighterNames.Count);
            while (a == b && b == c && c == d && a == c && a == d && b == d)
            {
                a = rand.Next(FighterNames.Count);
                b = rand.Next(FighterNames.Count);
                c = rand.Next(FighterNames.Count);
                d = rand.Next(FighterNames.Count);
            }
            SquadFighters[a].Ability = Abilities[0];
            SquadFighters[b].Ability = Abilities[1];
            SquadFighters[c].Ability = Abilities[2];
            SquadFighters[d].Ability = Abilities[3];

        }
        public void GetInfo()
        {
            Console.WriteLine($"В отряд {SquadName} входят:");
            for (int i = 0; i < SquadFighters.Count; i++)
            {
                SquadFighters[i].GetInfo();
            }
        }
    }
}
