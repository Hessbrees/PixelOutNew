using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public interface IWinScreenUI
{
    public void SetActive();
    public void ButtonsListener();
}
public class WinScreenUI : IWinScreenUI
{
    GameObject winScreenUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("WinScreen").gameObject;
    private IMainMenuUI mainMenuUI;

    [Inject]
    public void Setup(IMainMenuUI mainMenuUI)
    {
        this.mainMenuUI = mainMenuUI;
    }
    public void SetActive() => winScreenUI.SetActive(!winScreenUI.activeInHierarchy);
    public void ButtonsListener()
    {
        var buttonDone = winScreenUI.transform.Find("Done").GetComponent<Button>();
        buttonDone.onClick.AddListener(DoneButton);
    }
    private void DoneButton()
    {
        mainMenuUI.SetActive();
        SetActive();
    }
}
