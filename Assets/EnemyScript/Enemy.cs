using UnityEngine;

public abstract class Enemy : BaseObject
{
    public delegate void OnKill();
    public static event OnKill KillEvent;
    
    protected void Kill()
    {
        KillEvent();
    }
}
