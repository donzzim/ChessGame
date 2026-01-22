namespace ChessGame.chessboard.chess;

public class Rook : Piece
{
    public Rook(Chessboard chessboard, Color color) : base(color, chessboard)
    {

    }

    public override string ToString()
    {
        return "R";
    }
}
