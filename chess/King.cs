using ChessGame.chessboard;

namespace ChessGame.chess;

public class King : Piece
{
    public King(Chessboard chessboard, Color color) : base(color, chessboard)
    {

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

        return mat;
    }
}
