namespace Snake;

public class GameLogic
{
    public GameLogic(IGameRenderer renderer, int height, int width)
    {
        this.renderer = renderer;
        board = new Board(height, width);
    }
    
    private readonly IGameRenderer renderer;
    private readonly Board board;
    private readonly Snake snake = new();
    public static readonly List<Position> Border = new();
    private bool isGameOver;

    public void Start()
    {
        isGameOver = false;
        System.Timers.Timer gameTimer = new (150);
        gameTimer.Elapsed += (_,_) =>
        {
             if (isGameOver)
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
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body);
    }
}