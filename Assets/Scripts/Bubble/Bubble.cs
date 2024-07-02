using UnityEngine;

public class Bubble : MonoBehaviour,IPoolable
{
    [SerializeField]
    private PoolType poolType;
    public PoolType PoolType => poolType;

    //�������̽��� ����Ͽ� �߰��� ������Ʈ ���ÿ��� �����ϰ� �������� �ǵ�
    public IMoveable Moveable { get; private set; }
    public IClickable Clickable { get; private set; }
    public IBubbleReturner BubbleReturner { get; private set; }
    public IEndGame endGame { get; private set; }

    private void Awake()
    {
        Moveable = GetComponent<IMoveable>();
        Clickable = GetComponent<IClickable>();
        BubbleReturner = GameObject.FindWithTag(Tags.Managers).GetComponent<IBubbleReturner>();
        endGame = GameObject.FindWithTag(Tags.Managers).GetComponent<IEndGame>();
        endGame.GameFinished += () => BubbleReturner.ReturnBubble(gameObject);
    }
    private void Update()
    {
        Moveable.Move();
    }
    private void OnMouseDown()
    {
        Clickable.OnClick();
        BubbleReturner.ReturnBubble(gameObject);
    }
    public void OnReturn()
    {
    }
}