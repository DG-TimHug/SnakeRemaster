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

        Head = new Position(Head.X + 1, Head.Y);

        Body.Insert(0, oldHead);
        
        RemovedTail = Body[^1];

        Body.RemoveAt(Body.Count - 1);
    }
}