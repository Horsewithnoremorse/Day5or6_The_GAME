using System;
using System.Collections.Generic;
using System.Text;

namespace Day5or6_The_GAME
{
    public class Squad  
    {
        public List<string> FighterNames { get; set; }
        public string SquadName { get; set; }
        public List<Fighter> SquadFighters { get; set; }
        public void AddFighters()
        {
            SquadFighters = new List<Fighter>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(FighterNames.Count);
                SquadFighters.Add(new Fighter(FighterNames[index]));
            }
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
