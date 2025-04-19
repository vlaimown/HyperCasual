using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private List<EnemySpawn> _enemySpawners;
    void Awake()
    {
        _enemySpawners = GetComponentsInChildren<EnemySpawn>().ToList();

        foreach (var enemySpawn in _enemySpawners)
        {
            enemySpawn.SpawnEnemy();
        }
    }
}
