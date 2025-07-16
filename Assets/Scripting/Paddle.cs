using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerType { Player1, Player2 }

public class Paddle : MonoBehaviour
{
    public PlayerType CurrentPlayer;
    public float Speed = 10f;
    public float Boundary = 4f;

    [SerializeField] private InputAction moveInput;
    private float moveDirection;

    void Awake()
    {
        moveInput.performed += OnMovePerformed;
        moveInput.canceled += OnMoveCanceled;
    }

    void OnEnable()
    {
        moveInput.Enable();
    }
    
    void OnDisable()
    {
        moveInput.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<float> ();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveDirection = 0;
    }

    void Update()
    {
        float movement = this.moveDirection * Speed * Time.deltaTime;
        transform.Translate(0f, movement, 0f);

        float clampedY = Mathf.Clamp(transform.position.y, -Boundary, Boundary);
        transform.position = new Vector3(transform.position.x, clampedY, 0f);
    }
}
