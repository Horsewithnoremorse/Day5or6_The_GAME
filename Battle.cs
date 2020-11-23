using System;
using System.Collections.Generic;
using System.Text;

namespace Day5or6_The_GAME
{
    public class Battle
    {
        public List<string> names;
        public void JustDoSomething()
        {
            Squad HighElves = GetSquad("HighElves", names);
            Squad WoodElves = GetSquad("WoodElf", names);
            Squad MountainOrks = GetSquad("MountainOrks", names);
            Squad SaromanOrks = GetSquad("SaromanOrks", names);

            Fraction Elves = new Fraction() { FractionName = "Elves" };
            Elves.FractionSquads = new List<Squad>();
            Elves.FractionSquads.Add(HighElves);
            Elves.FractionSquads.Add(WoodElves);

            Fraction Orks = new Fraction() { FractionName = "Orks" };
            Orks.FractionSquads = new List<Squad>();
            Orks.FractionSquads.Add(MountainOrks);
            Orks.FractionSquads.Add(SaromanOrks);

            Elves.GetInfo();
            Orks.GetInfo();
        }
        public static Squad GetSquad(string name, List<string> names)
        {
            Squad squad = new Squad() { SquadName = name };
            squad.SquadFighters = new List<Fighter>();
            squad.FighterNames = names;
            squad.AddFighters();
            return squad;
        }
    }
}
