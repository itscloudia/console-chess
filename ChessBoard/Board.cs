
namespace ChessBoard
{
    class Board
    {
        public int Lines { get; set; }

        public int Columns { get; set; }

        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[lines, columns];
        }
    }
}
