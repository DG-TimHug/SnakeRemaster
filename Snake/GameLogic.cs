namespace Snake;

public class GameLogic(Interfaces.IGameRenderer renderer)
{
    public static readonly List<Position> Border = new();
    public static int Width { get; set; }  
    public static int Height { get; set; }
    private bool isGameAlive;
    private readonly Board board = new ();

    public void Setup()
    {
        isGameAlive = true;
        System.Timers.Timer gameTimer = new (150);
        board.CalculateBorder(Height, Width);
        gameTimer.Elapsed += (_,_) =>
        {
             if (!isGameAlive)
             {
                 gameTimer.Stop();
                 gameTimer.Dispose();
                 return;
             }
             GameLoop();
        };
        gameTimer.Start();
    }

    private void GameLoop()
    {
        renderer.Border(Border);
    }

    public void Over()
    {
        if (!isGameAlive)
        {
            Console.WriteLine("Game Over!");
        }
    }
}