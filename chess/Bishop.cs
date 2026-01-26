using ChessGame.chessboard;

namespace ChessGame.chess;

public class Bishop : Piece
{
    public Bishop(Chessboard chessboard, Color color) : base(color, chessboard)
    {

    }

    public override string ToString()
    {
        return "B";
    }

    private bool AbleToMove(Position pos)
    {
        Piece p = Chessboard.Piece(pos);
        return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] mat = new bool[Chessboard.Rows, Chessboard.Columns];

        Position pos = new Position(0, 0);

        pos.DefineValues(Position.Row - 1, Position.Column - 1);
        while (Chessboard.ValidPosition(pos) && AbleToMove(pos))
        {
            mat[pos.Row, pos.Column] = true;

            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }

            pos.DefineValues(pos.Row - 1, pos.Column - 1);
        }

        pos.DefineValues(Position.Row - 1, Position.Column + 1);
        while (Chessboard.ValidPosition(pos) && AbleToMove(pos))
        {
            mat[pos.Row, pos.Column] = true;

            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }

            pos.DefineValues(pos.Row - 1, pos.Column + 1);
        }

        pos.DefineValues(Position.Row + 1, Position.Column + 1);
        while (Chessboard.ValidPosition(pos) && AbleToMove(pos))
        {
            mat[pos.Row, pos.Column] = true;

            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }

            pos.DefineValues(pos.Row + 1, pos.Column + 1);
        }

        pos.DefineValues(Position.Row + 1, Position.Column - 1);
        while (Chessboard.ValidPosition(pos) && AbleToMove(pos))
        {
            mat[pos.Row, pos.Column] = true;

            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }

            pos.DefineValues(pos.Row + 1, pos.Column - 1);
        }

        return mat;
    }

}
