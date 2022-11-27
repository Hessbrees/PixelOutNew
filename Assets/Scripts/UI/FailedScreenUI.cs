using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public interface IFailedScreen
{
    public void SetActive();
    public void ButtonsListener();
}
public class FailedScreenUI : IFailedScreen
{
    GameObject failedScreenUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("FailedScreen").gameObject;

    private IMainMenuUI mainMenuUI;
    private IGameManager gameManager;
    private IGameSceneUI gameSceneUI;
    [Inject]
    public void Setup(IMainMenuUI mainMenuUI, IGameManager gameManager, IGameSceneUI gameSceneUI)
    {
        this.mainMenuUI = mainMenuUI;
        this.gameManager = gameManager;
        this.gameSceneUI = gameSceneUI;
    }
    public void SetActive() => failedScreenUI.SetActive(!failedScreenUI.activeInHierarchy);

    public void ButtonsListener()
    {
        var buttonDone = failedScreenUI.transform.Find("Done").GetComponent<Button>();
        buttonDone.onClick.AddListener(DoneButton);

        var buttonRestart = failedScreenUI.transform.Find("Restart").GetComponent<Button>();
        buttonRestart.onClick.AddListener(RestartButton);
    }
    private void DoneButton()
    {
        SetActive();
        mainMenuUI.SetActive();
    }
    private void RestartButton()
    {
        gameSceneUI.SetActive();
        SetActive();
        gameManager.StartGame();
    }

}
