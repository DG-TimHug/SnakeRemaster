namespace Snake;

public class Snake
{
    public Snake()
    {
        SetInitialLength();
    }
    public readonly List<Position> Body = new();
    public Position Head { get; set;} = new (5,4);
    public Position RemovedTail { get; set; }
    public Direction CurrentDirection { get; set; } = Direction.Right;

    private void SetInitialLength()
    {
        Body.Clear();

        Body.Add(new Position(4, 4));
        Body.Add(new Position(3, 4));
        Body.Add(new Position(2, 4));
        Body.Add(new Position(1, 4));
    }
    
    
    public void Move()
    {
        Position oldHead = Head;

        Head = CurrentDirection switch
        {
            Direction.Right => new Position(Head.X + 1, Head.Y),
            Direction.Up    => new Position(Head.X, Head.Y - 1),
            Direction.Left  => new Position(Head.X - 1, Head.Y),
            Direction.Down  => new Position(Head.X, Head.Y + 1),
            _               => Head
        };

        Body.Insert(0, oldHead);
    }
    
    public bool IsSnakeInSelf(Position pos)
    {
        return Body.Contains(pos);
    }

    public void Grow(bool ateApple)
    {
        if (!ateApple && Body.Count > 0)
        {
            RemovedTail = Body[^1];
            Body.RemoveAt(Body.Count - 1);
        }
        else
        {
            RemovedTail = null;
        }
    }


}

public enum Direction
{
    Left,   
    Right,
    Up,
    Down
    
}