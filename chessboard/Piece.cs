namespace ChessGame.Chessboard;

public class Piece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int NumberOfMoves  { get;  set; }
    public Chessboard Chessboard { get; protected set; }

    public Piece(Position position, Color color, Chessboard chessboard)
    {
        Position = position;
        Color = color;
        NumberOfMoves = 0;
        Chessboard = chessboard;
    }
}
