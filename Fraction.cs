using System;
using System.Collections.Generic;
using System.Text;

namespace Day5or6_The_GAME
{
    public class Fraction
    {
        public string FractionName { get; set; }
        public List<Squad> FractionSquads { get; set; }
        public void AddSquad()
        {
            FractionSquads = new List<Squad>();
            FractionSquads.Add(new Squad());
        }
        public void GetInfo()
        {
            Console.WriteLine($"\nФракция: {FractionName}");
            for (int i = 0; i < FractionSquads.Count; i++)
            {
                Console.WriteLine($"\nОтряд {FractionSquads[i].SquadName}: ");
                for (int j = 0; j < FractionSquads[i].SquadFighters.Count; j++)
                {
                    FractionSquads[i].SquadFighters[j].GetInfo();
                }
            }

        }
    }
}
