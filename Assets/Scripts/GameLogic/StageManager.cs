using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour, IEndGame, IScore, IScoreAdder, IScoreSubtracter
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private ScoreBoard scoreBoard;

    public int Score { get; set; }
    public int Combo { get; set; }
    [SerializeField, Tooltip("콤보 시 더해지는 점수")]
    private int comboBonus = 50;

    public bool IsGameRunning { get; private set; }
    

    private void Start()
    {
        IsGameRunning = true;
    }
    // 게임 종료시 호출
    public void EndGame()
    {
        Debug.Log("Time's up!");
        IsGameRunning = false;
        GameManager.Instance.GameOver(Score);              
    }
    // 게임 재시작
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
