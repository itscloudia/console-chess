using ChessBoard;

namespace ChessPiece 
{

    class Knight : Piece {

        public Knight(Board board, Color color) : base(board, color) {
        }

        public override string ToString() {
            return "N";
        }

        private bool CanItMove(Position pos) 
        {
            Piece p = board.Piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] PossibleMovements() 
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            pos.DefineValues(position.Line - 1, position.Column - 2);
            if (board.IsPositionValid(pos) && CanItMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(position.Line - 2, position.Column - 1);
            if (board.IsPositionValid(pos) && CanItMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            
            pos.DefineValues(position.Line - 2, position.Column + 1);
            if (board.IsPositionValid(pos) && CanItMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(position.Line - 1, position.Column + 2);
            if (board.IsPositionValid(pos) && CanItMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(position.Line + 1, position.Column + 2);
            if (board.IsPositionValid(pos) && CanItMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(position.Line + 2, position.Column + 1);
            if (board.IsPositionValid(pos) && CanItMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(position.Line + 2, position.Column - 1);
            if (board.IsPositionValid(pos) && CanItMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(position.Line + 1, position.Column - 2);
            if (board.IsPositionValid(pos) && CanItMove(pos)) 
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}