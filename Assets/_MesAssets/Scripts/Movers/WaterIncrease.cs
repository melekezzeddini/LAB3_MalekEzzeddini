using UnityEngine;

public class WaterIncrease : MonoBehaviour
{
    [SerializeField] private float speedWateur = 0.5f;
    void Update()
    {
        transform.position += new Vector3(0f, speedWateur * Time.deltaTime, 0f);
    }
}
