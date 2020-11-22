using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Day5or6_The_GAME
{
    public class Fighter
    {
        public string Name;
        public int Health;
        public int Attack;
        public int Strength;
        Random random = new Random();
        public Fighter(string n) 
        { 
            Name = n;
            Health = random.Next(30) + 50 + 1;
            Attack = random.Next(6) + 6 + 1;
            Strength = random.Next(4) + 1;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Имя: {Name}\t Здоровье: {Health}\t Атака: {Attack}\t Сила: {Strength}");
        }
    }
}