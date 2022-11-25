using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public interface IUpgradesUI
{
    public void SetActive();
    public void ButtonsListener();
}
public class UpgradesUI :IUpgradesUI
{
    GameObject upgradesUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Upgrade").gameObject;
    private IMainMenuUI mainMenuUI;
    [Inject]
    public void Setup(IMainMenuUI mainMenuUI)
    {
        this.mainMenuUI = mainMenuUI;
    }
    public void SetActive() => upgradesUI.SetActive(!upgradesUI.activeInHierarchy);
    public void ButtonsListener()
    {
        var buttonDone = upgradesUI.transform.Find("Back").GetComponent<Button>();
        buttonDone.onClick.AddListener(DoneButton);
    }
    public void DoneButton()
    {
        mainMenuUI.SetActive();
        SetActive();
    }
}
