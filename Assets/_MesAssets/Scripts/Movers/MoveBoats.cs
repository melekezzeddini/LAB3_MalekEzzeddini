using UnityEngine;

public class MoveBoats : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 50f;

    void Update()
    {
        // déplacer vers l'avant
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Changer de direction
        float rotation = Random.Range(-5f, 5f);
        transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);

        // zone de restriction
        if (transform.position.x > 50 || transform.position.x < -50)
        {
            transform.Rotate(0, 180, 0);
        }

        if (transform.position.z > 50 || transform.position.z < -50)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
