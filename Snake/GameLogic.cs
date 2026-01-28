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
        System.Timers.Timer gameTimer = new (170);
        gameTimer.Elapsed += (_,_) =>
        {
             GameLoop();
        };
        gameTimer.Start();
    }
    
    public void SetDirection(Direction newDir)
    {
        if (IsOpposite(currentDirection, newDir))
        {
             return;
        }
           
        currentDirection = newDir;
    }
    
    private void GameLoop()
    {
        Console.Clear();
        renderer.Border(board.Border);
        snake.Move(currentDirection);
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body);
    }
    
    private bool IsOpposite(Direction currentDir, Direction newDir)
    {
        return (currentDir == Direction.Left && newDir == Direction.Right) ||
               (currentDir == Direction.Right && newDir == Direction.Left) ||
               (currentDir == Direction.Up && newDir == Direction.Down) ||
               (currentDir == Direction.Down && newDir == Direction.Up);
    }

}