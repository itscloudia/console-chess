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

            while (!m.Finished)
            {
                try
                {
                    Console.Clear();
                    Screen.PrintBoard(m.board);
                    Console.WriteLine();
                    Console.WriteLine("Turn: " + m.Turn);
                    Console.WriteLine("Waiting move from: " + m.currentPlayer);

                    Console.WriteLine();
                    Console.Write("Type the origin position: ");
                    Position origin = Screen.ReadBoardPosition().ToPosition();
                    m.ValidateOriginMovement(origin);

                    bool[,] possiblePositions = m.board.Piece(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(m.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadBoardPosition().ToPosition();

                    m.PerformMove(origin, destination);
                }
                catch(BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }   
}