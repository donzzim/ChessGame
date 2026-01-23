namespace ChessGame.chessboard;

public class Chessboard
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    private Piece[,] Pieces;

    public Chessboard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Pieces = new Piece[Rows, Columns];
    }

    public Piece Piece(int row, int column)
    {
        return Pieces[row, column];
    }

    public Piece Piece(Position pos)
    {
        return Pieces[pos.Row, pos.Column];
    }

    public bool HasPiece(Position pos)
    {
        ValidatePosition(pos);
        return Piece(pos) != null;
    }

    public void PlacePiece(Piece p, Position pos)
    {
        if (HasPiece(pos))
        {
            throw new ChessboardException("There is already a piece in this position");
        }
        Pieces[pos.Row, pos.Column] = p;
        p.Position = pos;
    }

    public Piece RemovePiece(Position pos)
    {
        if (Piece(pos) == null)
        {
            return null;
        }
        Piece aux = Piece(pos);
        aux.Position = null;
        Pieces[pos.Row, pos.Column] = null;
        return aux;
    }

    public bool ValidPosition(Position pos)
    {
        if (pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Columns)
        {
            return false;
        }
        return true;
    }

    public void ValidatePosition(Position pos)
    {
        if (!ValidPosition(pos))
        {
            throw new ChessboardException("Invalid position");
        }
    }
}
