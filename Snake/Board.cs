using System.ComponentModel;

namespace Snake;

public class Board
{
    public Position[] border = [];
    public bool IsPositionOnBorder(Position pos)
    {
       return border.Contains(pos);
    }

    public void BorderStuff(int height, int width)
    {
        Position[,] localborder = new Position[,];
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    localborder[row, col]
                }
            }
            
            // BUUHH SO mroe research into Lists and Arrays etc. WE cooked chat
        }
    }
}