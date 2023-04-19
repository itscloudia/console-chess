
namespace ChessBoard
{
    abstract class Piece
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

        public void IncrementMoveCount()
        {
            MoveCount++;
        }
        
        public bool DoesMovementExist()
        {
            bool [,] mat = PossibleMovements();
            for(int i = 0; i<board.Lines; i++)
            {
                for(int j = 0; j<board.Columns; j++)
                {
                    if(mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanItMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }
        public abstract bool [,] PossibleMovements();
    }
}
