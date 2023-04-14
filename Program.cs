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
            board.InsertPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.InsertPiece(new King(board, Color.Black), new Position(2, 4));

            board.InsertPiece(new Rook(board, Color.White), new Position(3, 5));


            Screen.PrintBoard(board);

        }
    }
}