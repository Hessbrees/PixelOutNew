using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IEnemyControl
{
    public void GetEnemyPrefab(GameObject enemyPrefab);
    public void EnemyFlowControl();
    public GameObject TakeEnemyPrefab();
}

public class EnemyControl : IEnemyControl
{
    GameObject enemy = GameObject.FindGameObjectWithTag("Enemy").gameObject;
    GameObject enemyPrefab;
    private int spawnedEnemies;
    private float startingHeight = 200;
    private IPlayerControler playerControler;

    [Inject]
    public void Setup(IPlayerControler playerControler)
    {
        this.playerControler = playerControler;
    }
    public GameObject TakeEnemyPrefab() => enemyPrefab;

    public void GetEnemyPrefab(GameObject enemy) => enemyPrefab = enemy;

    public void EnemyFlowControl()
    {
        spawnedEnemies = enemy.transform.childCount;
        
        if(spawnedEnemies < 50)
        {
            GameObject spawnedEnemy = GameObject.Instantiate(enemyPrefab,enemy.transform);
            spawnedEnemy.transform.localScale = enemyPrefab.transform.localScale * Random.Range(1, 20);
            spawnedEnemy.transform.GetComponent<Rigidbody2D>().gravityScale += Random.Range(1, 10);
            spawnedEnemy.transform.localPosition = new Vector3(Random.Range(playerControler.GetLeftGameBoard() ,playerControler.GetRightGameBoard()), Random.Range(0,startingHeight));
        }
    }
}
