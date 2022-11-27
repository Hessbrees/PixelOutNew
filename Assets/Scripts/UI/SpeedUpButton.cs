using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SpeedUpButton : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
{

    private IGameManager gameManager;
    private IPlayerControler playerControler;
    private IEnemyControl enemyControl;

    [Inject]
    public void Setup(IEnemyControl enemyControl, IGameManager gameManager, IPlayerControler playerControler)
    {
        this.gameManager = gameManager;
        this.playerControler = playerControler;
        this.enemyControl = enemyControl;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SpeedUpTrigger();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(DelayBackToNormal());
    }
    IEnumerator DelayBackToNormal()
    {
        yield return new WaitForSeconds(5f);
        enemyControl.ResetGravity();
        enemyControl.ResetEnemySpawnAmount();
        //gameManager.BackToNormalGravity();
    }
    void SpeedUpTrigger()
    {
        //gameManager.SpeedUpButton();
        enemyControl.AddGravity(5f);
        enemyControl.SetEnemySpawnAmount(1);
        playerControler.SetPlayerSpeedUpSize(0.95f);
    }
}
