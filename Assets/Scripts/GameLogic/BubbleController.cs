using UnityEngine;

public class BubbleController : MonoBehaviour, IBubbleReturner
{
    private ObjectPool pool;
    [SerializeField]
    private Sprite[] InnerImages;
    [SerializeField]
    private Sprite BombImage;

    public float bubbleSpawnSpeed;
    [Range(0, 100)]
    public float bombSpawnRate;
    [SerializeField]
    private int maxBubbleCount;
    private int curBubbleCount;
    [SerializeField]
    private float bubbleMoveSpeed;
    [SerializeField]
    private Transform[] spawnPoint;

    private IEndGame endGame;

    private float timer;

    private void Awake()
    {
        pool = GetComponent<ObjectPool>();
        endGame = GameObject.FindWithTag(Tags.Managers).GetComponent<IEndGame>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= bubbleSpawnSpeed)
        {
            timer = 0;
            SpawnBubble();
        }
    }

    //버블 소환
    public void SpawnBubble()
    {
        if (!endGame.IsGameRunning || curBubbleCount >= maxBubbleCount)
        {
            return;
        }
        Bubble bubble;
        if (Random.Range(0, 100) < bombSpawnRate)
        {
            MakeBombBubble(out bubble);
        }
        else
        {
            MakeBubble(out bubble);
        }
        bubble.Moveable.Speed = bubbleMoveSpeed;
        bubble.transform.position = Vector2.Lerp(spawnPoint[0].position, spawnPoint[1].position, Random.value);
        curBubbleCount++;
    }

    //버블 생성
    public void MakeBubble(out Bubble bubble)
    {
        bubble = pool.GetObject(PoolType.Bubble).GetComponent<Bubble>();
        var random = Random.Range(0, InnerImages.Length);
        bubble.GetComponent<ImageSetter>().SetSprite(InnerImages[random]);
    }
    //폭탄 버블 생성
    public void MakeBombBubble(out Bubble bubble)
    {
        bubble = pool.GetObject(PoolType.BombBubble).GetComponent<Bubble>();
        bubble.GetComponent<ImageSetter>().SetSprite(BombImage);
    }

    //버블 삭제 및 현재 버블 카운트 조절
    public void ReturnBubble(GameObject bubble)
    {
        curBubbleCount--;
        pool.ReturnObject(bubble);
    }

    //버블 최대 카운트 설정
    public void SetMaxBubbleCount(int count)
    {
        maxBubbleCount = count;
    }

    //버블 이동 속도 설정
    public void SetBubbleMoveSpeed(float speed)
    {
        bubbleMoveSpeed = speed;
    }
}
