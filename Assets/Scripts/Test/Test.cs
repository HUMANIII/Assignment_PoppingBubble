using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private StageManager stageManager;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))//���� ����� Ŭ���� �۵�
        {
            stageManager.AddScore(50);
        }
        if(Input.GetKeyDown(KeyCode.A))//��ź ����� Ŭ���� �۵�
        {
            stageManager.SubtractScore(50);
        }
    }
}
