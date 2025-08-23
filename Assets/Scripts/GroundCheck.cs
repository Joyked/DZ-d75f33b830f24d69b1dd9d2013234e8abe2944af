using UnityEngine;

public class GroundChecker
{
    private readonly Transform _transform;
    private readonly Collider _collider;
    private readonly float _checkDistance;
    
    public GameObject Ground { get; private set; }
    public bool IsGrounded { get; private set; }

    public GroundChecker(Transform transform, Collider collider, float checkDistance = 0.2f)
    {
        _transform = transform;
        _collider = collider;
        _checkDistance = checkDistance;
    }

    public bool CheckGrounded()
    {
        Ground = null;
        IsGrounded = false;
        
        float totalCheckDistance = _collider.bounds.extents.y + _checkDistance;

        if (Physics.Raycast(_transform.position, Vector3.down, out RaycastHit hit, totalCheckDistance))
        {
            Ground = hit.collider.gameObject;
            IsGrounded = true;
            return true;
        }

        return false;
    }

    public bool IsStepHeightReachable(GameObject otherObject, float stepOffset)
    {
        if (otherObject == null) return false;
        
        float heightDifference = otherObject.transform.position.y - _transform.position.y;
        return heightDifference < stepOffset && otherObject.transform.localScale.y < stepOffset;
    }
}
