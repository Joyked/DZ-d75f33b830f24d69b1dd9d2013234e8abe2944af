using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class СatapultController : MonoBehaviour
{
    private SpringJoint _hingeJoint;
    private KeyCode _fierKey = KeyCode.Space;
    private KeyCode _reloadKey = KeyCode.R;

    private void Awake() =>
        _hingeJoint = GetComponent<SpringJoint>();
    
    private void Update()
    {
        if (Input.GetKeyDown(_fierKey))
            _hingeJoint.spring = 15;
            
        
        if (Input.GetKeyDown(_reloadKey))
            _hingeJoint.spring = 1.3f;
    }
}
