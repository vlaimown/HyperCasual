using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveableEnemy : StaticEnemy
{
    private bool _canMove;
    private Rigidbody _rigidbody;
    private RaycastHit hit;

    [SerializeField]
    private LayerMask _layerMask;

    [SerializeField]
    private float _speed = 20f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SwipeDetection.OnSwipeTriggered += TriggerMove;
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

    private void TriggerMove()
    {
        _canMove = true;
        SwipeDetection.OnSwipeTriggered -= TriggerMove;
    }

    public override void Move(Vector2 direction)
    {
        if (_canMove)
            _rigidbody.velocity = direction * _speed;
    }
}
