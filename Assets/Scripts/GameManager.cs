using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IGameManager
{
    public void DisableAfterDeath();
    public void ShowFailedScreen();
    public void StartGame();
    public void ShowWinScreen();
    public void SetFinalTime(string time);
    public string GetFinalTime();

    public void SetActive();

}
public class GameManager : IGameManager
{
    GameObject gameBoard = GameObject.FindGameObjectWithTag("GameManager").transform.Find("GameBoard").gameObject;
    

    private string finalTime;
    private IEnemyControl enemyControl;
    private IPlayerControler playerControler;
    private IFailedScreen failedScreen;
    private IGameSceneUI gameSceneUI;
    private IWinScreenUI winScreenUI;

    [Inject]
    public void Setup(IEnemyControl enemyControl, IPlayerControler playerControler, IFailedScreen failedScreen, IGameSceneUI gameSceneUI, IWinScreenUI winScreenUI)
    {
        this.enemyControl = enemyControl;
        this.playerControler = playerControler;
        this.failedScreen = failedScreen;
        this.gameSceneUI = gameSceneUI;
        this.winScreenUI = winScreenUI;
    }
    public void SetActive() => gameBoard.gameObject.SetActive(!gameBoard.gameObject.activeInHierarchy);

    public void DisableAfterDeath()
    {
        SetActive();
        enemyControl.SetActive();
        playerControler.SetActive();
    }
    public void StartGame()
    {
        SetActive();
        playerControler.SetActive();
        playerControler.ResetBody();
        playerControler.GetPlayerStartingSize(10 * 10);
        enemyControl.SetActive();
        enemyControl.ResetIndex();
    }

    public void ShowFailedScreen()
    {
        failedScreen.SetActive();
        gameSceneUI.SetActive();
    }

    public void ShowWinScreen()
    {
        winScreenUI.SetActive();
        gameSceneUI.SetActive();
    }
    public void SetFinalTime(string time) => finalTime = time;
    public string GetFinalTime() => finalTime;
}
