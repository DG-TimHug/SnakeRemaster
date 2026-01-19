namespace Snake;

public class GameLogic : GameLogic.IGameBoardPrinter
{
    public interface IGameBoardPrinter
    {
        List<Position> Border { get; set; }
    }

    public List<Position> Border { get; set; } = new();
    public int Width { get; set; }  
    public int Height { get; set; }
    public bool IsGameAlive = false;
    Board board = new Board();

    public void Setup()
    {
        System.Timers.Timer gameTimer = new (150);
        
        board.CalculateBorder(Height, Width);
        Border = board.Border;
        //gameTimer.Elapsed += (_,_) =>
        //{
        //     if (!isGameAlive)
        //     {
        //         //TODO: GameOver Mechanic
        //         return;
        //     }
        //     GameLoop();
        //};
        //gameTimer.Start();
    }
    
    public void GameLoop()
    {
        
    }
}