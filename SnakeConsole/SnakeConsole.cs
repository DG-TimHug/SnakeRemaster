using Snake;

namespace SnakeConsole;

internal class SnakeConsole
{
    private static readonly ConsolePrinter Printer = new();
    private static readonly GameLogic Logic = new(Printer);
    public static void Main()
    {
        StartGame();
        Console.ReadLine(); // -> dass das spielfeld angezeigt wird. Sobald controls kommen, kann ich dass rauchen aber es ist gut genug für den moment :)
    }

    private static void StartGame()
    {
        Console.CursorVisible = false;
        GameLogic.Height = 16; //Will be defined by user at some point :)
        GameLogic.Width = 16;
        Logic.Setup();
    }
}

public class ConsolePrinter : Interfaces.IGameRenderer
{
    public void Border(List<Position> border)
    {
        foreach (var position in border)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(position.Y, position.X);
            Console.Write("#");
        }
    }
}