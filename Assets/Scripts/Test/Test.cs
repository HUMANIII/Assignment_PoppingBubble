using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private StageManager stageManager;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))//점수 물방울 클릭시 작동
        {
            stageManager.AddScore(50);
        }
        if(Input.GetKeyDown(KeyCode.A))//폭탄 물방울 클릭시 작동
        {
            stageManager.SubtractScore(50);
        }
    }
}
