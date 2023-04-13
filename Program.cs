using System;
using ChessBoard;
using ChessPiece;

namespace console_chess
{
    class Program
    {
        static void Main()
        {
            Board board = new Board(8,8);

            board.InsertPiece(new Rook(board, Color.Black), new Position(0, 0));
          

            Screen.PrintBoard(board);
        }
    }
}