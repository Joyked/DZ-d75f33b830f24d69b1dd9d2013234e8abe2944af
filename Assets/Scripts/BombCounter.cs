using UnityEngine;

public class BombCounter : Counter
{
    [Space]
    [SerializeField] private BombSpawner _spawner;
    
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
        _textAllSpawnObject.text = $"Бомб заспавнено: {_countAllObject}";
    }

    protected override void AddCounterEnableObject()
    {
        base.AddCounterEnableObject();
        _textEnableObject.text = $"Бомб на сцене: {_countEnableObject}";
    }
    
    protected override void TakeCounterEnableObject()
    {
        base.TakeCounterEnableObject();
        _textEnableObject.text = $"Бомб на сцене: {_countEnableObject}";
    }

    protected virtual void ResetPoolCounter(int count) =>
        _textPoolCapacity.text = $"Бомб в пуле: {count}";
}
