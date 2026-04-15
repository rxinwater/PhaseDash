using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement settings")]
    [Range(1, 10)]
    [SerializeField] private float _speed = 5f;
    private float _baseSpeed;

    [Header("Player setup")]
    [SerializeField] private PlayerInput _playerInput;

    [SerializeField] private float _jumpForce = 7f;
    private Rigidbody2D _rb;

    private bool grounded;
    private Vector2 _currentInput;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _baseSpeed = _speed;

        _playerInput.OnInputReceived.AddListener(PlayerMove);
        _playerInput.OnJumpReceived.AddListener(Jump);
    }

    private void PlayerMove(Vector2 direction)
    {
        _currentInput = direction;
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_currentInput.x * _speed, _rb.linearVelocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _speed = _baseSpeed * 2f;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            _speed = _baseSpeed;
    }

    private void Jump()
    {
        if (grounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = false;
    }
}