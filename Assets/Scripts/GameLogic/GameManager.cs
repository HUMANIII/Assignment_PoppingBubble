using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int BestScore { get; private set; }
    public int TargetScore { get; private set; }

    public void LoadScore()
    {
        SaveLoadSystem.Load();
        TargetScore = SaveLoadSystem.SaveData.TargetScore;
        BestScore = SaveLoadSystem.SaveData.BestScore;
    }
    // 게임 점수 저장
    public void SaveScore(int curScore)
    {
        if(curScore > BestScore)
        {
            BestScore = curScore;
        }
        SaveLoadSystem.SaveData.BestScore = BestScore;
        SaveLoadSystem.SaveData.TargetScore = TargetScore;
        SaveLoadSystem.Save();
    }    
}
