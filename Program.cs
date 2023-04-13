using System;
using ChessBoard;

namespace console_chess
{
    class Program
    {
        static void Main()
        {
            Board board = new Board(8,8);

            Screen.PrintBoard(board);
        }
    }
}