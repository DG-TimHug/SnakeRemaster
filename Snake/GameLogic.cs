using Timer = System.Timers.Timer;
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
    private Timer gameTimer;

    public void Start()
    {
        gameTimer = new Timer(170);
        gameTimer.Elapsed += (_, _) => { GameLoop(); };
        gameTimer.Start();
    }
    private bool IsOpposite(Direction currentDirection, Direction newDirection)
    {
        return (currentDirection == Direction.Left && newDirection == Direction.Right) ||
               (currentDirection == Direction.Right && newDirection == Direction.Left) ||
               (currentDirection == Direction.Up && newDirection == Direction.Down) ||
               (currentDirection == Direction.Down && newDirection == Direction.Up);
    }
    
    public void SetDirection(Direction dir)
    {
        if (IsOpposite(snake.CurrentDirection, dir))
        {
            return;
        }

        snake.CurrentDirection = dir;
    }

    private void GameLoop()
    {
        Console.Clear();
        renderer.Border(board.Border);
        snake.Move();
        
        if (snake.IsSnakeInSelf(snake.Head))
        {
            EndGame();
            Console.WriteLine("Collision with self");
        }

        if (board.IsPositionOnBorder(snake.Head))
        {
            EndGame();
            Console.WriteLine("Collision with Border");
        }
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body.ToList());
    }
    
    private void EndGame()
    {
        gameTimer.Dispose();
        Console.WriteLine("Game Over!");
        
    }
}