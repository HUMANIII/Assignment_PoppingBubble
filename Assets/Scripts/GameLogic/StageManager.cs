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
        GameManager.Instance.LoadScore();
        targetScoreBoard.SetScore(GameManager.Instance.TargetScore);
        bestScoreBoard.SetScore(GameManager.Instance.BestScore);
        resultPanel.SetActive(false);
    }
    // ���� ����� ȣ��
    public void EndGame()
    {
        Debug.Log("Time's up!");
        IsGameRunning = false;
        GameManager.Instance.SaveScore(Score);
        resultPanel.SetActive(true);
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
