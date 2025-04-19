using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    public BaseObject player;

    private void Start()
    {
        player.Initiate(transform.position);
    }
}
