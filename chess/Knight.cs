using ChessGame.chessboard;

namespace ChessGame.chess;

public class Knight : Piece
{
    public Knight(Chessboard chessboard, Color color) : base(color, chessboard)
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

        int[,] moves =
        {
            { -2, -1 }, { -2,  1 },
            { -1, -2 }, { -1,  2 },
            {  1, -2 }, {  1,  2 },
            {  2, -1 }, {  2,  1 }
        };

        for (int i = 0; i < moves.GetLength(0); i++)
        {
            pos.DefineValues(
                Position.Row + moves[i, 0],
                Position.Column + moves[i, 1]
            );

            if (Chessboard.ValidPosition(pos) && AbleToMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
        }

        return mat;
    }

}
