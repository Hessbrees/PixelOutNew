using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public interface IDifficulty
{
    public void SetActive();
    public void ButtonsListener();
}
public class DifficultyUI : IDifficulty
{
    GameObject difficultyUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Difficulty").gameObject;
    private IMainMenuUI mainMenuUI;
    private IGameSceneUI gameSceneUI;
    private IGameManager gameManager;
    [Inject]
    public void Setup(IMainMenuUI mainMenuUI, IGameSceneUI gameSceneUI,IGameManager gameManager)
    {
        this.mainMenuUI = mainMenuUI;
        this.gameSceneUI = gameSceneUI;
        this.gameManager = gameManager;
    }
    public void SetActive() => difficultyUI.SetActive(!difficultyUI.activeInHierarchy);
    public void ButtonsListener()
    {
        var buttonDone = difficultyUI.transform.Find("Back").GetComponent<Button>();
        buttonDone.onClick.AddListener(BackButton);
        var buttonStart = difficultyUI.transform.Find("Start").GetComponent<Button>();
        buttonStart.onClick.AddListener(StartButton);
    }
    public void StartButton()
    {
        gameSceneUI.SetActive();
        SetActive();
        //startgame


        gameManager.StartGame();
    }

    public void BackButton()
    {
        mainMenuUI.SetActive();
        SetActive();
    }
}
