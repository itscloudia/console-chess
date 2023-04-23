using ChessBoard;

namespace ChessPiece
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }
        public override string ToString() 
        {
            return "Q";
        }
        private bool CanItMove(Position pos)
        {
            Piece p = board.Piece(pos);
            return p == null || p.color != this.color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            // Left
            pos.DefineValues(position.Line, position.Column - 1);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line, pos.Column - 1);
            }

            // Right
            pos.DefineValues(position.Line, position.Column + 1);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line, pos.Column + 1);
            }

            // Above
            pos.DefineValues(position.Line - 1, position.Column);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column);
            }

            // Below
            pos.DefineValues(position.Line + 1, position.Column);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column);
            }

            // Northwest
            pos.DefineValues(position.Line - 1, position.Column - 1);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
            }

            // Northeast
            pos.DefineValues(position.Line - 1, position.Column + 1);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }

            // Southeast
            pos.DefineValues(position.Line + 1, position.Column + 1);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
            }

            // Southwest
            pos.DefineValues(position.Line + 1, position.Column - 1);
            while(board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(board.Piece(pos) != null && board.Piece(pos).color != color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
            }
            return mat;
        }
    }
}