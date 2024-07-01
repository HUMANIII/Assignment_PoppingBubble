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

    public int Score { get; set; }
    public int Combo { get; set; }
    [SerializeField, Tooltip("�޺� �� �������� ����")]
    private int comboBonus = 50;

    public bool IsGameRunning { get; private set; }
    

    private void Start()
    {
        InitGame();
    }
    // ���� �ʱ�ȭ
    public void InitGame()
    {
        Score = 0;
        Combo = 0;
        scoreBoard.SetScore();
        timer.InitTimer();
        IsGameRunning = true;
        targetScoreBoard.SetScore(GameManager.Instance.TargetScore);
        bestScoreBoard.SetScore(GameManager.Instance.BestScore);
    }
    // ���� ����� ȣ��
    public void EndGame()
    {
        Debug.Log("Time's up!");
        IsGameRunning = false;
        GameManager.Instance.SaveScore(Score);   
        if(Score >= GameManager.Instance.TargetScore)
        {
            Debug.Log("You Win!");
        }
        else
        {
            Debug.Log("You Lose!");
        }
    }
    // ���� �߰�
    public void AddScore(int amount)
    {
        Combo += 1;
        Score += amount + comboBonus;
        scoreBoard.SetScore();
    }
    // ���� ����
    public void SubtractScore(int amount)
    {
        Combo = 0;
        Score -= amount;
        scoreBoard.SetScore();
    }
}
