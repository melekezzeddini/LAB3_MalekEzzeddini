using System.Net;
using UnityEngine;

public class Player_InputManager : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 3000f;

    [SerializeField] private float _playerRotationSpeed = 700f;

    private Animator _animator;
    private Rigidbody _rb;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody>();

        GameManager.Instance.SetTimer();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(directionX, 0f, directionZ); // utiliser le vecteur
        direction.Normalize(); // gestion des diagonales

        _rb.AddForce(direction * Time.fixedDeltaTime * _playerSpeed); // Pousser le corps dans la dir�ction du vecteur (regard la masse)

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
}
