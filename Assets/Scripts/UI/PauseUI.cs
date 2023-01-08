using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public interface IPauseUI
{
    public void SetActive();
    public void ButtonsListener();
}

public class PauseUI : IPauseUI
{
    GameObject pauseUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Pause").gameObject;

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
    public void ButtonsListener()
    {
        var buttonRestart = pauseUI.transform.Find("Restart").GetComponent<Button>();
        buttonRestart.onClick.AddListener(RestartButton);

        var buttonResume = pauseUI.transform.Find("Resume").GetComponent<Button>();
        buttonResume.onClick.AddListener(ResumeButton);

        var buttonMenu = pauseUI.transform.Find("Back to menu").GetComponent<Button>();
        buttonMenu.onClick.AddListener(MenuButton);

    }
    public void SetActive() => pauseUI.SetActive(!pauseUI.activeInHierarchy);
    public void TimeScale(int time) => Time.timeScale = time;
    public void ResumeButton()
    {
        gameManager.Disable();
        TimeScale(1);
        SetActive();
    }
    public void MenuButton()
    {
        TimeScale(1);
        mainMenuUI.SetActive();
        gameSceneUI.SetActive();
        SetActive();
    }
    private void RestartButton()
    {
        TimeScale(1);
        SetActive();
        gameManager.StartGame();
    }

}
