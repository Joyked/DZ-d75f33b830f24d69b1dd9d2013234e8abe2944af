using UnityEngine;

public class CubeCounter : Counter
{
    [Space]
    [SerializeField] private CubeSpawner _spawner;
    
    private void OnEnable()
    {
        _spawner.SpawnObject += ResetCounterAllObject;
        _spawner.EnableObject += AddCounterEnableObject;
        _spawner.PoolCapacity += ResetPoolCounter;
        _spawner.DisableObject += TakeCounterEnableObject;
    }

    private void OnDisable()
    {
        _spawner.SpawnObject -= ResetCounterAllObject;
        _spawner.EnableObject -= AddCounterEnableObject;
        _spawner.PoolCapacity -= ResetPoolCounter;
        _spawner.DisableObject -= TakeCounterEnableObject;
    }
    
    protected override void ResetCounterAllObject()
    {
        base.ResetCounterAllObject();
        _textAllSpawnObject.text = $"Кубов заспавнено: {_countAllObject}";
    }

    protected override void AddCounterEnableObject()
    {
        base.AddCounterEnableObject();
        _textEnableObject.text = $"Кубов на сцене: {_countEnableObject}";
    }

    protected override void TakeCounterEnableObject()
    {
        base.TakeCounterEnableObject();
        _textEnableObject.text = $"Кубов на сцене: {_countEnableObject}";
    }

    private void ResetPoolCounter(int count) =>
        _textPoolCapacity.text = $"Кубов в пуле: {count}";
}
