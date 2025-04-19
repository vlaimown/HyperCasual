using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemy;
    public void SpawnEnemy()
    {
        _enemy.Initiate(transform.position);
    }
}
