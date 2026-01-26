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
    private bool firstRender;

    public void Start()
    {
        isGameOver = false;
        System.Timers.Timer gameTimer = new (230);
        firstRender = true;
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
        Console.Clear();
        
        renderer.Border(Border);
        snake.Move();
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body);
    }
}