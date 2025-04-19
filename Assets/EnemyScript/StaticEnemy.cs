using UnityEngine;

public class StaticEnemy : Enemy
{
    protected bool _isTriggered;
    public override void Move(Vector2 direction) {}

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            Kill();
        }
        if (_isTriggered)
            Destroy(gameObject);
    }
}
