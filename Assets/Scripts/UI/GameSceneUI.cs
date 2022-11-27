using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
public interface IGameSceneUI
{
    public void SetActive();
    public void ButtonsListener();
}

public class GameSceneUI : IGameSceneUI
{
    GameObject gameSceneUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("GameScene").gameObject;
    private IPauseUI pauseUI;

    [Inject]
    public void Setup(IPauseUI pauseUI)
    {
        this.pauseUI = pauseUI;
    }
    public void ButtonsListener()
    {
        var buttonPause = gameSceneUI.transform.Find("Pause").GetComponent<Button>();
        buttonPause.onClick.AddListener(PauseButton);
    }
    public void PauseButton() => pauseUI.SetActive();
    public void SetActive() => gameSceneUI.SetActive(!gameSceneUI.activeInHierarchy);

}
