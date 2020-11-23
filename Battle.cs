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

            Fraction Elves = GetFraction("Elves");
            Elves.FractionSquads.Add(HighElves);
            Elves.FractionSquads.Add(WoodElves);

            Fraction Orks = GetFraction("Orks");
            Orks.FractionSquads.Add(MountainOrks);
            Orks.FractionSquads.Add(SaromanOrks);

            Elves.GetInfo();
            Orks.GetInfo();

            //вынести в отдельный метод
            Console.WriteLine("Нажми кнопку для начала PvP");
            Console.ReadKey();
            Console.WriteLine(" ");
            Random random = new Random();
            Fighter fighter1 = Elves.FractionSquads[random.Next(Elves.FractionSquads.Count)].SquadFighters[random.Next(Elves.FractionSquads[random.Next(Elves.FractionSquads.Count)].SquadFighters.Count)];
            fighter1.GetInfo();
            Fighter fighter2 = Elves.FractionSquads[random.Next(Elves.FractionSquads.Count)].SquadFighters[random.Next(Elves.FractionSquads[random.Next(Elves.FractionSquads.Count)].SquadFighters.Count)];
            fighter2.GetInfo();

            while (fighter2.Health >0 && fighter1.Health > 0)
            {
                int damage1 = random.Next(fighter1.Attack) + 1 + fighter1.Strength;
                fighter2.Health = fighter2.Health - damage1;
                Console.WriteLine($"Боец {fighter2.Name}\t получил урон {damage1} единиц от {fighter1.Name},\t здоровья осталось: {fighter2.Health} Hp");
                int damage2 = random.Next(fighter2.Attack) + 1 + fighter2.Strength;
                fighter1.Health = fighter1.Health - damage2;
                Console.WriteLine($"Боец {fighter1.Name}\t получил урон {damage2} единиц от {fighter2.Name},\t здоровья осталось: {fighter1.Health} Hp");
            }
            String Winner = fighter1.Health > fighter2.Health ? fighter1.Name : fighter2.Name;
            Console.WriteLine($"Победитель:{Winner}");
            Console.ReadKey();
        }
        public static Squad GetSquad(string name, List<string> names)
        {
            Squad squad = new Squad() { SquadName = name };
            squad.SquadFighters = new List<Fighter>();
            squad.FighterNames = names;
            squad.AddFighters();
            return squad;
        }
        public static Fraction GetFraction(string name)
        {
            Fraction fraction = new Fraction() { FractionName = name };
            fraction.FractionSquads = new List<Squad>();
            return fraction;
        }
        //2*
        //1 на 1 пвп
        //из фракции выбирается случайный отряд и из него случайный боец
        //они направляются драться друг с другом
        //бой идет по следующей логике
        //бойцы атакуют по очереди - урон расчитывается по формуле(рандом от 1 до атаки)+сила - этот урон отнимается
        //от здоровья врага.после удара пишется урон и сколько у врага хп осталось
        //бой продолжается пока 1 из бойцов не ушел в <=0 hp - выводится отчет кто победил и кто проиграл

    }
}
