using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;

    public Action ObjectSpawned;
    public Action ObjectEnabled;
    public Action ObjectDisabled;
    public Action<int> СapacityPoolChanged; 
    
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

    private void Start() =>
        СapacityPoolChanged?.Invoke(_pool.CountAll);

    protected virtual T CreateObject()
    {
        return Instantiate(_prefab);
    }
    
    protected virtual void ActionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
        ObjectEnabled?.Invoke();
        ObjectSpawned?.Invoke();
        СapacityPoolChanged?.Invoke(_pool.CountAll);
    }

    protected virtual void ActionOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
        ObjectDisabled?.Invoke();
    }

    protected virtual void ActionOnDestroy(T obj) =>
        Destroy(obj.gameObject);
}