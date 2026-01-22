namespace ChessGame.Chessboard;

public class Chessboard
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    private Piece[,] Pieces;

    public Chessboard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Pieces = new Piece[Rows, Columns];
    }

    public Piece Piece(int row, int column)
    {
        return Pieces[row, column];
    }
}
