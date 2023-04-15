using System;
using ChessBoard;
using ChessPiece;

namespace console_chess
{
    class Program
    {
        static void Main()
        {
            Match m = new Match();

            Screen.PrintBoard(m.board);

        }
    }
}