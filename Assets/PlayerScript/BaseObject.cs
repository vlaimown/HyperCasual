using UnityEngine;

public abstract class BaseObject : MonoBehaviour, IMoveable
{
    public abstract void Move(Vector2 direction);
    public virtual void Initiate()
    {
        Instantiate(this, Vector3.zero, Quaternion.identity);
    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
