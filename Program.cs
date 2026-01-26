using ChessGame;
using ChessGame.chessboard;
using ChessGame.chess;

try
{
    ChessMatch match = new ChessMatch();

    while (!match.Finished)
    {
        try
        {
            Console.Clear();
            Screen.PrintMatch(match);

            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = Screen.ReadChessPosition().ToPosition();
            match.ValidateOriginPosition(origin);

            bool[,] possiblePositions = match.Board.Piece(origin).PossibleMoves();

            Console.Clear();
            Screen.PrintScreen(match.Board, possiblePositions);

            Console.WriteLine();
            Console.Write("Destination: ");
            Position destination = Screen.ReadChessPosition().ToPosition();
            match.ValidateDestinationPosition(origin, destination);

            match.PerformTurn(origin, destination);
        }
        catch (ChessboardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
    Console.Clear();
    Screen.PrintMatch(match);
}
catch (ChessboardException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();
