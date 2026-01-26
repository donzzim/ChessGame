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
    public bool Check { get; private set; }

    public ChessMatch()
    {
        Board = new Chessboard(8,8);
        Turn = 1;
        CurrentPlayer = Color.White;
        Finished = false;
        pieces = new HashSet<Piece>();
        capturedPieces = new HashSet<Piece>();
        Check = false;
        PlacePieces();
    }

    public Piece MakeMove(Position origin, Position destination)
    {
        Piece p = Board.RemovePiece(origin);
        p.AddMove();
        Piece capturedPiece = Board.RemovePiece(destination);
        Board.PlacePiece(p, destination);

        if (capturedPiece != null)
        {
            capturedPieces.Add(capturedPiece);
        }

        return capturedPiece;
    }

    public void UndoMove(Position origin, Position destination, Piece capturedPiece)
    {
        Piece p = Board.RemovePiece(destination);
        p.RemoveMove();
        if (capturedPiece != null)
        {
            Board.PlacePiece(capturedPiece, destination);
            capturedPieces.Remove(capturedPiece);
        }
        Board.PlacePiece(p, origin);
    }

    public void PerformTurn(Position origin, Position destination)
    {
        Piece capturedPiece = MakeMove(origin, destination);

        if (IsInCheck(CurrentPlayer))
        {
            UndoMove(origin, destination, capturedPiece);
            throw new ChessboardException("You cannot put yourself in check");
        }

        if (IsInCheck(Opponent(CurrentPlayer)))
        {
            Check = true;
        }
        else
        {
            Check = false;
        }

        if (TestCheckMate(Opponent(CurrentPlayer)))
        {
            Finished = true;
        }
        else
        {
            Turn++;
            ChangePlayer();
        }

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

    private Color Opponent(Color color)
    {
        if (color == Color.White)
        {
            return Color.Black;
        }
        return Color.White;
    }

    private Piece King(Color color)
    {
        foreach (Piece p in GetPiecesInGame(color))
        {
            if (p is King)
            {
                return p;
            }
        }
        return null;
    }

    public bool IsInCheck(Color color)
    {
        Piece K = King(color);
        if (K == null)
        {
            throw new ChessboardException($"The {color}'s King is not on the board");
        }

        foreach (Piece p in GetPiecesInGame(Opponent(color)))
        {
            bool[,] mat = p.PossibleMoves();
            if (mat[K.Position.Row, K.Position.Column])
            {
                return true;
            }
        }
        return false;
    }

    public bool TestCheckMate(Color color)
    {
        if (!IsInCheck(color))
        {
            return false;
        }

        foreach (Piece p in GetPiecesInGame(color))
        {
            bool[,] mat = p.PossibleMoves();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        Position origin = p.Position;
                        Position destination = new Position(i, j);
                        Piece capturedPiece = MakeMove(p.Position, destination);
                        bool CheckMate = IsInCheck(color);
                        UndoMove(origin, destination, capturedPiece);
                        if (!CheckMate)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
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
