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

    public Direction currentDirection = Direction.Right;

    private void SetInitialLength()
    {
        Body.Clear();

        Body.Add(new Position(4, 4));
        Body.Add(new Position(3, 4));
    }
    
    public enum Direction
    {
        Left,   
        Right,
        Up,
        Down
    }
    public void SetDirection(Direction dir)
    {
        currentDirection = dir;
    }
    
    public void Move()
    {
        Position oldHead = Head;

        ChangeDirection();

        Body.Insert(0, oldHead);
        
        RemovedTail = Body[^1];

        Body.RemoveAt(Body.Count - 1);
    }

    private void ChangeDirection()
    {
        switch (currentDirection)
        {
            case Direction.Right:
            {
                Head = new Position(Head.X + 1, Head.Y);
                break;
            }
            case Direction.Up:
            {
                Head = new Position(Head.X, Head.Y - 1);
                break;
            }
            case Direction.Left:
            {
                Head = new Position(Head.X -1, Head.Y);
                break;
            }
            case Direction.Down:
            {
                Head = new Position(Head.X, Head.Y + 1);
                break;
            }

            default:
            {
                Head = new Position(Head.X + 1, Head.Y);
                break;
            }
        }
    }
}