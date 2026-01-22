using ChessGame.chessboard;

namespace ChessGame.chess;

public class ChessPosition
{
    public char Column { get; set; }
    public int Row { get; set; }

    public ChessPosition(int row,char column)
    {
        Column = column;
        Row = row;
    }

    public Position ToPosition()
    {
        return new Position(8 - Row, Column - 'a');
    }

    public override string ToString()
    {
        return "" + Column + Row;
    }
}
