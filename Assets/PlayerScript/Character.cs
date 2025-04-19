using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : BaseObject
{
    [SerializeField]
    private float _speed = 30f;

    private bool _isCollision;
    private bool _isFirstMove;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        SwipeDetection.SwipeEvent += Move;
        Enemy.KillEvent += Destroy;
        _rigidbody = GetComponent<Rigidbody>();
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

    public override void Destroy()
    {
        SwipeDetection.SwipeEvent -= Move;
        Enemy.KillEvent -= Destroy;
        _rigidbody = null;
        _isFirstMove = false;
        base.Destroy();
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
