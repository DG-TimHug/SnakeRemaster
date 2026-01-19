namespace Snake;

public class Board : GameLogic.IGameBoardPrinter
{
    public List<Position> Border { get; set; } = new ();
    public bool IsPositionOnBorder(Position pos)
    {
       return Border.Contains(pos);
    }

    public void CalculateBorder(int height, int width)
    {
       // TODO: More efficient way of calculating border
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (row == 0 || row == height - 1 || col == 0 || col == width - 1)
                {
                    Position newBorderPosition = new Position(row, col);
                    Border.Add(newBorderPosition);
                }
            }
            
        }
    }
}