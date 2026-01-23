using ChessGame.chessboard;

namespace ChessGame.chess;

public class ChessMatch
{
    public Chessboard Board { get; private set; }
    private int Turn;
    private Color CurrentPlayer;
    public bool Finished { get; private set; }

    public ChessMatch()
    {
        Board = new Chessboard(8,8);
        Turn = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        PlacePieces();
    }

    public void MakeMove(Position origin, Position destination)
    {
        Piece p = Board.RemovePiece(origin);
        p.AddMove();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.PlacePiece(p, destination);
    }

    private void PlacePieces()
    {
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 1 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('c', 2 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('d', 2 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 2 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('e', 1 ).ToPosition());
        Board.PlacePiece(new King(Board, Color.White), new ChessPosition('d', 1 ).ToPosition());

        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 7 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('c', 8 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('d', 7 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 7 ).ToPosition());
        Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('e', 8 ).ToPosition());
        Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('d', 8 ).ToPosition());
    }

}
