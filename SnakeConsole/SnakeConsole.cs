using Snake;

namespace SnakeConsole;

internal abstract class SnakeConsole
{
    private static readonly ConsolePrinter Printer = new();

    public static void Main()
    {
        StartGame();
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.W:
                {
                    GameLogic.CurrentDirection = GameLogic.Direction.Up;
                    break;
                        
                }
                case ConsoleKey.A:
                {
                    GameLogic.CurrentDirection = GameLogic.Direction.Left; 
                    break;
                }
                case ConsoleKey.S:
                {
                    GameLogic.CurrentDirection = GameLogic.Direction.Down;
                    break;
                }
                case ConsoleKey.D:
                {
                    GameLogic.CurrentDirection = GameLogic.Direction.Right;
                    break;
                }
            }
        }
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