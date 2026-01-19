using Snake;

namespace SnakeConsole;

class Program
{
    static void Main()
    {
       
    }

    private static void UseData(GameLogic.IGameBoardPrinter data)
    {
        
    }

    private static int GetWindowHeight()
    {
        return 20;
        while (false)
        {
            Console.WriteLine("How tall should the playing field be?");
            if (int.TryParse(Console.ReadLine(), out var playingFieldHeight) && playingFieldHeight is >= 10 and <= 45)
            {
                return playingFieldHeight;
            }
            Console.WriteLine("Please enter a number between 10 and 45..");
        }
    }

    private static int GetWindowWidth()
    {
        return 20;
        while (false)
        {
            Console.WriteLine("How wide should the playing field be?");
            if (int.TryParse(Console.ReadLine(), out var playingFieldWidth) && playingFieldWidth is >= 20 and <= 100)
            {
                return playingFieldWidth;
            }
            Console.WriteLine("Please enter a number between 20 and 100..");
        }
    }
}