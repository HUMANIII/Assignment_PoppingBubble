using UnityEngine;

public class ImageSetter : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public void SetSprite(in Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
