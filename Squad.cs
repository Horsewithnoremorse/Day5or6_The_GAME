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
        public void AddFighters(int squadSize, int heroNumbers)
        {
            SquadFighters = new List<Fighter>();
            Random rand = new Random();
            if (squadSize < heroNumbers) { heroNumbers = squadSize; }

            for (int i = 0; i < squadSize; i++)
            {
                SquadFighters.Add(new Fighter(FighterNames[rand.Next(FighterNames.Count)]));
            }

            List<int> indexList = new List<int>();
            indexList.Add(rand.Next(FighterNames.Count));
            int index;
            for (int j = 0; j < heroNumbers && indexList.Count < heroNumbers; j++)
            {
                index = rand.Next(FighterNames.Count);
                for (int i = 0; i < indexList.Count; i++)
                {

                    if (index == indexList[i])
                    {
                        Random rand1 = new Random();
                        index = rand1.Next(FighterNames.Count);
                        i = 0;
                    }
                }
                indexList.Add(index);
            }
            for (int i = 0; i < indexList.Count; i++) 
            {
                int j = i;
                while (j >= Abilities.Count)
                {
                    j -= Abilities.Count;
                }
                SquadFighters[indexList[i]].Ability = Abilities[j];
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
