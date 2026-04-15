using System.Collections;
using UnityEngine;

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

    [Header("Dash/Trail settings")]
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private float _dashingPower = 24f;
    [SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _dashingCooldown = 1f;

    private bool grounded;
    private Vector2 _currentInput;

    private bool _canDash = true;
    private bool _isDashing;
    private float _lastDirection = 1f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _baseSpeed = _speed;

        _playerInput.OnInputReceived.AddListener(PlayerMove);
        _playerInput.OnJumpReceived.AddListener(Jump);

        if (tr != null)
            tr.emitting = false;
    }

    private void PlayerMove(Vector2 direction)
    {
        _currentInput = direction;

        if (direction.x != 0)
            _lastDirection = Mathf.Sign(direction.x);
    }

    private void FixedUpdate()
    {
        if (_isDashing)
            return;

        _rb.linearVelocity = new Vector2(_currentInput.x * _speed, _rb.linearVelocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _speed = _baseSpeed * 2f;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            _speed = _baseSpeed;

        if (_isDashing)
            return;

        if (Input.GetKeyDown(KeyCode.Q) && _canDash)
            StartCoroutine(Dash());
    }

    private void Jump()
    {
        if (grounded && !_isDashing)
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

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;

        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;

        float dashDirection = _currentInput.x != 0 ? Mathf.Sign(_currentInput.x) : _lastDirection;
        _rb.linearVelocity = new Vector2(dashDirection * _dashingPower, 0f);

        if (tr != null)
            tr.emitting = true;

        yield return new WaitForSeconds(_dashingTime);

        if (tr != null)
            tr.emitting = false;

        _rb.gravityScale = originalGravity;
        _isDashing = false;

        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
    }
}