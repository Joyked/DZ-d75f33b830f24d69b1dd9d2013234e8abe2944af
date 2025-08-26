using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private CatapultTrigger _trigger;
    
    private Rigidbody _rigidbody;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    private void OnEnable() =>
        _trigger.InPositioned += Reload;

    private void OnDisable() =>
        _trigger.InPositioned -= Reload;

    private void Reload()
    {
         _rigidbody.velocity = Vector3.zero;
         transform.position = _transform.position;
    }
}
