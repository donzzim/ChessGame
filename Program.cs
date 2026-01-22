using ChessGame;
using ChessGame.chessboard;
using ChessGame.chess;

try
{
    Chessboard cb = new Chessboard(8, 8);

    cb.PlacePiece(new Rook(cb, Color.Black), new Position(0, 0));
    cb.PlacePiece(new Rook(cb, Color.Black), new Position(1, 3));
    cb.PlacePiece(new King(cb, Color.Black), new Position(0, 9));
    Screen.PrintScreen(cb);
}
catch (ChessboardException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();
