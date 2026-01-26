using ChessGame;
using ChessGame.chessboard;
using ChessGame.chess;

try
{
    ChessMatch match = new ChessMatch();

    while (!match.Finished)
    {
        Console.Clear();
        Screen.PrintScreen(match.Board);

        Console.WriteLine();
        Console.Write("Origin: ");
        Position origin = Screen.ReadChessPosition().ToPosition();

        bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoves();

        Console.Clear();
        Screen.PrintScreen(match.Board, possiblePositions);

        Console.WriteLine();
        Console.Write("Destination: ");
        Position destination = Screen.ReadChessPosition().ToPosition();

        match.MakeMove(origin, destination);
    }
}
catch (ChessboardException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();
