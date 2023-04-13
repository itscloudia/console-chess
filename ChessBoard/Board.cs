
namespace ChessBoard
{
    class Board
    {
        public int Lines { get; set; }

        public int Columns { get; set; }

        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int lines, int columns)
        {
            return Pieces[lines, columns];
        }

        public Piece Piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool DoesPieceExist(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }
        public void InsertPiece(Piece p, Position pos)
        {
            Pieces[pos.Line, pos.Column] = p;
            p.position = pos;
        }

        public bool IsPositionValid(Position pos)
        {
            if(pos.Line<0 || pos.Line >= Lines || pos.Column<0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!IsPositionValid(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
