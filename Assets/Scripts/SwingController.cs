using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class SwingController : MonoBehaviour
{
    [SerializeField] private float _pushForce = 100f;

    private KeyCode _swingKey = KeyCode.F;
    private HingeJoint _hingeJoint;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        _rigidbody = _hingeJoint.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(_swingKey))
            _rigidbody.AddTorque(transform.forward * _pushForce, ForceMode.Impulse);
    }
}
