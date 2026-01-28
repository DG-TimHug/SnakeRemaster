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
    private static Direction currentDirection;

    public enum Direction
    {
        Left,   
        Right,
        Up,
        Down
    }

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
    
    public void SetDirection(Direction dir)
    {
        currentDirection = dir;
    }
    
    private void GameLoop()
    {
        Console.Clear();
        if (firstRender)
        {
            renderer.Border(Border);
        }
        
        snake.Move(currentDirection);
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body);
    }
}