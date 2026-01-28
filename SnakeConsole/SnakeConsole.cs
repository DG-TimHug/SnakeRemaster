using Snake;

namespace SnakeConsole;

internal abstract class SnakeConsole
{
    private static readonly ConsolePrinter Printer = new();

    public static void Main()
    {
        StartGame();
    }

    private static void StartGame()
    {
        Console.CursorVisible = false;
        int height = 20;
        int width = 40;
        var logic = new GameLogic(Printer, height, width);
        logic.Start();
        
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                var dir = key switch
                {
                    ConsoleKey.W => GameLogic.Direction.Up,
                    ConsoleKey.A => GameLogic.Direction.Left,
                    ConsoleKey.S => GameLogic.Direction.Down,
                    ConsoleKey.D => GameLogic.Direction.Right,
                    _ => (GameLogic.Direction?)null
                };

                if (dir.HasValue)
                {
                     logic.SetDirection(dir.Value);
                }
            }

        }
    }
}