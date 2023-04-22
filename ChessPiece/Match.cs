﻿using ChessBoard; 
using System.Collections.Generic;

namespace ChessPiece
{
    class Match
    {
        public Board board { get; private set; }
        public int Turn { get; private set; }
        public Color currentPlayer {get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> capturedPieces;
        public bool Check {get; private set;}

        public Match()
        {
            this.board = new Board(8, 8);
            this.Turn = 1;
            this.currentPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            Finished = false;
            Check = false;
            InsertPieces();
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.RemovePiece(destination);
            p.DecrementMoveCount();
            if(capturedPiece != null)
            {
                board.InsertPiece(capturedPiece, destination);
                capturedPieces.Remove(capturedPiece);
            }
            board.InsertPiece(p, origin);
        }
        public void PerformMove(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMovement(origin, destination);

            if(IsItInCheck(currentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                Console.WriteLine();
                throw new BoardException("You can't put yourself in check, type again!");
            }

            if(IsItInCheck(Adversary(currentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if(CheckmateTest(Adversary(currentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn ++;
                SwitchPlayer();   
            }
        }

        public void ValidateOriginMovement(Position pos)
        {
            if(board.Piece(pos) == null)
            {
                throw new BoardException("There's no piece in the chosen origin position. Type again: ");
            }
            if(currentPlayer != board.Piece(pos).color)
            {
                throw new BoardException("The chosen piece isn't yours. Type again: ");

            }
            if(!board.Piece(pos).DoesMovementExist())
            {
                throw new BoardException("There's no possible movements for the chosen origin piece. Type again: ");
            }
        }

        public void ValidateDestinationMovement(Position origin, Position destination)
        {
            if(!board.Piece(origin).PossibleMovement(destination))
            {
                throw new BoardException("Destination position is invalid.");
            }
        }
        private void SwitchPlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in capturedPieces)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Pieces)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public Piece ExecuteMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementMoveCount();
            Piece capturedPiece = board.RemovePiece(destination);
            board.InsertPiece(p, destination);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        private Color Adversary(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece x in InGamePieces(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null; // Just in case :P
        }

        public bool IsItInCheck(Color color)
        {
            Piece K = King(color);

            foreach(Piece x in InGamePieces(Adversary(color)))
            {
                bool[,] mat = x.PossibleMovements();
                if(mat[K.position.Line, K.position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color)
        {
            if(!IsItInCheck(color))
            {
                return false;
            }

            foreach(Piece x in InGamePieces(color))
            {
                bool[,] mat = x.PossibleMovements();
                for(int i = 0; i<board.Lines; i++)
                {
                    for(int j = 0; j<board.Columns; j++)
                    {
                        if(mat[i,j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i,j);
                            Piece capturedPiece = ExecuteMovement(origin, destination);
                            bool CheckmateTest = IsItInCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if(!CheckmateTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void InsertNewPiece(char column, int line, Piece piece)
        {
            board.InsertPiece(piece, new BoardPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void InsertPieces()
        {
            InsertNewPiece('c', 1, new Rook(board, Color.White));
            InsertNewPiece('c', 2, new Rook(board, Color.White));
            InsertNewPiece('d', 2, new Rook(board, Color.White));
            InsertNewPiece('e', 2, new Rook(board, Color.White));
            InsertNewPiece('e', 1, new Rook(board, Color.White));
            InsertNewPiece('d', 1, new King(board, Color.White));

            InsertNewPiece('c', 7, new Rook(board, Color.Black));
            InsertNewPiece('c', 8, new Rook(board, Color.Black));
            InsertNewPiece('d', 7, new Rook(board, Color.Black));
            InsertNewPiece('e', 7, new Rook(board, Color.Black));
            InsertNewPiece('e', 8, new Rook(board, Color.Black));
            InsertNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
