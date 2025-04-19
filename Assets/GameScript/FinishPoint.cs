using UnityEngine;

public class FinishPoint : BaseObject
{
    public delegate void OnPlayerFinish();
    public static event OnPlayerFinish OnPlayerFinished;
    public override void Move(Vector2 direction){}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Character>() != null)
        {
            OnPlayerFinished();
        }
    }
}
