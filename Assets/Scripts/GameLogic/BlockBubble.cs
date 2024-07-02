using UnityEngine;

public class BlockBubble : MonoBehaviour
{
    private IBubbleReturner bubbleReturner;

    private void Awake()
    {
        bubbleReturner ??= GameObject.FindWithTag(Tags.Managers).GetComponent<IBubbleReturner>();
    }

    //����� ������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Bubble))
        {
            bubbleReturner.ReturnBubble(collision.gameObject);
        }
    }
}
