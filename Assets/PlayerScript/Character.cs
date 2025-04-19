using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Character : BaseObject
{
    public delegate void OnDeath();
    public static event OnDeath OnCharacterDeath;

    [SerializeField]
    private float _speed = 30f;

    private int _coins;
    private Rigidbody _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public int Coins { get { return _coins; } }

    private void Awake()
    {
        SwipeDetection.SwipeEvent += Move;
        Enemy.KillEvent += Destroy;
        Coin.OnCollectCoin += CollectCoin;
        _rigidbody = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _coins = 0;
    }

    public override void Move(Vector2 direction)
    {
        if (direction == Vector2.right)
        {
            _spriteRenderer.flipX = false;
            _animator.SetTrigger("IsRun");
        }
        else if (direction == Vector2.left)
        {
            _spriteRenderer.flipX = true;
            _animator.SetTrigger("IsRun");
        }
        else if (direction == Vector2.up)
        {
            _animator.SetTrigger("IsStartJump");
        }
        else if (direction == Vector2.down)
        {
            _animator.SetTrigger("IsSlide");
        }

        _rigidbody.velocity = direction * _speed;
    }

    private void CollectCoin()
    {
        _coins++;
    }

    public override void Destroy()
    {
        SwipeDetection.SwipeEvent -= Move;
        Enemy.KillEvent -= Destroy;
        _rigidbody = null;
        OnCharacterDeath();
        base.Destroy();
    }
}
