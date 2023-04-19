using ChessBoard; 
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
        private HashSet<Piece> CapturedPieces;

        public Match()
        {
            this.board = new Board(8, 8);
            this.Turn = 1;
            this.currentPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            Finished = false;
            InsertPieces();
        }

        public void PerformMove(Position origin, Position destination)
        {
            ExecuteMovement(origin, destination);
            Turn ++;
            SwitchPlayer();
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
            if(!board.Piece(origin).CanItMoveTo(destination))
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
            foreach(Piece x in CapturedPieces)
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

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementMoveCount();
            Piece capturedPiece = board.RemovePiece(destination);
            board.InsertPiece(p, destination);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
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
