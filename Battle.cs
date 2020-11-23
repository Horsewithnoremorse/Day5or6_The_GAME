using System;
using System.Collections.Generic;
using System.Text;

namespace Day5or6_The_GAME
{
     public class Battle
     {
        public List <string> names;
        public void JustDoSomething()
        {
            Squad HighElves = new Squad() { SquadName = "HighElves" };
            HighElves.SquadFighters = new List<Fighter>();
            HighElves.FighterNames = names;
            HighElves.AddFighters();


            Squad WoodElves = new Squad() { SquadName = "WoodElf" };
            WoodElves.SquadFighters = new List<Fighter>();
            WoodElves.FighterNames = names;
            WoodElves.AddFighters();

            Squad MountainOrks = new Squad() { SquadName = "MountainOrks" };
            MountainOrks.SquadFighters = new List<Fighter>();
            MountainOrks.FighterNames = names;
            MountainOrks.AddFighters();

            Squad SaromanOkrs = new Squad() { SquadName = "SaromanOkrs" };
            SaromanOkrs.SquadFighters = new List<Fighter>();
            SaromanOkrs.FighterNames = names;
            SaromanOkrs.AddFighters();

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
