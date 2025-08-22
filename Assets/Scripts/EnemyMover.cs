using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float stoppingDistance = 2f;
    public float stepOffset = 0.3f;
    public float jumpForce = 8f;

    private Rigidbody rb;
    private float lastJumpTime;
    private GameObject _ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance > stoppingDistance)
        {
            Vector3 moveDir = direction.normalized;
            rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.z * speed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (IsGrounded() && other.gameObject != _ground &&
            other.gameObject.transform.position.y < transform.position.y + stepOffset && other.gameObject.transform.localScale.y < stepOffset)
        {
            Debug.Log(other.gameObject.name);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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