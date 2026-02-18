namespace Snake;

public interface IGameRenderer
{
    void Border(List<Position> border);
    void SnakeBody(List<Position> body);
    void SnakeHead(Position head);
    void Apple(Position apple);
    void ClearSnake(Snake snake);
    void Level(Position levelPosition, int level);
}
