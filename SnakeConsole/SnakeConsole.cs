using Snake;

namespace SnakeConsole;

internal abstract class SnakeConsole
{
    private static readonly ConsolePrinter Printer = new();

    public static void Main()
    {
        StartGame();
        Console.ReadLine(); // -> dass das spielfeld angezeigt wird. Sobald controls kommen, kann ich dass rauchen aber es ist gut genug für den moment :)
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