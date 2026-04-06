using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private Vector3 openRotation = new Vector3(0, 90, 0);
    [SerializeField] private float speed = 100f;

    private Quaternion targetRotation;
    private bool isTriggered = false;

    void Start()
    {
        targetRotation = door.transform.rotation * Quaternion.Euler(openRotation);
    }

    void Update()
    {
        if (isTriggered)
        {
            float step = speed * Time.deltaTime;

            door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation,targetRotation,step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
}