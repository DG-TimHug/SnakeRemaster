namespace Snake;

public class Board 
{
    public Board(int height, int width)
    {
        CalculateBorder(height, width);
    }
    
    public readonly List<Position> Border = new();
    
    private void CalculateBorder(int height, int width)
    {
       // TODO: More efficient way of calculating border
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    Border.Add(new Position(row, col));
                }
            }
            
        }
    }
}