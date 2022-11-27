using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    
    private IEnemyControl enemyControl;
    private IGameManager gameManager;

    [Inject]
    public void Setup(IEnemyControl enemyControl, IGameManager gameManager)
    {
        this.enemyControl = enemyControl;
        this.gameManager = gameManager;
    }

    private void Awake()
    {
        enemyControl.GetEnemyPrefab(enemy);
        //enemyControl.SpawnEnemyPool();
    }
    private void OnEnable()
    {
        enemyControl.GetEnemyPrefab(enemy);
        enemyControl.SpawnEnemyPool();
        StartCoroutine(EnemySpawn());
    }
    private void OnDisable()
    {
        StopCoroutine(EnemySpawn());
        enemyControl.DisactivateFlowControl();
    }
    IEnumerator EnemySpawn()
    {
        while(true)
        {
            for(int i = 1; i <= enemyControl.GetEnemySpawnAmount(); i++)
            enemyControl.EnemyFlowControl();

            yield return new WaitForSeconds(Random.Range(0.2f,0.5f));
        }
    }



}
