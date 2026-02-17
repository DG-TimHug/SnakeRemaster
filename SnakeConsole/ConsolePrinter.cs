using Snake;

namespace SnakeConsole;

public class ConsolePrinter : IGameRenderer
{
    public void Border(List<Position> border)
    {
        foreach (var position in border)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("#");
        }
    }

    public void SnakeBody(List<Position> body)
    {
        foreach (var position in body)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write("o");
        }
    }

    public void SnakeHead(Position head)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(head.X, head.Y);
        Console.Write("0");
    }
}