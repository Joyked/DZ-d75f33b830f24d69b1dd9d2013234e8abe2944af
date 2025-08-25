using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpawnCube : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private ReloadTrigger _trigger;
    
    private Rigidbody _rigidbody;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    private void OnEnable() =>
        _trigger.InPosition += Reload;

    private void OnDisable() =>
        _trigger.InPosition += Reload;

    private void Reload()
    {
         _rigidbody.velocity = Vector3.zero;
         transform.position = _transform.position;
    }
}
