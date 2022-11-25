using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SpeedUpButton : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
{

    private IGameManager gameManager;
    private IPlayerControler playerControler;

    [Inject]
    public void Setup(IGameManager gameManager, IPlayerControler playerControler)
    {
        this.gameManager = gameManager;
        this.playerControler = playerControler;
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
        gameManager.BackToNormalGravity();
        playerControler.SetPlayerSpeedUpSizeBackToNormal();
    }
    void SpeedUpTrigger()
    {
        gameManager.SpeedUpButton();
        playerControler.SetPlayerSpeedUpSize(0.7f);
        //123
    }
}
