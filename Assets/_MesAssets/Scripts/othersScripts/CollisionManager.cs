using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private Material _hitMaterial = default(Material);
    [SerializeField] private int _collisionValue = 1;
    [SerializeField] private float _resetTimer = 4f; // Temps avant r�initialisation

    private bool _isHit = false;
    private Material _originalMaterial;
    private MeshRenderer _meshRenderer;

    private MeshRenderer[] _childrenMeshRenderer;
    private Material[] _childrenOriginalMaterial;
    private int _numChildren;
    private bool _hasChildren = false;

    private void Start()
    {
        // Si n'a pas de MeshRenderer.. Regarde celui des "children"
        if (TryGetComponent<MeshRenderer>(out _meshRenderer))
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _originalMaterial = _meshRenderer.material;
        }
        else
        {
            _hasChildren = true;
            _childrenMeshRenderer = GetComponentsInChildren<MeshRenderer>();
            _numChildren = _childrenMeshRenderer.Length;
            _childrenOriginalMaterial = new Material[_numChildren];
            for (int i = 0; i < _numChildren; i++)
            {
                _childrenOriginalMaterial[i] = _childrenMeshRenderer[i].material;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isHit)
        {
            if (!_hasChildren)
            {
                _meshRenderer.material = _hitMaterial;
            }
            else
            {
                foreach (var m in _childrenMeshRenderer)
                {
                    m.material = _hitMaterial;
                }
            }

            GameManager.Instance.AddCollision(_collisionValue);

            _isHit = true;

            Invoke("ResetColor", _resetTimer);
        }
    }

    private void ResetColor()
    {
        if (!_hasChildren)
        {
            _meshRenderer.material = _originalMaterial;
        }
        else
        {
            for (int i = 0; i < _numChildren; i++)
            {
                _childrenMeshRenderer[i].material = _childrenOriginalMaterial[i];
            }
        }
        _isHit = false;
    }
}
