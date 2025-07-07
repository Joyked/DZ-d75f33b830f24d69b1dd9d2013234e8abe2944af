using UnityEngine;
using UnityEngine.UI;

public class Counter<T> : MonoBehaviour where T : MonoBehaviour
{ 
    [SerializeField] private BaseSpawner<T> _spawner;
    [Space]
    [SerializeField] private Text _textAllSpawnObject;
    [SerializeField] private Text _textEnableObject;
    [SerializeField] private Text _textPoolCapacity;
    [Space] 
    protected string _nameObject;

    private int _countAllObject;
    private int _countEnableObject;

    private void OnEnable()
    {
        _spawner.ObjectSpawned += ResetCounterAllObject;
        _spawner.ObjectEnabled += AddCounterEnableObject;
        _spawner.СapacityPoolChanged += ResetPoolCounter;
        _spawner.ObjectDisabled += TakeCounterEnableObject;
    }

    private void OnDisable()
    {
        _spawner.ObjectSpawned -= ResetCounterAllObject;
        _spawner.ObjectEnabled -= AddCounterEnableObject;
        _spawner.СapacityPoolChanged -= ResetPoolCounter;
        _spawner.ObjectDisabled -= TakeCounterEnableObject;
    }
    
    protected virtual void ResetCounterAllObject()
    {
        _countAllObject++;
        _textAllSpawnObject.text = $"{_nameObject} заспавнено: {_countAllObject}";
    }

    protected virtual void AddCounterEnableObject()
    {
        _countEnableObject++;
        _textEnableObject.text = $"{_nameObject} на сцене: {_countEnableObject}";
    }

    protected virtual void TakeCounterEnableObject()
    {
        _countEnableObject--;
        _textEnableObject.text = $"{_nameObject} на сцене: {_countEnableObject}";
    }

    protected virtual void ResetPoolCounter(int count) =>
        _textPoolCapacity.text = $"{_nameObject} в пуле: {count}";
}
