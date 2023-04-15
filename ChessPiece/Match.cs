using ChessBoard; 

namespace ChessPiece
{
    class Match
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool Finished { get; private set; }

        public Match()
        {
            this.board = new Board(8, 8);
            this.turn = 1;
            this.currentPlayer = Color.White;
            Finished = false;
            InsertPieces();
        }

        public void ExecuteMovement(Position origin, Position destination)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementMoveCount();
            Piece capturedPiece = board.RemovePiece(destination);
            board.InsertPiece(p, destination);
        }

        private void InsertPieces()
        {
            board.InsertPiece(new Rook(board, Color.White), new BoardPosition('c', 1).ToPosition());
            board.InsertPiece(new Rook(board, Color.White), new BoardPosition('c', 2).ToPosition());
            board.InsertPiece(new Rook(board, Color.White), new BoardPosition('d', 2).ToPosition());
            board.InsertPiece(new Rook(board, Color.White), new BoardPosition('e', 2).ToPosition());
            board.InsertPiece(new Rook(board, Color.White), new BoardPosition('e', 1).ToPosition());
            board.InsertPiece(new King(board, Color.White), new BoardPosition('d', 1).ToPosition());
        }
    }
}
