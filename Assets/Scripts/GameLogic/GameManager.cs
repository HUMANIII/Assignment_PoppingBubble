using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int BestScore { get; private set; }
    public int TargetScore { get; private set; } = 250;

    // ���� ����� ȣ��
    public void SaveScore(int curScore)
    {
        if(curScore > BestScore)
        {
            BestScore = curScore;
        }
    }    
}
