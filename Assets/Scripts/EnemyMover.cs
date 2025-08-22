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
    private GameObject _ground;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
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
        if (IsGrounded() && other.gameObject != _ground &&
            other.gameObject.transform.position.y < transform.position.y + _stepOffset && other.gameObject.transform.localScale.y < _stepOffset)
        {
            Debug.Log(other.gameObject.name);
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    
    private bool IsGrounded()
    {
        _ground = null;
        float checkDistance = GetComponent<Collider>().bounds.extents.y + 0.2f;
    
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, checkDistance))
        {
            _ground = hit.collider.gameObject;
            return true;
        }
    
        return false;
    }
}