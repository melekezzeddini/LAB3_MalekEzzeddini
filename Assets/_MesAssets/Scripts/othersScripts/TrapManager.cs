using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listTraps = new List<GameObject>();
    [SerializeField] private float _forceIntensity = 100f;

    [Header("Force direction on trigger (X,Y,Z)")]
    [SerializeField] private Vector3 _direction = Vector3.down;

    private List<Rigidbody> _listRbs = new List<Rigidbody>();
    private bool _isTriggered = false;

    private void Start()
    {
        foreach (GameObject go in _listTraps)
        {
            _listRbs.Add(go.GetComponent<Rigidbody>());
            go.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isTriggered)
        {
            foreach (Rigidbody rb in _listRbs)
            {
                rb.useGravity = false;
                rb.AddForce(_direction * _forceIntensity);
            }

            _isTriggered = true;
        }

    }
}
