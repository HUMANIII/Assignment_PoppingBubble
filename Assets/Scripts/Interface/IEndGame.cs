using System;

public interface IEndGame
{
    public Action GameFinished { get; set; }
    public bool IsGameRunning { get; }
    public void EndGame();
}
