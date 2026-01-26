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

    public abstract bool[,] PossibleMoves();

}
