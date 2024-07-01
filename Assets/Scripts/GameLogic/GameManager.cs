using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int BestScore { get; private set; }
    public int TargetScore { get; private set; } = 250;

    // 게임 종료시 호출
    public void SaveScore(int curScore)
    {
        if(curScore > BestScore)
        {
            BestScore = curScore;
        }
    }    
}
