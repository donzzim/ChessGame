using ChessGame.chessboard;

namespace ChessGame.chess;

public class ChessMatch
{
    public Chessboard Board { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
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

    public void PerformTurn(Position origin, Position destination)
    {
        MakeMove(origin, destination);
        Turn++;
        ChangePlayer();
    }

    public void ValidateOriginPosition(Position pos)
    {
        if (Board.Piece(pos) == null)
        {
            throw new ChessboardException("There is no piece in this position");
        }

        if (CurrentPlayer != Board.Piece(pos).Color)
        {
            throw new ChessboardException("This piece is not yours");
        }

        if (Board.Piece(pos).HasAnyPossibleMove())
        {
            throw new ChessboardException("There is no possible moves for this piece");
        }
    }

    public void ValidateDestinationPosition(Position origin, Position destination)
    {
        if (Board.Piece(origin).AbleToMoveTo(destination))
        {
            throw new ChessboardException("Invalid destination position");
        }
    }

    public void ChangePlayer()
    {
        if (CurrentPlayer == Color.White)
        {
            CurrentPlayer = Color.Black;
        }
        else
        {
            CurrentPlayer = Color.White;
        }
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
