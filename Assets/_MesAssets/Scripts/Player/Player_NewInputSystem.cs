using UnityEngine;

public class Player_NewInputSystem : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 500f;
    [SerializeField] private float _playerRotationSpeed = 500f;
    [SerializeField] private float jumpForce = 10f;

    private bool isGrounded = true;
    private int jumpCount = 0;
    private int jumpsRequired = 2;
    private bool levelCompleted = false;

    private Animator _animator;
    private Rigidbody _rb;

    private PlayerInputActions _playerInputActions;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();

        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        if (_playerInputActions.Player.Jump.triggered && isGrounded)
        {
            Jump();
        }
    }

    public void DisableInputActions()
    {
        _playerInputActions.Disable();
    }

    private void PlayerMovement()
    {

        Vector2 direction2D = _playerInputActions.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(direction2D.x, 0f, direction2D.y);
        direction.Normalize(); // gestion des diagonales , normaliser l'hypoth�nuse � 1

        // Pousser le corps dans la dir�ction du vecteur (regard la masse et ajouter une force sur le rigidBody = jeu de hockey)
        _rb.AddForce(direction *Time.fixedDeltaTime *_playerSpeed);

        if (direction != Vector3.zero)
        {
            if (!GameManager.Instance.IsStarted)
                GameManager.Instance.SetTimer();

            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _playerRotationSpeed * Time.deltaTime);
        
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", false);
            _animator.SetBool("IsJumping", false);
        }
    }

    private void Jump()
    {
        _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);

        // Applied force with impusle
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        isGrounded = false;

        _animator.SetBool("IsJumping", true);

        jumpCount++;
        Debug.Log($"Saut réussi ! Total : {jumpCount}/{jumpsRequired}");

        // Verify if level is completed
        if (jumpCount >= jumpsRequired && !levelCompleted)
        {
            levelCompleted = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            _animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Quand on quitte le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
