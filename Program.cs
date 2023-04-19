﻿using System;
using ChessBoard;
using ChessPiece;

namespace console_chess
{
    class Program
    {
        static void Main()
        {
            Match m = new Match();

            while (!m.Finished)
            {
                Console.Clear();
                Screen.PrintBoard(m.board);

                Console.WriteLine();
                Console.Write("Type the origin position: ");
                Position origin = Screen.ReadBoardPosition().ToPosition();

                bool[,] possiblePositions = m.board.Piece(origin).PossibleMovements();

                Console.Clear();

                Screen.PrintBoard(m.board, possiblePositions);
                Console.WriteLine();
                Console.Write("Destination: ");
                Position destination = Screen.ReadBoardPosition().ToPosition();

                m.ExecuteMovement(origin, destination);
            }
        }
    }
}