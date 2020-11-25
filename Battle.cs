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

            //PvP(Elves, Orks);
            SquadVsSquad(Elves, Orks);


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
        public void PvP(Fraction fraction1, Fraction fraction2)
        {
            Console.WriteLine("Нажми кнопку для начала PvP");
            Console.ReadKey();
            Console.WriteLine(" ");
            Random random = new Random();
            Fighter fighter1 = fraction1.FractionSquads[random.Next(fraction1.FractionSquads.Count)].SquadFighters[random.Next(fraction1.FractionSquads[random.Next(fraction1.FractionSquads.Count)].SquadFighters.Count)];
            fighter1.GetInfo();
            Fighter fighter2 = fraction2.FractionSquads[random.Next(fraction2.FractionSquads.Count)].SquadFighters[random.Next(fraction2.FractionSquads[random.Next(fraction2.FractionSquads.Count)].SquadFighters.Count)];
            fighter2.GetInfo();

            while (fighter2.Health > 0 && fighter1.Health > 0)
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
        /*3 *
            стенка на стенку
            берутся по 1 рандомному отряду и ходы идут по той же логике, но по принципу 1 боец 1 отряда, 1 боец 2 отряда,
            2 боец первого отряда
            боец первого отряда бьет по следующему бьющему врагу(1 по 1 сначала) а боец второго отряда по предыдущему
            (1 по 1 сначала тоже получится), когда ударил последний боец отряда - бьет снова первый(но мёртвые не дерутся естественно)
            бой продолжается до тех пор, пока в 1 из отрядов не закончатся живые бойцы
            в отчет выводятся "герои" - живые бойцы отрядов победителей */
        public void SquadVsSquad(Fraction fraction1, Fraction fraction2)
        {
            Console.WriteLine("Нажми кнопку для начала битвы стенка на стенку");
            Console.ReadKey();
            Console.WriteLine(" ");
            Random random = new Random();
            Squad squad1 = fraction1.FractionSquads[random.Next(fraction1.FractionSquads.Count)];
            squad1.GetInfo();
            Squad squad2 = fraction2.FractionSquads[random.Next(fraction2.FractionSquads.Count)];
            squad2.GetInfo();
            int round = 1;
            int fightercount = 10;
            while (fightercount > 0)
            {
                for (int i = 0; i < fightercount; i++)
                {
                    while (squad1.SquadFighters[i].Health > 0 && squad2.SquadFighters[i].Health > 0)
                    {
                        int damage1 = random.Next(squad1.SquadFighters[i].Attack) + 1 + squad1.SquadFighters[i].Strength;
                        squad2.SquadFighters[i].Health = squad2.SquadFighters[i].Health - damage1;
                        //Console.WriteLine($"Боец {squad2.SquadFighters[i].Name}\t получил урон {damage1} единиц от {squad1.SquadFighters[i].Name},\t здоровья осталось: {squad2.SquadFighters[i].Health} Hp");
                        int damage2 = random.Next(squad2.SquadFighters[i].Attack) + 1 + squad2.SquadFighters[i].Strength;
                        squad1.SquadFighters[i].Health = squad1.SquadFighters[i].Health - damage2;
                        //Console.WriteLine($"Боец {squad1.SquadFighters[i].Name}\t получил урон {damage2} единиц от {squad2.SquadFighters[i].Name},\t здоровья осталось: {squad1.SquadFighters[i].Health} Hp");
                    }
                }
                for (int i = 0; i < squad1.SquadFighters.Count; i++)
                {
                    if (squad1.SquadFighters[i].Health <= 0)
                    {
                        squad1.SquadFighters.RemoveAt(i);
                        i--; //вообще выглядит как костыль
                    }
                }
                for (int i = 0; i < squad2.SquadFighters.Count; i++)
                {
                    if (squad2.SquadFighters[i].Health <= 0)
                    {
                        squad2.SquadFighters.RemoveAt(i);
                        i--;
                    }                    
                }
                if (squad1.SquadFighters.Count !=0 && squad2.SquadFighters.Count !=0)
                {
                    Console.WriteLine($"\nРаунд {round}\n");
                    squad1.GetInfo();
                    Console.WriteLine();
                    squad2.GetInfo();
                    round++;
                }
                fightercount = squad1.SquadFighters.Count <= squad2.SquadFighters.Count ? squad1.SquadFighters.Count : squad2.SquadFighters.Count; 
            }
            Squad Winner = squad1.SquadFighters.Count > squad2.SquadFighters.Count ? squad1 : squad2;
            Console.WriteLine($"\nПобедитель в {round} раунде:{Winner.SquadName}");
            Winner.GetInfo();
            Console.ReadKey();
        }
    }
}
