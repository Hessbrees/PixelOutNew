using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IEnemyControl
{
    public void GetEnemyPrefab(GameObject enemyPrefab);
    public void EnemyFlowControl();
    public GameObject TakeEnemyPrefab();
    public void SpawnEnemyPool();
    public void ResetGravity();
    public void AddGravity(float gravity);
    public void SetEnemySpawnAmount(int spawn);
    public int GetEnemySpawnAmount();
    public void ResetEnemySpawnAmount();
}

public class EnemyControl : IEnemyControl
{
    GameObject enemy = GameObject.FindGameObjectWithTag("Enemy").gameObject;
    GameObject enemyPrefab;
    private float gravityScaling = 0;
    private float startingHeight = 200;
    GameObject[] spawnedEnemy = new GameObject[50];
    int currentEnemyIndex = 0;
    private int spawnAmount = 1;
    private IPlayerControler playerControler;
    [Inject]
    public void Setup(IPlayerControler playerControler)
    {
        this.playerControler = playerControler;
    }
    public GameObject TakeEnemyPrefab() => enemyPrefab;
    public void SetEnemySpawnAmount(int spawn) => spawnAmount += spawn;
    public int GetEnemySpawnAmount() => spawnAmount;
    public void ResetEnemySpawnAmount() => spawnAmount = 1;
    public void GetEnemyPrefab(GameObject enemy) => enemyPrefab = enemy;

    public void SpawnEnemyPool()
    {
        if(enemy.transform.childCount == 0)
        for(int i =0; i <50; i++)
        spawnedEnemy[i] = GameObject.Instantiate(enemyPrefab, enemy.transform);
    }
    public void ResetGravity() => gravityScaling = 0;
    public void AddGravity(float gravity) => gravityScaling += gravity;
    public void EnemyFlowControl()
    {
        spawnedEnemy[currentEnemyIndex].transform.localScale = (enemyPrefab.transform.localScale + playerControler.GetPlayerNormalSize() ) * Random.Range(0.5f, 1.2f);
        spawnedEnemy[currentEnemyIndex].transform.GetComponent<Rigidbody2D>().gravityScale += Random.Range(1, 10) + gravityScaling;
        spawnedEnemy[currentEnemyIndex].transform.localPosition = new Vector3(Random.Range(playerControler.GetLeftGameBoard(), playerControler.GetRightGameBoard()), Random.Range(0, startingHeight));
        spawnedEnemy[currentEnemyIndex].SetActive(true);

        currentEnemyIndex++;
        if (currentEnemyIndex > 49) currentEnemyIndex = 0;
    }
}
