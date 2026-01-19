using Snake;

namespace SnakeConsole;

class SnakeConsole
{
    static void Main()
    {
        ConsoleSetup setup = new ConsoleSetup();
        setup.Setup();

        foreach (var position in setup.Border)
        {
            Console.WriteLine($"X={position.X}, Y={position.Y}");
        }
    }
}

public class ConsoleSetup : GameLogic.IGameBoardPrinter
{
    public List<Position> Border { get; set; } = new ();
    
    private GameLogic logic = new GameLogic();
    
    public void Setup()
    {
        logic.Height = 16;
        logic.Width = 16;
        logic.Setup();
        Border = logic.Border;
    }
}