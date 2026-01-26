namespace Snake;

public class Snake
{
    public Snake()
    {
        SetInitialLength();
    }
    public readonly List<Position> Body = new();
    public Position Head { get; set;} = new (5,4);

    private void SetInitialLength()
    {
        Body.Clear();
        for (int i = 1; i < 3; i++)
        {
            Body.Add(new Position(Head.X - i, Head.Y));
        }
    }
}