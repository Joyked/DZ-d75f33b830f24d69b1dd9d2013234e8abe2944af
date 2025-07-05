using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;

    public event Action SpawnObject;
    public event Action EnableObject;
    public event Action DisableObject;
    public Action PoolCapacity; 
    
    protected IObjectPool<T> _pool;
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
    
    protected virtual T CreateObject()
    {
        PoolCapacity?.Invoke();
        return Instantiate(_prefab);
    }
    
    protected virtual void ActionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        EnableObject?.Invoke();
        SpawnObject?.Invoke();
    }

    protected virtual void ActionOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
        DisableObject?.Invoke();
    }

    protected virtual void ActionOnDestroy(T obj) =>
        Destroy(obj.gameObject);
}