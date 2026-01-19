using Snake;

namespace SnakeConsole;

class SnakeConsole
{
    static ConsoleSetup setup = new ConsoleSetup();
    static void Main()
    {
        setup.Setup();
        Print();
    }

    private static void Print()
    {
        foreach (var position in setup.Border)
        {
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write("#");
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