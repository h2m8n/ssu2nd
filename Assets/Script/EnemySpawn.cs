using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject mEnemy;
    
    [SerializeField]
    private float mFirstSpawnZ = 80.0f;

    [SerializeField]
    private float mSpawnIntervalZ = 3.0f;

    [SerializeField]
    private Transform[] mSpawnPoints;

    private List<GameObject> _enemyPool = new List<GameObject>();
    private float _spawnIntervalZ;
    float timer;
    int waitingTime;

    private void Awake()
    {
        _spawnIntervalZ = mFirstSpawnZ;
        
        // for (var i = 0; i < 10; ++i)
        // {
        //     _enemyPool.Add(SpawnEnemy());
        // }
    }
    private void Start() {
        timer = 0.0F;
        waitingTime = 2;
        // inside  = false;
    }
    private void Update()
    {
        timer += Time.deltaTime;
   
        if(timer > waitingTime)
        {
            //Action
            timer = 0;
            _enemyPool.Add(SpawnEnemy());
        }
        //foreach (var enemy in _enemyPool)
        //{
            // if (zombie.transform.position.z + 40.0f < mPlayer.transform.position.z)
            // {
                // _spawnIntervalZ += mSpawnIntervalZ;

                // if (Random.Range(0, 100) > 80)
                // {
                //     return;
                // }
               
            // }

            //enemy.transform.position = CalcRandomEnemyPos();
        //}
    }

    private GameObject SpawnEnemy()
    {
        _spawnIntervalZ += mSpawnIntervalZ;
        return Instantiate(mEnemy, CalcRandomEnemyPos(), Quaternion.Euler(0, 180, 0));
    }

    private Vector3 CalcRandomEnemyPos()
    {
        var spawnPointTransform = mSpawnPoints[Random.Range(0, 4)];
        return spawnPointTransform.position;// + new Vector3(0, 0, _spawnIntervalZ);
    }
}
