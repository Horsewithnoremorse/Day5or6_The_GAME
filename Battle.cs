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
            Squad HighElves = GetSquad("HighElves", names, 10, 5);
            Squad WoodElves = GetSquad("WoodElf", names, 10, 5);
            Squad MountainOrks = GetSquad("MountainOrks", names, 11, 4);
            Squad SaromanOrks = GetSquad("SaromanOrks", names, 11, 4);

            Fraction Elves = GetFraction("Elves");
            Elves.FractionSquads.Add(HighElves);
            Elves.FractionSquads.Add(WoodElves);

            Fraction Orks = GetFraction("Orks");
            Orks.FractionSquads.Add(MountainOrks);
            Orks.FractionSquads.Add(SaromanOrks);

            //Elves.GetInfo();
            //Orks.GetInfo();

            //PvP(Elves, Orks);
            SquadVsSquad(Elves, Orks);
            //FractionVsFraction(Elves, Orks);


        }
        public static Squad GetSquad(string name, List<string> names, int numberFighters, int numberHero)
        {
            Squad squad = new Squad() { SquadName = name };
            squad.SquadFighters = new List<Fighter>();
            squad.FighterNames = names;
            squad.AddFighters(numberFighters, numberHero);
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
                int damage1 = Damage(fighter1);
                fighter2.Health = fighter2.Health - damage1;
                Console.WriteLine($"Боец {fighter2.Name}\t получил урон {damage1} единиц от {fighter1.Name},\t здоровья осталось: {fighter2.Health} Hp");
                int damage2 = Damage(fighter2);
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
                    if (squad1.SquadFighters[i].Health > 0 && squad2.SquadFighters[i].Health > 0)
                    {
                        AttackNAbility(squad1.SquadFighters[i], squad2.SquadFighters[i], squad1, squad2, round);
                        Console.ReadKey();
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
                if (squad1.SquadFighters.Count != 0 && squad2.SquadFighters.Count != 0)
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
        public void FractionVsFraction(Fraction fraction1, Fraction fraction2)
        {
            Console.WriteLine("Нажми кнопку для начала битвы фракций");
            Console.ReadKey();
            Console.WriteLine(" ");
            int round = 1;
            int fightercount = 10;
            int squadcount = fraction1.FractionSquads.Count;

            while (squadcount > 0) //бой между фракциями
            {

                Squad squad1 = fraction1.FractionSquads[0];
                Console.WriteLine("инфа перед боем");
                squad1.GetInfo();
                Squad squad2 = fraction2.FractionSquads[0];
                squad2.GetInfo();
                fightercount = squad1.SquadFighters.Count <= squad2.SquadFighters.Count ? squad1.SquadFighters.Count : squad2.SquadFighters.Count;
                while (fightercount > 0) //бой отряда на отряд
                {
                    for (int i = 0; i < fightercount; i++) //бой Пвп
                    {
                        while (squad1.SquadFighters[i].Health > 0 && squad2.SquadFighters[i].Health > 0)
                        {
                            Random random = new Random();
                            int damage1 = random.Next(squad1.SquadFighters[i].Attack) + 1 + squad1.SquadFighters[i].Strength;
                            squad2.SquadFighters[i].Health = squad2.SquadFighters[i].Health - damage1;
                            //Console.WriteLine($"Боец {squad2.SquadFighters[i].Name}\t получил урон {damage1} единиц от {squad1.SquadFighters[i].Name},\t здоровья осталось: {squad2.SquadFighters[i].Health} Hp");
                            int damage2 = random.Next(squad2.SquadFighters[i].Attack) + 1 + squad2.SquadFighters[i].Strength;
                            squad1.SquadFighters[i].Health = squad1.SquadFighters[i].Health - damage2;
                            //Console.WriteLine($"Боец {squad1.SquadFighters[i].Name}\t получил урон {damage2} единиц от {squad2.SquadFighters[i].Name},\t здоровья осталось: {squad1.SquadFighters[i].Health} Hp");
                        }
                    }
                    for (int i = 0; i < squad1.SquadFighters.Count; i++) //вынос мертвецов 1 отряда
                    {
                        if (squad1.SquadFighters[i].Health <= 0)
                        {
                            squad1.SquadFighters.RemoveAt(i);
                            i--; //вообще выглядит как костыль
                        }
                    }
                    for (int i = 0; i < squad2.SquadFighters.Count; i++) //вынос мертвецов 2 отряда
                    {
                        if (squad2.SquadFighters[i].Health <= 0)
                        {
                            squad2.SquadFighters.RemoveAt(i);
                            i--;
                        }
                    }
                    if (squad1.SquadFighters.Count != 0 && squad2.SquadFighters.Count != 0)
                    {
                        Console.WriteLine($"\nРаунд {round}\n");
                        squad1.GetInfo();
                        Console.WriteLine();
                        squad2.GetInfo();
                        Console.WriteLine();
                    }
                    Squad SquadWinner;
                    if (fraction1.FractionSquads[0].SquadFighters.Count == 0 && fraction2.FractionSquads[0].SquadFighters.Count == 0)
                    {
                        Console.WriteLine("Ничья, оба отряда уничтожены");
                        fraction1.FractionSquads.RemoveAt(0);
                        fraction2.FractionSquads.RemoveAt(0);
                    }
                    else
                    {
                        if (fraction1.FractionSquads[0].SquadFighters.Count == 0)
                        {
                            fraction1.FractionSquads.RemoveAt(0);
                            SquadWinner = fraction2.FractionSquads[0];
                            Console.WriteLine($"В сражении отрядов победил {SquadWinner.SquadName} в {round} раунде");
                        }
                        if (fraction2.FractionSquads[0].SquadFighters.Count == 0)
                        {
                            fraction2.FractionSquads.RemoveAt(0);
                            SquadWinner = fraction1.FractionSquads[0];
                            Console.WriteLine($"В сражении отрядов победил {SquadWinner.SquadName} в {round} раунде");
                        }
                    }
                    round++;
                    Console.ReadKey();
                    fightercount = squad1.SquadFighters.Count <= squad2.SquadFighters.Count ? squad1.SquadFighters.Count : squad2.SquadFighters.Count;
                }
                squadcount = fraction1.FractionSquads.Count <= fraction2.FractionSquads.Count ? fraction1.FractionSquads.Count : fraction2.FractionSquads.Count;
            }
            Fraction Winner = fraction1.FractionSquads.Count > fraction2.FractionSquads.Count ? fraction1 : fraction2;
            Console.WriteLine($"\nПобедитель в {round} раунде:{Winner.FractionName}");
            Winner.GetInfo();
            Console.ReadKey();
        }
        public void AttackNAbility(Fighter fighter1, Fighter fighter2, Squad Squad1, Squad Squad2, int round)
        {
            int damage;
            string ability1 = fighter1.Ability;
            string ability2 = fighter2.Ability;
            Random random = new Random();
          
                //fighter1 attck fighter2
                if (fighter2.Ability == "Warior" && round == 1)
                {
                    fighter2.roundCount = round;
                    Console.WriteLine($"{fighter2.Name} использует способность Warior - уклонение");
                }
                else
                {
                    switch (ability1)
                    {
                        case "Berserk":
                            damage = Damage(fighter1);
                            fighter2.Health -= damage;
                            if (fighter1.Health <= 10)
                            {
                                int berserkDamage = Damage(fighter1);
                                int index = random.Next(Squad2.SquadFighters.Count);
                                Squad2.SquadFighters[index].Health -= berserkDamage;
                                Console.WriteLine($"{fighter1.Name} использует способность Berserk - ярость набрасываясь на {Squad2.SquadFighters[index].Name} и наносит {berserkDamage} урона");
                            }
                            break;

                        case "Priest":
                            damage = Damage(fighter1);
                            fighter2.Health -= damage;
                            int indexHeal = 0;
                            if (fighter1.roundCount <= round)
                            {
                                for (int i = 0; i < Squad1.SquadFighters.Count && indexHeal < Squad1.SquadFighters.Count; i++)
                                {
                                    if (Squad1.SquadFighters[indexHeal].Health > 0)
                                    {
                                        if (Squad1.SquadFighters[indexHeal].Health > Squad1.SquadFighters[i].Health && Squad1.SquadFighters[i].Health > 0)
                                        {
                                            indexHeal = i;
                                        }
                                    }
                                    else
                                    {
                                        indexHeal = i++;
                                    }
                                }
                                if (Squad1.SquadFighters[indexHeal].Health < 20)
                                {
                                    fighter1.roundCount = round + 3;
                                    Squad1.SquadFighters[indexHeal].Health += damage;
                                    Console.WriteLine($"{fighter1.Name} использует способность Priest - Исцеление на {Squad1.SquadFighters[indexHeal].Name} на {damage} HP");
                                }
                            }
                            break;

                        case "Mage":
                            damage = Damage(fighter1);
                            int indexAttck = 0;
                            if (fighter1.roundCount <= round)
                            {
                                for (int i = 0; i < Squad2.SquadFighters.Count; i++) //проверка на мин ХП и его живость
                                {
                                    if (Squad2.SquadFighters[indexAttck].Health > 0)
                                    {
                                        if (Squad2.SquadFighters[indexAttck].Health > Squad2.SquadFighters[i].Health && Squad2.SquadFighters[i].Health > 0)
                                        {
                                            indexAttck = i;
                                        }
                                    }
                                    else
                                    {
                                        indexAttck = i++;
                                    }
                                }
                                fighter1.roundCount = round + 3;
                                // если осталось меньше 3х - то по всем оставшимся - а это мы сделаем потом))
                                Squad2.SquadFighters[indexAttck].Health -= damage;
                                Console.WriteLine($"{fighter1.Name} использует способность Mage - Fireball bitch!");
                                for (int x = indexAttck - 1; x >= -1; x--) //проверка соседа снизу и атака
                                { 
                                    if (x <= -1)
                                    {
                                        x = Squad2.SquadFighters.Count;
                                    }
                                    else if (Squad2.SquadFighters[x].Health > 0 )
                                    {
                                        Squad2.SquadFighters[x].Health -= damage;
                                        break;
                                    }
                                }

                                for (int x = indexAttck + 1; x < Squad2.SquadFighters.Count; x++) //проверка соседа сверху и атака
                                {
                                    
                                    if (x == Squad2.SquadFighters.Count)
                                    {
                                        x = 0;
                                    }
                                    else if (Squad2.SquadFighters[x].Health > 0)
                                    {
                                        Squad2.SquadFighters[x].Health -= damage;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < Squad2.SquadFighters.Count; i++)
                                {
                                    if (Squad2.SquadFighters[indexAttck].Health > 0)
                                    {
                                        if (Squad2.SquadFighters[indexAttck].Health > Squad2.SquadFighters[i].Health && Squad2.SquadFighters[i].Health > 0)
                                        {
                                            indexAttck = i;
                                        }
                                    }
                                    else
                                    {
                                        indexAttck = i++;
                                    }
                                }
                                if (Squad2.SquadFighters[indexAttck].Health > 0)
                                {
                                    Squad2.SquadFighters[indexAttck].Health -= damage;
                                }
                            }
                            break;

                        default:
                            damage = Damage(fighter1);
                            fighter2.Health -= damage;
                            break;
                    }
                }
                //fighter2 attck fighter1
                if (fighter1.Ability == "Warior" && round == 1)
                {
                    fighter1.roundCount = round;
                    Console.WriteLine($"{fighter1.Name} использует способность Warior - уклонение");
                }
                else
                {
                    switch (ability2)
                    {
                        case "Berserk":
                            damage = Damage(fighter2);
                            fighter1.Health -= damage;
                            if (fighter2.Health <= 10)
                            {
                                int berserkDamage = Damage(fighter2);
                                int index = random.Next(Squad1.SquadFighters.Count);
                                Squad1.SquadFighters[index].Health -= berserkDamage;
                                Console.WriteLine($"{fighter2.Name} использует способность Berserk - ярость набрасываясь на {Squad1.SquadFighters[index].Name} и наносит {berserkDamage} урона");
                            }
                            break;

                        case "Priest":
                            damage = Damage(fighter2);
                            fighter1.Health -= damage;
                            int indexHeal = 0;
                            if (fighter2.roundCount <= round)
                            {
                                for (int i = 0; i < Squad2.SquadFighters.Count && indexHeal < Squad2.SquadFighters.Count; i++)
                                {
                                    if (Squad2.SquadFighters[indexHeal].Health > 0)
                                    {
                                        if (Squad2.SquadFighters[indexHeal].Health > Squad2.SquadFighters[i].Health && Squad2.SquadFighters[i].Health > 0)
                                        {
                                            indexHeal = i;
                                        }
                                    }
                                    else
                                    {
                                        indexHeal = i++;
                                    }
                                }
                                if (Squad2.SquadFighters[indexHeal].Health < 20)
                                {
                                    fighter2.roundCount = round + 3;
                                    Squad2.SquadFighters[indexHeal].Health += damage;
                                    Console.WriteLine($"{fighter2.Name} использует способность Priest - Исцеление на {Squad2.SquadFighters[indexHeal].Name} на {damage} HP");
                                }
                            }
                            break;

                        case "Mage":
                            damage = Damage(fighter2);
                            int indexAttck = 0;
                            if (fighter2.roundCount <= round)
                            {
                                for (int i = 0; i < Squad1.SquadFighters.Count; i++) //проверка на мин ХП и его живость
                                {
                                    if (Squad1.SquadFighters[indexAttck].Health > 0)
                                    {
                                        if (Squad1.SquadFighters[indexAttck].Health > Squad1.SquadFighters[i].Health && Squad1.SquadFighters[i].Health > 0)
                                        {
                                            indexAttck = i;
                                        }
                                    }
                                    else
                                    {
                                        indexAttck = i++;
                                    }
                                }
                                fighter2.roundCount = round + 3;
                                // если осталось меньше 3х - то по всем оставшимся - а это мы сделаем потом))
                                Squad1.SquadFighters[indexAttck].Health -= damage;
                                Console.WriteLine($"{fighter2.Name} использует способность Mage - Fireball bitch!");
                                for (int x = indexAttck - 1; x >= -1; x--) //проверка соседа снизу и атака
                                {
                                    if (x <= -1)
                                    {
                                        x = Squad1.SquadFighters.Count;
                                    }
                                    else if (Squad1.SquadFighters[x].Health > 0)
                                    {
                                        Squad1.SquadFighters[x].Health -= damage;
                                        break;
                                    }
                                    
                                }

                                for (int x = indexAttck + 1; x <= Squad1.SquadFighters.Count; x++) //проверка соседа сверху и атака
                                {
                                    if (x == Squad1.SquadFighters.Count)
                                    {
                                        x = 0;
                                    }
                                    else if (Squad1.SquadFighters[x].Health > 0 && x < Squad1.SquadFighters.Count)
                                    {
                                        Squad1.SquadFighters[x].Health -= damage;
                                        break;
                                    }
                                    
                                }
                            }
                            else
                            {
                                for (int i = 0; i < Squad1.SquadFighters.Count; i++)
                                {
                                    if (Squad1.SquadFighters[indexAttck].Health > 0)
                                    {
                                        if (Squad1.SquadFighters[indexAttck].Health > Squad1.SquadFighters[i].Health && Squad1.SquadFighters[i].Health > 0)
                                        {
                                            indexAttck = i;
                                        }
                                    }
                                    else
                                    {
                                        indexAttck = i++;
                                    }
                                }
                                if (Squad1.SquadFighters[indexAttck].Health > 0)
                                {
                                    Squad1.SquadFighters[indexAttck].Health -= damage;
                                }
                            }
                            break;

                        default:
                            damage = Damage(fighter2);
                            fighter1.Health -= damage;
                            break;
                    }
                }
            
            
        }
        public int Damage(Fighter fighter)
        {
            Random random = new Random();
            int damage = random.Next(fighter.Attack) + 1 + fighter.Strength;
            return damage;
        }
    }
}
