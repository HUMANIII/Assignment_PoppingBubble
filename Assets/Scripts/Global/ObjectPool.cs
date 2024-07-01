using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Bubble,
    BombBubble,
    Count,
}

public class ObjectPool : MonoBehaviour
{
    private readonly Dictionary<PoolType, Stack<GameObject>> poolStacks = new();
    [SerializeField]
    private GameObject[] prefabs;

    private void Awake()
    {
        for (int i = 0; i < (int)PoolType.Count; i++)
        {
            Instantiate(new GameObject(((PoolType)i).ToString()), gameObject.transform);       
            poolStacks.Add((PoolType)i, new Stack<GameObject>());
        }
    }

    public GameObject GetObject(PoolType poolType)
    {
        if (!poolStacks.ContainsKey(poolType))
            return null;

        if (poolStacks[poolType].Count == 0)
        {
            var obj = Instantiate(prefabs[(int)poolType]);
            obj.transform.parent = gameObject.transform.GetChild((int)poolType);
            return obj;
        }
        GameObject GO = poolStacks[poolType].Pop();
        GO.SetActive(true);
        return GO;
    }

    public bool ReturnObject(GameObject GO)
    {
        if(!GO.TryGetComponent<IPoolable>(out var poolable))
            return false;
        poolable.OnReturn();
        GO.SetActive(false);
        poolStacks[poolable.PoolType].Push(GO);
        GO.transform.SetParent(gameObject.transform.GetChild((int)poolable.PoolType));
        return true;
    }

    public void Clear()
    {
        foreach (var effectQueue in poolStacks)
        {
            foreach (var effect in effectQueue.Value)
            {
                Destroy(effect);
            }
        }
    }

    private void OnDestroy()
    {
        Clear();
    }
}
public interface IPoolable
{
    public PoolType PoolType { get; }
    public void OnReturn();
}