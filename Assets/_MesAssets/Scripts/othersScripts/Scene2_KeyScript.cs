using Unity.VisualScripting;
using UnityEngine;

public class Scene2_KeyScript : MonoBehaviour
{

    // OnCollisionEnter est appelé quand ce collider/rigidbody commence à toucher un autre rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject.Find("DoorExitPoint").GetComponent<Scene2_DoorScript>().CanOpen = true;
            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject,3f);
        }
    }


}
