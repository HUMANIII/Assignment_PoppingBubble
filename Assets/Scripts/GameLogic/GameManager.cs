using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int BestScore { get; private set; }
    public int TargetScore { get; private set; }

    // 게임 종료시 호출
    public void GameOver(int curScore)
    {
        if(curScore > BestScore)
        {
            BestScore = curScore;
        }
    }    
}
