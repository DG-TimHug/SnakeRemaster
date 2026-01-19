using System.Timers;
using Timer = System.Threading.Timer;

namespace Snake;

public class GameLogic
{
    public System.Timers.Timer GameTimer = new (150);
    public interface IGameBoardPrinter
    {
        List<Position> Border { get; set; }
    }

    public void GameLoop()
    {
        
    }
}

public class GameBoardPrinter : GameLogic.IGameBoardPrinter
{
    public List<Position> Border { get; set; }
    
    public void SetData()
    {
        Border = Board.border;
    }
}