using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private Vector3 _openDirection = new Vector3(0, -3, 0);
    [SerializeField] private float _openSpeed = 1.0f;

    private Vector3 doorOpenPos;
    private bool isTriggered = false;

    void Start()
    {
        doorOpenPos = _door.transform.position + _openDirection;
    }

    void FixedUpdate()
    {
        if (isTriggered || _door.transform.position == doorOpenPos)
        {
            float step = _openSpeed * Time.fixedDeltaTime;
            _door.transform.position = Vector3.MoveTowards(_door.transform.position, doorOpenPos, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;

            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
