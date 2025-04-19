using UnityEngine;

public class Spike : Enemy
{
    public override void Move(Vector2 direction) {}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            Kill();
        }
    }
}
