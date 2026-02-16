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
    

    public void Start()
    {
        System.Timers.Timer gameTimer = new (230);
        gameTimer.Elapsed += (_,_) =>
        {
             GameLoop();
        };
        gameTimer.Start();
    }
    
    public void SetDirection(Direction dir)
    {
        snake.CurrentDirection = dir;
    }
    
    private void GameLoop()
    {
        Console.Clear();
        renderer.Border(board.Border);
        snake.Move();
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body);
    }
}