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
            Console.ForegroundColor = ConsoleColor.Yellow;
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

    public void Apple(Position apple)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(apple.X, apple.Y);
        Console.Write("@");
    }
    
    public void Level(Position levelPosition, int level)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(levelPosition.X, levelPosition.Y);
        Console.Write($"Your current level is {level}.");
    }

    public void ClearSnake(Snake.Snake snake)
    {
        foreach (var part in snake.Body)
        {
            Console.SetCursorPosition(part.X, part.Y);
            Console.Write(" ");
        }
    }
}
