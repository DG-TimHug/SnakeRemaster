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
    
    public Position Apple;

    private void CalculateBorder()
    {
        // TODO: More efficient way of calculating border
        for (var row = 0; row < height; row++)
        {
            for (var col = 0; col < width; col++)
            {
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    Border.Add(new Position(col, row));
                }
            }
        }
    }

    public bool IsPositionOnBorder(Position pos)
    {
        return Border.Contains(pos);
    }

    public void SpawnApple(Snake snake)
    {
        Position newApple;
        do
        {
            newApple = new Position(
                random.Next(1, width - 1),
                random.Next(1, height - 1)
            );
        } while
        (
            IsPositionOnBorder(newApple) || snake.IsPositionOnSnake(newApple)
        );

        Apple = newApple;
    }
}