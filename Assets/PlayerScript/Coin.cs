using UnityEngine;

public class Coin : BaseObject
{
    public delegate void OnCollect();
    public static event OnCollect OnCollectCoin;
    public override void Move(Vector2 direction) {}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Character>() != null)
        {
            OnCollectCoin();
            Destroy(gameObject);
        }
    }
}
