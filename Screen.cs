
namespace ChessGame;

public class Screen
{
    public static void printScreen(Chessboard.Chessboard cb)
    {
        for (int i = 0; i < cb.Rows; i++)
        {
            for (int j = 0; j < cb.Columns; j++)
            {
                if (cb.Piece(i, j) == null)
                {
                    Console.Write("- ");
                }
                else
                {
                    Console.Write(cb.Piece(i, j) + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
