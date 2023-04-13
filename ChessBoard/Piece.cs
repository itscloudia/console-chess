
namespace ChessBoard
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int MoveCount { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.board = board;
            this.color = color;
            this.position = null;
            MoveCount = 0;
        }
    }
}
