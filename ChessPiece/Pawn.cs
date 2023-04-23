using ChessBoard;

namespace ChessPiece 
{
    class Pawn : Piece 
    {

        private Match chessMatch;

        public Pawn(Board board, Color color, Match chessMatch) : base(board, color) 
        {
            this.chessMatch = chessMatch;
        }

        public override string ToString() 
        {
            return "P";
        }

        private bool IsThereEnemy(Position pos) 
        {
            Piece p = board.Piece(pos);
            return p != null && p.color != color;
        }

        private bool AvailableSquare(Position pos) 
        {
            return board.Piece(pos) == null;
        }

        public override bool[,] PossibleMovements() 
        {
            bool[,] mat = new bool[board.Lines, board.Columns];

            Position pos = new Position(0, 0);

            if (color == Color.White) 
            {
                pos.DefineValues(pos.Line - 1, pos.Column);
                if (board.IsPositionValid(pos) && AvailableSquare(pos)) 
                {
                    mat[board.Lines, board.Columns] = true;
                }

                pos.DefineValues(position.Line - 2, position.Column);
                Position p2 = new Position(position.Line - 1, position.Column);
                if(board.IsPositionValid(p2) && AvailableSquare(p2) && AvailableSquare(pos) && MoveCount == 0)
                {
                    mat [pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line - 1, pos.Column - 1);
                if (board.IsPositionValid(pos) && IsThereEnemy(pos)) 
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line - 1, pos.Column + 1);
                if (board.IsPositionValid(pos) && IsThereEnemy(pos)) 
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // En passant
                if(position.Line == 3)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if(board.IsPositionValid(left) && IsThereEnemy(left) && board.Piece(left) == chessMatch.EnPassantVulnerable)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if(board.IsPositionValid(right) && IsThereEnemy(right) && board.Piece(right) == chessMatch.EnPassantVulnerable)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else 
            {
                pos.DefineValues(position.Line + 1, position.Column);
                if(board.IsPositionValid(pos) && AvailableSquare(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(position.Line + 2, position.Column);
                Position p2 = new Position(position.Line + 1, position.Column);
                if(board.IsPositionValid(p2) && AvailableSquare(p2) && board.IsPositionValid(pos) && AvailableSquare(pos) && MoveCount == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(position.Line + 1, position.Column - 1);
                if(board.IsPositionValid(pos) && IsThereEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(position.Line + 1, position.Column + 1);
                if(board.IsPositionValid(pos) && IsThereEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                
                // En passant
                if(position.Line == 4)
                {
                    Position left = new Position(position.Line, position.Column - 1);
                    if(board.IsPositionValid(left) && IsThereEnemy(left) && board.Piece(left) == chessMatch.EnPassantVulnerable)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(position.Line, position.Column + 1);
                    if(board.IsPositionValid(right) && IsThereEnemy(right) && board.Piece(right) == chessMatch.EnPassantVulnerable)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
