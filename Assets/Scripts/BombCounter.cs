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
        _textAllSpawnObject.text = "Бомб заспавнено: ";
        base.ResetCounterAllObject();
    }

    protected override void AddCounterEnableObject()
    {
        _textEnableObject.text = "Бомб на сцене: ";
        base.AddCounterEnableObject();
    }
    
    protected override void TakeCounterEnableObject()
    {
        _textEnableObject.text = "Бомб на сцене: ";
        base.TakeCounterEnableObject();
    }

    protected virtual void ResetPoolCounter()
    {
        _textPoolCapacity.text = "Бомб в пуле: ";
        base.ResetPoolCounter();
    }
}
