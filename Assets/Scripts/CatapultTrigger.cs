using System;
using UnityEngine;

public class CatapultTrigger : MonoBehaviour
{
    public event Action InPositioned;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Сatapult controller))
            InPositioned?.Invoke();
    }
}
