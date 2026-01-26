using ChessGame.chessboard;

namespace ChessGame.chess;

public class Rook : Piece
{
    public Rook(Chessboard chessboard, Color color) : base(color, chessboard)
    {

    }

    private bool AbleToMove(Position pos)
    {
        Piece p = Chessboard.Piece(pos);
        return p == null || p.Color != Color;
    }

    public override string ToString()
    {
        return "R";
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] mat = new bool[Chessboard.Rows, Chessboard.Columns];

        Position pos = new Position(0, 0);

        pos.DefineValues(Position.Row - 1, Position.Column);
        while (Chessboard.ValidPosition(pos) || AbleToMove(pos))
        {
            mat[Position.Row, Position.Column] = true;
            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.Row -= 1;
        }

        pos.DefineValues(Position.Row + 1, Position.Column);
        while (Chessboard.ValidPosition(pos) || AbleToMove(pos))
        {
            mat[Position.Row, Position.Column] = true;
            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.Row += 1;
        }

        pos.DefineValues(Position.Row, Position.Column + 1);
        while (Chessboard.ValidPosition(pos) || AbleToMove(pos))
        {
            mat[Position.Row, Position.Column] = true;
            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.Column += 1;
        }

        pos.DefineValues(Position.Row, Position.Column - 1);
        while (Chessboard.ValidPosition(pos) || AbleToMove(pos))
        {
            mat[Position.Row, Position.Column] = true;
            if (Chessboard.Piece(pos) != null && Chessboard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.Column -= 1;
        }

        return mat;
    }
}
