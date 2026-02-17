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
    private bool isEating;  

    public void Start()
    {
        board.SpawnApple(snake);

        gameTimer = new Timer(170);
        gameTimer.Elapsed += (_, _) => GameLoop();
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
        snake.Move();
        
        if (snake.IsPositionInSnake(snake.Head))
        {
            EndGame();
            Console.WriteLine("Collision with self");
        }

        if (board.IsPositionOnBorder(snake.Head))
        {
            EndGame();
            Console.WriteLine("Collision with Border");
        }

        if (board.Apple == snake.Head)
        {
            isEating = true;
        }
        
        snake.Grow();
        if (isEating)
        {
            board.SpawnApple(snake);
            isEating = false;
        }
        Render();
    }
    
    private void EndGame()
    {
        gameTimer.Dispose();
        Console.WriteLine("Game Over!");
        
    }

    private void Render()
    {
        renderer.Border(board.Border);
        renderer.Apple(board.Apple);
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body.ToList());
    }
}