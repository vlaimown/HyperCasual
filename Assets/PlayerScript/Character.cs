using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : BaseObject
{
    private readonly float _speed = 20f;
    private bool _isCollision;
    private bool _isFirstMove;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SwipeDetection.SwipeEvent += Move;
        _isFirstMove = true;
    }

    public override void Move(Vector2 direction)
    {
        if (_isCollision || _isFirstMove)
        {
            _rigidbody.velocity = direction * _speed;
            _isFirstMove = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
            _isCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isCollision = false;
    }
}
