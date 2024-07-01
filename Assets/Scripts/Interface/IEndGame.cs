using UnityEngine;

public interface IEndGame
{
    public bool IsGameRunning { get; }
    public void EndGame();
}
