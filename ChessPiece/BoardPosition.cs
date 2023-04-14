using ChessBoard;

namespace ChessPiece
{
    class BoardPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public BoardPosition(char column, int line)
        {
            this.Column = column;
            this.Line = line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
