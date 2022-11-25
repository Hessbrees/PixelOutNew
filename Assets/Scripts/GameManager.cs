using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IGameManager
{
    public void SpeedUpButton();
    public int GetEasingID();

    public void BackToNormalGravity();
}
public class GameManager : IGameManager
{
    private int easingScaleID = -1;
    GameObject player = GameObject.FindGameObjectWithTag("Player").transform.Find("Body").gameObject;
    GameObject enemy = GameObject.FindGameObjectWithTag("Enemy").gameObject;

    private IEnemyControl enemyControl;

    [Inject]
    public void Setup(IEnemyControl enemyControl)
    {
        this.enemyControl = enemyControl;
    }

    public void SpeedUpButton()
    {
        Rigidbody2D[] enemyGravityScale = enemy.transform.GetComponentsInChildren<Rigidbody2D>();
        enemyControl.TakeEnemyPrefab().GetComponent<Rigidbody2D>().gravityScale += 6f;
    }
    public void BackToNormalGravity()
    {
        enemyControl.TakeEnemyPrefab().GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
    public int GetEasingID() => easingScaleID;
}
