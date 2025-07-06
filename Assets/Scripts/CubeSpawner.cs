using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;

public class CubeSpawner : BaseSpawner<Cube>
{
    public event Action<Vector3> PositionForSpawnBomb;
    
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;
    [SerializeField] private BombSpawner _bombSpawner;

    private List<Cube> _cubes;
    
    protected override void Awake()
    {
        _cubes = new List<Cube>();
        _bombSpawner.SetParameters(_poolCapacity, _poolMaxSize);
        base.Awake();

        for (int i = _poolCapacity; i > 0; i--)
            _pool.Get();
    }

    protected override Cube CreateObject()
    {
        Cube cube = Instantiate(_prefab);
        cube.Fell += ReturnToPool;
        _cubes.Add(cube);
        return cube;
    }

    private void OnDisable()
    {
        foreach (var cube in _cubes)
            cube.Fell -= ReturnToPool;
    }

    protected override void ActionOnRelease(Cube obj)
    {
        base.ActionOnRelease(obj);
        _pool.Get();
    }

    protected override void ActionOnGet(Cube obj)
    {
        base.ActionOnGet(obj);  
        
        float minX = -7f;
        float maxX = 8f;
        float minZ = -4f;
        float maxZ = 5f;
        float yPos = 25f;

        obj.transform.position = new Vector3(Random.Range(minX, maxX), yPos, Random.Range(minZ, maxZ));
    }
    
    private void ReturnToPool(Cube cube)
    {
        int minSecond = 2;
        int maxSecond = 6;
        int randomSecond = Random.Range(minSecond, maxSecond);
        StartCoroutine(CubeCycle(randomSecond, cube));
    }
    
    private IEnumerator CubeCycle(float second, Cube cube)
    {
        yield return new WaitForSeconds(second);
        cube.gameObject.SetActive(false);
        _pool.Release(cube);
        PositionForSpawnBomb?.Invoke(cube.transform.position);
    }
}
