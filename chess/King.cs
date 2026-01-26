using ChessGame.chessboard;

namespace ChessGame.chess;

public class King : Piece
{
    private ChessMatch Match;

    public King(Chessboard chessboard, Color color, ChessMatch match) : base(color, chessboard)
    {
        Match = match;
    }

    public override string ToString()
    {
        return "K";
    }

    private bool AbleToMove(Position pos)
    {
        Piece p = Chessboard.Piece(pos);
        return p == null || p.Color != Color;
    }

    private bool RookTest(Position pos)
    {
        Piece p = Chessboard.Piece(pos);
        return p != null && p is Rook && p.Color == Color && p.NumberOfMoves == 0;
    }

    public override bool[,] PossibleMoves()
    {
        bool[,] mat = new bool[Chessboard.Rows, Chessboard.Columns];

        (int row, int col)[] directions =
        {
            (-1,  0),
            (-1,  1),
            ( 0,  1),
            ( 1,  1),
            ( 1,  0),
            ( 1, -1),
            ( 0, -1),
            (-1, -1)
        };

        foreach (var (dr, dc) in directions)
        {
            Position pos = new Position(
                Position.Row + dr,
                Position.Column + dc
            );

            if (Chessboard.ValidPosition(pos) && AbleToMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
        }

        // Castling
        if (NumberOfMoves == 0 && !Match.Check)
        {
            Position posR1 = new Position(Position.Row, Position.Column + 3);
            if (RookTest(posR1))
            {
                Position p1 = new Position(Position.Row, Position.Column + 1);
                Position p2 = new Position(Position.Row, Position.Column + 2);
                if (Chessboard.Piece(p1) == null && Chessboard.Piece(p2) == null)
                {
                    mat[Position.Row, Position.Column] = true;
                }
            }

            Position posR2 = new Position(Position.Row, Position.Column - 4);
            if (RookTest(posR2))
            {
                Position p1 = new Position(Position.Row, Position.Column - 1);
                Position p2 = new Position(Position.Row, Position.Column - 2);
                Position p3 = new Position(Position.Row, Position.Column - 3);
                if (Chessboard.Piece(p1) == null && Chessboard.Piece(p2) == null && Chessboard.Piece(p3) == null)
                {
                    mat[Position.Row, Position.Column - 2] = true;
                }
            }
        }

        return mat;
    }
}
