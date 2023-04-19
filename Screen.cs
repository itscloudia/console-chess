using System;
using System.Collections.Generic;
using ChessBoard;
using ChessPiece;

namespace console_chess
{
    class Screen
    {
        public static void PrintMatch(Match m)
        {   
            PrintBoard(m.board);
            Console.WriteLine();
            PrintCapturedPieces(m);
            Console.WriteLine();
            Console.WriteLine("Turn: " + m.Turn);
            Console.WriteLine("Waiting move from: " + m.currentPlayer);
        }

        public static void PrintCapturedPieces(Match m)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White pieces: ");
            PrintSet(m.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black pieces: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(m.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[ ");
            foreach(Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board)
        {

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(possiblePositions[i,j])
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static BoardPosition ReadBoardPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + " ");
            return new BoardPosition(column, line);
        }
        public static void PrintPiece(Piece p)
        {
            if(p == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (p.color == Color.White)
                { 
                    Console.Write(p);
                }
            
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(p);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
