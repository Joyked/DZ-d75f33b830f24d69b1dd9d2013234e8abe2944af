using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private InputReader _inputReader;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _inputReader = new InputReader();
    }

    private void Update()
    {
        Vector2 input = _inputReader.GetMovementInput();
        Vector3 movement = new Vector3(input.x, 0, input.y) * _speed;
        movement = Vector3.ClampMagnitude(movement, _speed);
        
        if (!_characterController.isGrounded)
            movement.y += Physics.gravity.y;
        else
            movement.y = -0.5f;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
