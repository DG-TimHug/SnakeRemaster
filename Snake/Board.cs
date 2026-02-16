namespace Snake;

public class Board
{
    public Board(int height, int width)
    {
        this.height = height;
        this.width = width;
        CalculateBorder();
    }

    private int height;
    private int width;
    private readonly Random random = new();

    public readonly List<Position> Border = new();

    private void CalculateBorder()
    {
        // TODO: More efficient way of calculating border
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    Border.Add(new Position(col, row));
                }
            }
        }
    }

    public bool IsPosOnBorder(Position pos)
    {
        return Border.Contains(pos);
    }

    public Position Apple;

    public void SpawnApple(Position head, List<Position> body)
    {
        if (!IsPosOnBorder(Apple))
        {
            Position newApple;
            do
            {
                newApple = new Position(
                    random.Next(1, width - 1),
                    random.Next(1, height - 1)
                );
            }
            while 
            (
                newApple == head || body.Contains(newApple)
            );

            Apple = newApple;

        }
    }
}