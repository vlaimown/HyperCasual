using UnityEngine;

public abstract class BaseObject : MonoBehaviour, IMoveable
{
    public abstract void Move(Vector2 direction);
    public virtual void Initiate(Vector3 startPosition)
    {
        Instantiate(this, startPosition, Quaternion.identity);
    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
