using UnityEngine;

public class AfterBurnerScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("t as Gagne ");
        }
    }
}
    