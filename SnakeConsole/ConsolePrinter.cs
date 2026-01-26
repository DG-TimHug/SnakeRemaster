using Snake;

namespace SnakeConsole;

public class ConsolePrinter : IGameRenderer
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