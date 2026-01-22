namespace ChessGame.chessboard.chess;

public class King : Piece
{
    public King(Chessboard chessboard, Color color) : base(color, chessboard)
    {

    }

    public override string ToString()
    {
        return "K";
    }
}
