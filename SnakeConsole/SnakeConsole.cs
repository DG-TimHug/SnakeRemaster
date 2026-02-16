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
                    ConsoleKey.W => Snake.Snake.Direction.Up,
                    ConsoleKey.A => Snake.Snake.Direction.Left,
                    ConsoleKey.S => Snake.Snake.Direction.Down,
                    ConsoleKey.D => Snake.Snake.Direction.Right,
                    _ => (Snake.Snake.Direction?)null
                };

                if (dir.HasValue)
                {
                     logic.SetDirection(dir.Value);
                }
            }

        }
    }
}