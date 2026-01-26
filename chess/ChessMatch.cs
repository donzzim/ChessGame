using ChessGame.chessboard;

namespace ChessGame.chess;

public class ChessMatch
{
    public Chessboard Board { get; private set; }
    public int Turn { get; private set; }
    public Color CurrentPlayer { get; private set; }
    public bool Finished { get; private set; }
    private HashSet<Piece> pieces;
    private HashSet<Piece> capturedPieces;

    public ChessMatch()
    {
        Board = new Chessboard(8,8);
        Turn = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        pieces = new HashSet<Piece>();
        capturedPieces = new HashSet<Piece>();
        PlacePieces();
    }

    public void MakeMove(Position origin, Position destination)
    {
        Piece p = Board.RemovePiece(origin);
        p.AddMove();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.PlacePiece(p, destination);

        if (capturedPiece != null)
        {
            capturedPieces.Add(capturedPiece);
        }
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

    public HashSet<Piece> GetCapturedPieces(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (Piece p in capturedPieces)
        {
            if (p.Color == color)
            {
                aux.Add(p);
            }
        }
        return aux;
    }

    public HashSet<Piece> GetPiecesInGame(Color color)
    {
        HashSet<Piece> aux = new HashSet<Piece>();
        foreach (Piece p in pieces)
        {
            if (p.Color == color)
            {
                aux.Add(p);
            }
        }
        aux.ExceptWith(GetCapturedPieces(color));
        return aux;
    }

    public void PlaceNewPiece(char column, int row, Piece piece)
    {
        Board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
        pieces.Add(piece);
    }

    private void PlacePieces()
    {
        PlaceNewPiece('c', 1, new Rook(Board, Color.White));
        PlaceNewPiece('c', 2, new Rook(Board, Color.White));
        PlaceNewPiece('d', 2, new Rook(Board, Color.White));
        PlaceNewPiece('e', 2, new Rook(Board, Color.White));
        PlaceNewPiece('e', 1, new Rook(Board, Color.White));
        PlaceNewPiece('d', 1, new King(Board, Color.White));

        PlaceNewPiece('c', 7, new Rook(Board, Color.Black));
        PlaceNewPiece('c', 8, new Rook(Board, Color.Black));
        PlaceNewPiece('d', 7, new Rook(Board, Color.Black));
        PlaceNewPiece('e', 7, new Rook(Board, Color.Black));
        PlaceNewPiece('e', 8, new Rook(Board, Color.Black));
        PlaceNewPiece('d', 8, new King(Board, Color.Black));
    }

}
