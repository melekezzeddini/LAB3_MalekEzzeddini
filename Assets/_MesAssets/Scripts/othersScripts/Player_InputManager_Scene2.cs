using UnityEngine;

public class Player_InputManager_Scene2 : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 1000f;
    [SerializeField] private float _playerRotationSpeed = 150f;

    private Animator _animator;
    private Rigidbody _rb;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();

        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetTimer();
        }
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.forward * directionZ + transform.right * directionX;
        direction.y = 0f;
        direction.Normalize();

        _rb.AddForce(direction * Time.fixedDeltaTime * _playerSpeed);

        if (direction != Vector3.zero)
        {
            if (GameManager.Instance != null && !GameManager.Instance.IsStarted)
            {
                GameManager.Instance.SetTimer();
            }

            // tourner seulement quand on avance
            if (directionZ > 0)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    toRotation,
                    _playerRotationSpeed * Time.deltaTime
                );
            }

            if (_animator != null)
            {
                _animator.SetBool("IsRunning", true);
                _animator.SetBool("IsWalking", false);
                _animator.SetBool("IsJumping", false);
            }
        }
        else
        {
            if (_animator != null)
            {
                _animator.SetBool("IsWalking", false);
                _animator.SetBool("IsRunning", false);
                _animator.SetBool("IsJumping", false);
            }
        }
    }
}