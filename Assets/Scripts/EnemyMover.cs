using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _stoppingDistance = 2f;
    [SerializeField] private float _stepOffset = 0.3f;
    [SerializeField] private float _jumpForce = 8f;

    private Rigidbody _rigidbody;
    private GroundChecker _groundChecker;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        
        _groundChecker = new GroundChecker(transform, GetComponent<Collider>());
    }

    private void FixedUpdate()
    {
        _groundChecker.CheckGrounded();
        
        Vector3 direction = _player.position - transform.position;
        float distance = direction.magnitude;

        if (distance > _stoppingDistance)
        {
            Vector3 moveDir = direction.normalized;
            _rigidbody.velocity = new Vector3(moveDir.x * _speed, _rigidbody.velocity.y, moveDir.z * _speed);
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_groundChecker.IsGrounded && 
            other.gameObject != _groundChecker.Ground &&
            _groundChecker.IsStepHeightReachable(other.gameObject, _stepOffset))
        {
            Debug.Log(other.gameObject.name);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}