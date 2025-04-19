using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveableEnemy : StaticEnemy
{
    private Rigidbody _rigidbody;
    private RaycastHit hit;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private float _speed = 20f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isTriggered = false;
    }

    private void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, _layerMask))
        {
            Move(transform.TransformDirection(Vector3.up));
            _isTriggered = true;
        }
    }

    public override void Move(Vector2 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }
}
