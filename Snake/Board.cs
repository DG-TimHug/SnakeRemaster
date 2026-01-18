namespace Snake;

public class Board
{
    private List<Position> border;
    public bool IsPositionOnBorder(Position pos)
    {
       return border.Contains(pos);
    }

    public void BorderStuff(int height, int width)
    {
        
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    Position newborderpos = new Position(row, col);
                    border.Add(newborderpos);
                }
            }
            
            // BUUHH SO mroe research into Lists and Arrays etc. WE cooked chat
        }
    }
}