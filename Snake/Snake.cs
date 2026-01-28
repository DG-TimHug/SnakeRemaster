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
    
    public void Move()
    {
        Position oldHead = Head;

        ChangeDirection(20);

        Body.Insert(0, oldHead);
        
        RemovedTail = Body[^1];

        Body.RemoveAt(Body.Count - 1);
    }

    public void ChangeDirection(int direction)
    {
        switch (direction)
        {
            case 10:
            {
                //Set Direction right
                Head = new Position(Head.X + 1, Head.Y);
                break;
            }
            case 20:
            {
                //Direction UP
                Head = new Position(Head.X, Head.Y + 1);
                break;
            }
            case 30:
            {
                //direction left
                Head = new Position(Head.X -1, Head.Y);
                break;
            }
            case 40:
            {
                //direction down
                Head = new Position(Head.X, Head.Y - 1);
                break;
            }
        }
    }
}