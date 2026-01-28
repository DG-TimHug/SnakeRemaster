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

    private void SetInitialLength()
    {
        Body.Clear();

        Body.Add(new Position(4, 4));
        Body.Add(new Position(3, 4));
    }
    
    public void Move(GameLogic.Direction currentDirection)
    {
        Position oldHead = Head;

        ChangeDirection(currentDirection);

        Body.Insert(0, oldHead);
        
        RemovedTail = Body[^1];

        Body.RemoveAt(Body.Count - 1);
    }

    private void ChangeDirection(GameLogic.Direction currentDirection)
    {
        switch (currentDirection)
        {
            case GameLogic.Direction.Right:
            {
                Head = new Position(Head.X + 1, Head.Y);
                break;
            }
            case GameLogic.Direction.Up:
            {
                Head = new Position(Head.X, Head.Y - 1);
                break;
            }
            case GameLogic.Direction.Left:
            {
                Head = new Position(Head.X -1, Head.Y);
                break;
            }
            case GameLogic.Direction.Down:
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