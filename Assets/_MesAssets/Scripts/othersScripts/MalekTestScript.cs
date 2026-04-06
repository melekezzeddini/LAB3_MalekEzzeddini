using UnityEngine;

public class MalekTestScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    [SerializeField]
    private float rot = 80f;

    private float curspeed;

    void FixedUpdate()
    {
        // Sprint
        curspeed = Input.GetKey(KeyCode.LeftControl) ? speed * 2f : speed;

        // Rotation gauche / droite
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0f, rot * Time.fixedDeltaTime * horizontal, 0f);

        // Avancer / reculer selon le joueur
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(0f, 0f, -curspeed * Time.fixedDeltaTime * vertical);
    }
}