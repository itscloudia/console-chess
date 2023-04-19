using ChessBoard;

namespace ChessPiece
{
    class King : Piece
    {
        public King(Board board , Color color) : base (board, color)
        {

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
            return mat;
        }
    }
}
