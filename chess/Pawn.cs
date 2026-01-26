using ChessGame.chessboard;

namespace ChessGame.chess;

public class Pawn : Piece
{
    private ChessMatch Match;
    public Pawn(Chessboard chessboard, Color color, ChessMatch match) : base(color, chessboard)
    {
        Match = match;
    }

    public override string ToString()
    {
        return "P";
    }

    public bool HasOpponent(Position pos)
    {
        Piece p = Chessboard.Piece(pos);
        return p != null && p.Color != Color;
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

            // En Passant
            if (Position.Row == 3)
            {
                Position left = new Position(Position.Row, Position.Column - 1);
                if (Chessboard.ValidPosition(left) && HasOpponent(left) && Chessboard.Piece(left) == Match.PieceEnPassant)
                {
                    mat[left.Row - 1, left.Column] = true;
                }

                Position right = new Position(Position.Row, Position.Column + 1);
                if (Chessboard.ValidPosition(right) && HasOpponent(right) && Chessboard.Piece(right) == Match.PieceEnPassant)
                {
                    mat[right.Row - 1, right.Column] = true;
                }
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

            // En Passant
            if (Position.Row == 4)
            {
                Position left = new Position(Position.Row, Position.Column - 1);
                if (Chessboard.ValidPosition(left) && HasOpponent(left) && Chessboard.Piece(left) == Match.PieceEnPassant)
                {
                    mat[left.Row + 1, left.Column] = true;
                }

                Position right = new Position(Position.Row, Position.Column + 1);
                if (Chessboard.ValidPosition(right) && HasOpponent(right) && Chessboard.Piece(right) == Match.PieceEnPassant)
                {
                    mat[right.Row + 1, right.Column] = true;
                }
            }
        }

        return mat;
    }
}
