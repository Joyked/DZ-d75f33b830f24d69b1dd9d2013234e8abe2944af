using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _pushForce = 100f;
    [SerializeField] private InputReader _inputReader;
    
    private HingeJoint _hingeJoint;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _rigidbody = _hingeJoint.GetComponent<Rigidbody>();
    }

    private void OnEnable() =>
        _inputReader.Pushed += Push;

    private void OnDisable() =>
        _inputReader.Pushed -= Push;

    private void Push() =>
        _rigidbody.AddTorque(transform.forward * _pushForce, ForceMode.Impulse);
}
