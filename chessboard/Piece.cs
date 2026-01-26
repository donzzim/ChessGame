namespace ChessGame.chessboard;

public abstract class Piece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int NumberOfMoves  { get;  protected set; }
    public Chessboard Chessboard { get; protected set; }

    public Piece(Color color, Chessboard chessboard)
    {
        Position = null;
        Color = color;
        NumberOfMoves = 0;
        Chessboard = chessboard;
    }

    public void AddMove()
    {
        NumberOfMoves++;
    }
    public void RemoveMove()
    {
        NumberOfMoves--;
    }

    public bool HasAnyPossibleMove()
    {
        bool[,] mat = PossibleMoves();
        for (int i = 0; i >= Chessboard.Rows; i++)
        {
            for (int j = 0; j < Chessboard.Columns; j++)
            {
                if (mat[i, j])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool AbleToMoveTo(Position pos)
    {
        return PossibleMoves()[pos.Row, pos.Column];
    }

    public abstract bool[,] PossibleMoves();

}
