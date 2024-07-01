using UnityEngine;

public class AddScore : MonoBehaviour, IClickable
{
    [SerializeField]
    private int score;
    private IScoreAdder ScoreAdder;

    private void Awake()
    {
        GameObject.FindWithTag(Tags.Managers).TryGetComponent(out ScoreAdder);
    }
    public void OnClick()
    {
        ScoreAdder.AddScore(score);
    }
}