using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{ 
    [SerializeField] protected Text _textAllSpawnObject;
    [SerializeField] protected Text _textEnableObject;
    [SerializeField] protected Text _textPoolCapacity;

    private int _countAllObject;
    private int _countEnableObject;
    private int _countPoolCapacity;

    protected virtual void ResetCounterAllObject()
    {
        _countAllObject++;
        _textAllSpawnObject.text = _countAllObject.ToString();
    }

    protected virtual void AddCounterEnableObject()
    {
        _countEnableObject++;
        _textEnableObject.text = _countEnableObject.ToString();
    }
    
    protected virtual void TakeCounterEnableObject()
    {
        _countEnableObject--;
        _textEnableObject.text = _countEnableObject.ToString();
    }

    protected virtual void ResetPoolCounter()
    {
        _countPoolCapacity++;
        _textPoolCapacity.text = _countPoolCapacity.ToString();
    }
}
