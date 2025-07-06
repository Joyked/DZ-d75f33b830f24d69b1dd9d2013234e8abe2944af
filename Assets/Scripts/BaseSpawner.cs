using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;

    public Action SpawnObject;
    public Action EnableObject;
    public Action DisableObject;
    public Action<int> PoolCapacity; 
    
    protected ObjectPool<T> _pool;
    protected int _poolCapacity = 10;
    protected int _poolMaxSize = 100;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<T>
        (
            CreateObject,
            ActionOnGet,
            ActionOnRelease,
            ActionOnDestroy,
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    private void Start()
    {
        PoolCapacity?.Invoke(_pool.CountAll);

        for (int i = 0; i < _pool.CountAll; i++)
        {
            SpawnObject?.Invoke();
            EnableObject?.Invoke();
        }
    }

    protected virtual T CreateObject()
    {
        return Instantiate(_prefab);
    }
    
    protected virtual void ActionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        EnableObject?.Invoke();
        SpawnObject?.Invoke();
        PoolCapacity?.Invoke(_pool.CountAll);
    }

    protected virtual void ActionOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
        DisableObject?.Invoke();
    }

    protected virtual void ActionOnDestroy(T obj) =>
        Destroy(obj.gameObject);
}