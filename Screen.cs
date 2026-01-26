
using ChessGame.chess;
using ChessGame.chessboard;

namespace ChessGame;

public class Screen
{
    public static void PrintScreen(chessboard.Chessboard cb)
    {
        for (int i = 0; i < cb.Rows; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < cb.Columns; j++)
            {
                PrintPiece(cb.Piece(i, j));
            }
            Console.WriteLine();
        }

        Console.WriteLine(" a b c d e f g h");
    }

    public static void PrintScreen(chessboard.Chessboard cb, bool[,] possiblePositions)
    {
        ConsoleColor originalBackgroundColor = Console.BackgroundColor;
        ConsoleColor modifiedBackgroundColor = ConsoleColor.DarkGray;

        for (int i = 0; i < cb.Rows; i++)
        {
            Console.Write(8 - i + " ");
            for (int j = 0; j < cb.Columns; j++)
            {
                if (possiblePositions[i, j])
                {
                    Console.BackgroundColor = modifiedBackgroundColor;
                }
                else
                {
                    Console.BackgroundColor = originalBackgroundColor;
                }
                PrintPiece(cb.Piece(i, j));
                Console.BackgroundColor = originalBackgroundColor;
            }
            Console.WriteLine();
        }
        Console.WriteLine(" a b c d e f g h");
        Console.BackgroundColor = originalBackgroundColor;
    }

    public static void PrintPiece(Piece piece)
    {
        if (piece == null)
        {
            Console.WriteLine("- ");
        }
        else
        {
            if (piece.Color == Color.White)
            {
                Console.WriteLine(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }

            Console.WriteLine(" ");
        }
    }

    public static ChessPosition ReadChessPosition()
    {
        string s = Console.ReadLine();
        char column = s[0];
        int row = int.Parse(s[1] + " ");
        return new ChessPosition(column, row);
    }
}
