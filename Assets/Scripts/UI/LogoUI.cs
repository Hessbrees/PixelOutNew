using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public interface ILogoUI
{
    void ButtonClick();
    void OnClickLogotoMainMenu();
}

public class LogoUI : ILogoUI
{
    private bool isClicked = false;

    private IMainMenuUI mainMenuUI;

    [Inject]
    public void Setup(IMainMenuUI mainMenuUI)
    {
        this.mainMenuUI = mainMenuUI;
    }


    GameObject logoUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Logo").gameObject;
    public void ButtonClick()
    {
        var button = logoUI.transform.Find("AreaButton").GetComponent<Button>();
        button.onClick.AddListener(OnClickLogotoMainMenu);
    }
    public void OnClickLogotoMainMenu()
    {
        if (!isClicked)
        {
            isClicked = true;
            var desc = logoUI.transform.Find("Desc").GetComponent<Transform>();
            desc.LeanScale(desc.localScale * 1.5f, 1f).setEaseInBounce().setOnComplete(ChangeScreenAfterEasing).setLoopPingPong(1);
        }
    }
    private void ChangeScreenAfterEasing()
    {
        SetActive();
        mainMenuUI.SetActive();
        isClicked = false;
    }

    public void SetActive() => logoUI.SetActive(!logoUI.activeInHierarchy);
}
