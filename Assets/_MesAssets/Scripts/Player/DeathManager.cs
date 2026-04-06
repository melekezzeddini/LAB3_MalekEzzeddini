using UnityEngine;

public class DeathManager : MonoBehaviour
{

    [SerializeField] private Vector3 _spawn = new Vector3(0, 0, 0);
    [SerializeField] private int _penalty = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCollision(_penalty);
            other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            other.transform.position = _spawn;
        }
    }
}
