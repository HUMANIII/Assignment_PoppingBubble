using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreValueText;
    [SerializeField]
    private TextMeshProUGUI ComboValueText;
    [SerializeField]
    private GameObject ComboGameObject;
    [SerializeField]
    private GameObject scoreGameObject;
    private IScore score;

    private void Awake()
    {
        score = scoreGameObject.GetComponent<IScore>();    
    }
    // 점수판에 점수 최신화
    public void SetScore()
    {
        scoreValueText.text = score.Score.ToString();
        if(ComboValueText == null)
            return;
        if(score.Combo >= 1)
        {
            if (!ComboGameObject.activeSelf)
            {
                ComboGameObject.SetActive(true);
            }
            ComboValueText.text = score.Combo.ToString();
        }
        else
        {
            if (ComboGameObject.activeSelf)
            {
                ComboGameObject.SetActive(false);
            }
        }
    }

    public void SetScore(int value)
    {
        scoreValueText.text = value.ToString();
    }
}
