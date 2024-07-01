using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour, IEndGame, IScore, IScoreAdder, IScoreSubtracter
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private ScoreBoard scoreBoard;
    [SerializeField]
    private ScoreBoard targetScoreBoard;
    [SerializeField]
    private ScoreBoard bestScoreBoard;
    [SerializeField]
    private GameObject resultPanel;

    public int Score { get; set; }
    public int Combo { get; set; }
    [SerializeField, Tooltip("콤보 시 더해지는 점수")]
    private int comboBonus = 50;

    public bool IsGameRunning { get; private set; }
    

    private void Start()
    {
        InitGame();
    }
    // 게임 초기화
    public void InitGame()
    {
        Score = 0;
        Combo = 0;
        scoreBoard.SetScore();
        timer.InitTimer();
        IsGameRunning = true;
        GameManager.Instance.LoadScore();
        targetScoreBoard.SetScore(GameManager.Instance.TargetScore);
        bestScoreBoard.SetScore(GameManager.Instance.BestScore);
        resultPanel.SetActive(false);
    }
    // 게임 종료시 호출
    public void EndGame()
    {
        Debug.Log("Time's up!");
        IsGameRunning = false;
        GameManager.Instance.SaveScore(Score);
        resultPanel.SetActive(true);
    }
    // 점수 추가
    public void AddScore(int amount)
    {
        Combo += 1;
        Score += amount + comboBonus;
        scoreBoard.SetScore();
    }
    // 점수 감소
    public void SubtractScore(int amount)
    {
        Combo = 0;
        Score -= amount;
        scoreBoard.SetScore();
    }
}
