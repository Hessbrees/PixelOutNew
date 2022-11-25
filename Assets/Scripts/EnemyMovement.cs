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
        gameManager.BackToNormalGravity();
    }
    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    IEnumerator EnemySpawn()
    {
        while(true)
        {
            for(int i = 0; i< Random.Range(1,15); i++)
            enemyControl.EnemyFlowControl();

            yield return new WaitForSeconds(Random.Range(0.2f,1f));
        }
    }
}
