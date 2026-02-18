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
        const int height = 20;
        const int width = 40;
        var logic = new GameLogic(Printer, height, width);
        logic.Start();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                var dir = key switch
                {
                    ConsoleKey.W => Direction.Up,
                    ConsoleKey.A => Direction.Left,
                    ConsoleKey.S => Direction.Down,
                    ConsoleKey.D => Direction.Right,
                    _ => (Direction?)null,
                };

                if (dir.HasValue)
                {
                    logic.SetDirection(dir.Value);
                }
            }
        }
    }
}
