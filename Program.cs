using System;
using Board;

namespace console_chess
{
    class Program
    {
        static void Main()
        {
            Position P;

            P = new Position(3, 4);

            Console.WriteLine("Position: " + P);

            Console.ReadLine();
        }
    }
}