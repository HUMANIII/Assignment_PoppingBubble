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
    [SerializeField, Tooltip("�޺� �� �������� ����")]
    private int comboBonus = 50;

    public bool IsGameRunning { get; private set; }
    

    private void Start()
    {
        IsGameRunning = true;
    }
    // ���� ����� ȣ��
    public void EndGame()
    {
        Debug.Log("Time's up!");
        IsGameRunning = false;
        GameManager.Instance.GameOver(Score);              
    }
    // ���� �����
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
