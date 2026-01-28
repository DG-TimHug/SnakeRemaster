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
    private Direction currentDirection = Direction.Right;

    public enum Direction
    {
        Left,   
        Right,
        Up,
        Down
    }

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
        currentDirection = dir;
    }
    
    private void GameLoop()
    {
        Console.Clear();
        renderer.Border(board.Border);
        snake.Move(currentDirection);
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body);
    }
}