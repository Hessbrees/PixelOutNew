using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public interface ILanguageUI
{
    public void SetActive();
    public void ButtonsListener();
}
public class LanguageUI : ILanguageUI
{
    GameObject languageUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Language").gameObject;
    private IMainMenuUI mainMenuUI;

    [Inject]
    public void Setup(IMainMenuUI mainMenuUI)
    {
        this.mainMenuUI = mainMenuUI;
    }
    public void SetActive() => languageUI.SetActive(!languageUI.activeInHierarchy);
    public void ButtonsListener()
    {
        var buttonDone = languageUI.transform.Find("Back").GetComponent<Button>();
        buttonDone.onClick.AddListener(DoneButton);
    }
    public void DoneButton()
    {
        mainMenuUI.SetActive();
        SetActive();
    }

}
