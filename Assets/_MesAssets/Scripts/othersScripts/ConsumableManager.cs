using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private int _collisionValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddCollision(_collisionValue);
            Destroy(gameObject);
        }
    }

}
