using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;

    private void Awake() =>
        _characterController = GetComponent<CharacterController>();

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = Physics.gravity.y;
        
        if (!_characterController.isGrounded)
            movement.y += Physics.gravity.y;
        else
            movement.y = -0.5f;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
