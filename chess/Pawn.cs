using ChessGame.chessboard;

namespace ChessGame.chess;

public class Pawn : Piece
{
    public Pawn(Chessboard chessboard, Color color) : base(color, chessboard)
    {

    }

    public override string ToString()
    {
        return "P";
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

        if (Color == Color.White)
        {
            pos.DefineValues(Position.Row - 1, Position.Column);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) == null)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 2, Position.Column);
            Position p2 = new Position(Position.Row - 1, Position.Column);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) == null &&
                Chessboard.Piece(p2) == null && NumberOfMoves == 0)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) != null &&
                Chessboard.Piece(pos).Color == Color.Black)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) != null &&
                Chessboard.Piece(pos).Color == Color.Black)
            {
                mat[pos.Row, pos.Column] = true;
            }
        }
        else
        {
            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) == null)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 2, Position.Column);
            Position p2 = new Position(Position.Row + 1, Position.Column);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) == null &&
                Chessboard.Piece(p2) == null && NumberOfMoves == 0)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) != null &&
                Chessboard.Piece(pos).Color == Color.White)
            {
                mat[pos.Row, pos.Column] = true;
            }

            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Chessboard.ValidPosition(pos) && Chessboard.Piece(pos) != null &&
                Chessboard.Piece(pos).Color == Color.White)
            {
                mat[pos.Row, pos.Column] = true;
            }
        }

        return mat;
    }
}
