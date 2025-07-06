using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{ 
    [SerializeField] protected Text _textAllSpawnObject;
    [SerializeField] protected Text _textEnableObject;
    [SerializeField] protected Text _textPoolCapacity;

    protected int _countAllObject;
    protected int _countEnableObject;

    protected virtual void ResetCounterAllObject() =>
        _countAllObject++;

    protected virtual void AddCounterEnableObject() =>
        _countEnableObject++;
    
    protected virtual void TakeCounterEnableObject() =>
        _countEnableObject--;
}
