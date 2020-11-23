using System;
using System.IO;
using System.Collections.Generic;

namespace Day5or6_The_GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> names = new List<string> ();
            TxtReader reader = new TxtReader();
            reader.ReadTxT();
            names = reader.names;

            Battle battle = new Battle();
            battle.names = names;
            battle.JustDoSomething();

        }
    }
}
