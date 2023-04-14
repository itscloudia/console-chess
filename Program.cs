using System;
using ChessBoard;
using ChessPiece;

namespace console_chess
{
    class Program
    {
        static void Main()
        {
            BoardPosition boardPosition = new BoardPosition('c', 7);

            Console.WriteLine(boardPosition);

            Console.WriteLine(boardPosition.ToPosition());

            Console.WriteLine();
           
        }
    }
}