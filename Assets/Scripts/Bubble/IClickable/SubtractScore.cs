using UnityEngine;

public class SubtractScore : MonoBehaviour, IClickable
{
    [SerializeField]
    private int score;
    private IScoreSubtracter ScoreSubtracter;

    private void Awake()
    {
        GameObject.FindWithTag(Tags.Managers).TryGetComponent(out ScoreSubtracter);
    }
    public void OnClick()
    {
        ScoreSubtracter.SubtractScore(score);
    }
}