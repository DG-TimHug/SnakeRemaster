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

    public void SnakeBody(List<Position> body)
    {
        foreach (var position in body)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(position.Y, position.X);
            Console.Write("o");
        }
    }

    public void SnakeHead(Position head)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(head.Y, head.X);
        Console.Write("0");
    }
}