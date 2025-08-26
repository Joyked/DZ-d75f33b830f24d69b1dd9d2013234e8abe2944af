using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class СatapultController : MonoBehaviour
{
    [SerializeField] private float _fierSpring = 15;
    [SerializeField] private float _reloadSpring = 1.3f;
    
    private SpringJoint _hingeJoint;
    private KeyCode _fierKey = KeyCode.Space;
    private KeyCode _reloadKey = KeyCode.R;

    private void Awake() =>
        _hingeJoint = GetComponent<SpringJoint>();
    
    private void Update()
    {
        if (Input.GetKeyDown(_fierKey))
            _hingeJoint.spring = _fierSpring;
            
        
        if (Input.GetKeyDown(_reloadKey))
            _hingeJoint.spring = _reloadSpring;
    }
}
