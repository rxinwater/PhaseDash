using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [Space]
    public UnityEvent<Vector2> OnInputReceived = new UnityEvent<Vector2>();
    public UnityEvent OnJumpReceived = new UnityEvent();

    private Vector2 _lastInput;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0f);

        OnInputReceived.Invoke(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpReceived.Invoke();
        }
    }
}
