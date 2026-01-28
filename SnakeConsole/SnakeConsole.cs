using Snake;

namespace SnakeConsole;

internal abstract class SnakeConsole
{
    private static readonly ConsolePrinter Printer = new();

    public static void Main()
    {
        StartGame();
        /*
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W: 
                {
                    GameLogic.DirectionNumber
                    break;
                        
                }
                case ConsoleKey.A:
                {
                    game.SetDirection(Direction.Left); 
                    break;
                }
                case ConsoleKey.S:
                {
                    game.SetDirection(Direction.Down);
                    break;
                }
                case ConsoleKey.D:
                {
                    game.SetDirection(Direction.Right); 
                    break;
                }
            }
        }*/
        Console.ReadLine();
    }

    private static void StartGame()
    {
        Console.CursorVisible = false;
        int height = 20;
        int width = 40;
        var logic = new GameLogic(Printer, height, width);
        logic.Start();
    }
}