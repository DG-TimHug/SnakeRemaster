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
    private bool IsOpposite(Direction currentDir, Direction newDir)
    {
        return (currentDir == Direction.Left && newDir == Direction.Right) ||
               (currentDir == Direction.Right && newDir == Direction.Left) ||
               (currentDir == Direction.Up && newDir == Direction.Down) ||
               (currentDir == Direction.Down && newDir == Direction.Up);
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
        Checks();
        renderer.SnakeHead(snake.Head);
        renderer.SnakeBody(snake.Body.ToList());
    }
    
    private void Checks()
    {
        if (snake.IsSnakeInSelf(snake.Head))
        {
            EndGame();
            Console.WriteLine("Collision with self");
        }

        if (board.IsPosOnBorder(snake.Head))
        {
            EndGame();
            Console.WriteLine("Collision with Border");
        }
    }

    private void EndGame()
    {
        gameTimer.Dispose();
        Console.WriteLine("Game Over!");
    }
}