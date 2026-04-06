using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 3f;
    [SerializeField] private bool moveOnX = true;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (moveOnX)
        {
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime, Space.World);

            if (transform.position.x >= startPos.x + distance)
                direction = -1;
            else if (transform.position.x <= startPos.x - distance)
                direction = 1;
        }
        else
        {
            transform.Translate(Vector3.forward * direction * speed * Time.deltaTime, Space.World);

            if (transform.position.z >= startPos.z + distance)
                direction = -1;
            else if (transform.position.z <= startPos.z - distance)
                direction = 1;
        }
    }
}