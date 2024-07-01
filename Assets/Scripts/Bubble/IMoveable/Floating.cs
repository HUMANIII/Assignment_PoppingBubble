using UnityEngine;

public class Floating : MonoBehaviour, IMoveable
{
    public float Speed { get; set; }

    public void Move()
    {
        var pos = transform.position;
        pos.y += Time.deltaTime * Speed;
        gameObject.transform.position = pos;
    }
}
