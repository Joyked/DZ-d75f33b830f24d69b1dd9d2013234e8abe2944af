using System;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{
    public event Action InPositioned;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Сatapult controller))
            InPositioned?.Invoke();
    }
}
