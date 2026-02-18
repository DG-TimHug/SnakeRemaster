namespace Snake;

public class Snake
{
    public Snake()
    {
        Body.Add(new Position(4, 4));
        Body.Add(new Position(3, 4));
    }

    public readonly List<Position> Body = new();
    public Position Head { get; private set; } = new(5, 4);
    private Position RemovedTail { get; set; }
    public Direction CurrentDirection { get; set; } = Direction.Right;

    public void Move()
    {
        var oldHead = Head;

        Head = CurrentDirection switch
        {
            Direction.Right => new Position(Head.X + 1, Head.Y),
            Direction.Up => new Position(Head.X, Head.Y - 1),
            Direction.Left => new Position(Head.X - 1, Head.Y),
            Direction.Down => new Position(Head.X, Head.Y + 1),
            _ => Head,
        };

        Body.Insert(0, oldHead);

        RemovedTail = Body[^1];
        Body.RemoveAt(Body.Count - 1);
    }

    public bool IsEatingSelf()
    {
        return Body.Contains(Head);
    }

    public bool IsPositionOnSnake(Position pos)
    {
        return Body.Contains(pos) || Head == pos;
    }

    internal void Grow()
    {
        Body.Add(RemovedTail);
    }

    public bool IsEating(Position apple)
    {
        return Head == apple;
    }
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down,
}
