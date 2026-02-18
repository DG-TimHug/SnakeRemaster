using Timer = System.Timers.Timer;

namespace Snake;

public class GameLogic
{
    public GameLogic(IGameRenderer renderer, int height, int width)
    {
        this.renderer = renderer;
        board = new Board(height, width);
        GameLogic.height = height;
        GameLogic.width = width;
    }

    private static int height;
    private static int width;
    private readonly IGameRenderer renderer;
    private readonly Board board;
    private readonly Snake snake = new();
    private Timer? gameTimer;
    private Position LevelCounter { get; set; } = new(width, height + 20);

    public void Start()
    {
        board.SpawnApple(snake);
        renderer.Border(board.Border);

        gameTimer = new Timer(170);
        gameTimer.Elapsed += (_, _) => GameLoop();
        gameTimer.Start();
    }

    private bool IsOpposite(Direction currentDirection, Direction newDirection)
    {
        return (currentDirection == Direction.Left && newDirection == Direction.Right)
            || (currentDirection == Direction.Right && newDirection == Direction.Left)
            || (currentDirection == Direction.Up && newDirection == Direction.Down)
            || (currentDirection == Direction.Down && newDirection == Direction.Up);
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
        renderer.ClearSnake(snake);
        snake.Move();

        if (snake.IsEatingSelf())
        {
            EndGame();
            Console.WriteLine("Collision with self");
            Environment.Exit(-1);
        }

        if (board.IsPositionOnBorder(snake.Head))
        {
            EndGame();
            Console.WriteLine("Collision with Border");
            Environment.Exit(-1);
        }

        if (snake.IsEating(board.Apple))
        {
            board.SpawnApple(snake);
            snake.Grow();
        }

        Render();
    }

    private void EndGame()
    {
        gameTimer.Dispose();
        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine($"You got to Level {snake.Body.Count}. Good Job!");
    }

    private void Render()
    {
        renderer.Apple(board.Apple);
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body.ToList());
        renderer.Level(LevelCounter, snake.Body.Count);
    }
}
