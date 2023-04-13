
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

        public void InsertPiece(Piece p, Position pos)
        {
            Pieces[pos.Line, pos.Column] = p;
        }
    }
}
