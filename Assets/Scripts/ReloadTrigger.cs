using System;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{
    public event Action InPosition;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out СatapultController controller))
            InPosition?.Invoke();
    }
}
