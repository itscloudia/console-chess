using ChessBoard;

namespace ChessPiece
{
    class King : Piece
    {
        private Match chessMatch;
        public King(Board board , Color color, Match chessMatch) : base (board, color)
        {
            this.chessMatch = chessMatch;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanItMove(Position pos)
        {
            Piece p = board.Piece(pos);
            return p == null || p.color != this.color;
        }

        
        private bool CastleRookTest(Position pos) {
            Piece p = board.Piece(pos);
            return p != null && p is Rook && p.color == color && p.MoveCount == 0;
        }
        
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0,0);

            // Above
            pos.DefineValues(position.Line - 1, position.Column);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Northeast
            pos.DefineValues(position.Line - 1, position.Column + 1);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Right
            pos.DefineValues(position.Line, position.Column + 1);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

             // Left
            pos.DefineValues(position.Line, position.Column - 1);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Southeast
            pos.DefineValues(position.Line +1, position.Column + 1);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Below
            pos.DefineValues(position.Line +1, position.Column);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Southwest
            pos.DefineValues(position.Line +1, position.Column - 1);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Northwest
            pos.DefineValues(position.Line - 1, position.Column - 1);
            if(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // Castle
            if (MoveCount==0 && !chessMatch.Check) 
            {
                // Short Castle
                Position posR1 = new Position(position.Line, position.Column + 3);
                if (CastleRookTest(posR1)) 
                {
                    Position p1 = new Position(position.Line, position.Column + 1);
                    Position p2 = new Position(position.Line, position.Column + 2);
                    if (board.Piece(p1)==null && board.Piece(p2)==null) 
                    {
                        mat[position.Line, position.Column + 2] = true;
                    }
                }
                // Long Castle
                Position posR2 = new Position(position.Line, position.Column - 4);
                if (CastleRookTest(posR2)) {
                    Position p1 = new Position(position.Line, position.Column - 1);
                    Position p2 = new Position(position.Line, position.Column - 2);
                    Position p3 = new Position(position.Line, position.Column - 3);
                    if (board.Piece(p1) == null && board.Piece(p2) == null && board.Piece(p3) == null) {
                        mat[position.Line, position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}