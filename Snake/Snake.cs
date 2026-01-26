namespace Snake;

public class Snake
{
    public readonly List<Position> Body = new();
    public Position Head { get; set;} = new(10, 5);
}