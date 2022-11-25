using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public interface IStatsUI
{
    public void SetActive();
    public void ButtonsListener();
}
public class StatsUI : IStatsUI
{
    GameObject statsUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Stats").gameObject;
    private IMainMenuUI mainMenuUI;

    [Inject]
    public void Setup(IMainMenuUI mainMenuUI)
    {
        this.mainMenuUI = mainMenuUI;
    }
    public void SetActive() => statsUI.SetActive(!statsUI.activeInHierarchy);
    public void ButtonsListener()
    {
        var buttonDone = statsUI.transform.Find("Back").GetComponent<Button>();
        buttonDone.onClick.AddListener(DoneButton);
    }
    public void DoneButton()
    {
        mainMenuUI.SetActive();
        SetActive();
    }
}
