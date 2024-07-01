using UnityEngine;

public class Bubble : MonoBehaviour,IPoolable
{
    [SerializeField]
    private PoolType poolType;
    public PoolType PoolType => poolType;

    //인터페이스를 사용하여 추가한 컴포넌트 사용시에도 유연하게 동작함을 의도
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