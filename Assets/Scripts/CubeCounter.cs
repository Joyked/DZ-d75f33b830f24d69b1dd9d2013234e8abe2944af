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
        _textAllSpawnObject.text = "Кубов заспавнено: ";
        base.ResetCounterAllObject();
    }

    protected override void AddCounterEnableObject()
    {
        _textEnableObject.text = "Кубов на сцене: ";
        base.AddCounterEnableObject();
    }

    protected override void TakeCounterEnableObject()
    {
        _textEnableObject.text = "Кубов на сцене: ";
        base.TakeCounterEnableObject();
    }

    protected virtual void ResetPoolCounter()
    {
        _textPoolCapacity.text = "Кубов в пуле: ";
        base.ResetPoolCounter();
    }
}
