namespace Snake;

public class Board
{
    internal static List<Position> border;
    public bool IsPositionOnBorder(Position pos)
    {
       return border.Contains(pos);
    }

    public void CalculateBorder(int height, int width)
    {
        
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    Position newBorderPosition = new Position(row, col);
                    border.Add(newBorderPosition);
                }
            }
            
            // BUUHH SO mroe research into Lists and Arrays etc. WE cooked chat
        }
    }
}