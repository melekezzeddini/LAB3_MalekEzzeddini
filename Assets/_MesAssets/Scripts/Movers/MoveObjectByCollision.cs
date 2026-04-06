using UnityEngine;

public class MoveObjectByCollision : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Vector3 _moveDirection = new Vector3(0, -3, 0);
    [SerializeField] private float _moveSpeed = 1.0f;

    private Vector3 objectFinalPos;
    private bool isTriggered = false;

    void Start()
    {
        objectFinalPos = _object.transform.position + _moveDirection;
    }

    void FixedUpdate()
    {
        if (isTriggered || _object.transform.position == objectFinalPos)
        {
            float step = _moveSpeed * Time.fixedDeltaTime;
            _object.transform.position = Vector3.MoveTowards(_object.transform.position, objectFinalPos, step);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !isTriggered)
        {
            isTriggered = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !isTriggered)
        {
            isTriggered = true;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}