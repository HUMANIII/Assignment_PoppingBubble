using TMPro;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI resultText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private GameObject scoreGameObject;
    private IScore score;

    private void Awake()
    {
        score = scoreGameObject.GetComponent<IScore>();
    }

    private void OnEnable()
    {
        SetResultPanel();
    }

    //결과창 설정
    private void SetResultPanel()
    {
        if (score.Score >= GameManager.Instance.TargetScore)
        {
            resultText.text = "You Win!";
        }
        else
        {
            resultText.text = "You Lose!";
        }
        scoreText.text = score.Score.ToString();
        bestScoreText.text = GameManager.Instance.BestScore.ToString();
    }
}
