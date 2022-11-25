using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public interface IMainMenuUI
{
    void SetActive();
    void ButtonsListener();
    void ExitButton();
    void StartButton();
    void LanguageButton();
}
public class MainMenuUI : IMainMenuUI
{
    GameObject mainMenuUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("MainMenu").gameObject;

    private IDifficulty difficulty;
    private ILanguageUI languageUI;
    private ISettingsUI settingsUI;
    private IUpgradesUI upgradesUI;
    private IStatsUI statsUI;

    [Inject]
    public void Setup(IDifficulty difficulty,ILanguageUI languageUI, ISettingsUI settingsUI, IUpgradesUI upgradesUI, IStatsUI statsUI)
    {
        this.difficulty = difficulty;
        this.languageUI = languageUI;
        this.settingsUI = settingsUI;
        this.upgradesUI = upgradesUI;
        this.statsUI = statsUI;
    }
    public void ButtonsListener()
    {
        var buttonExit = mainMenuUI.transform.Find("Exit").GetComponent<Button>();
        buttonExit.onClick.AddListener(ExitButton);
        var buttonStart = mainMenuUI.transform.Find("Start").GetComponent<Button>();
        buttonStart.onClick.AddListener(StartButton);
        var buttonLanguage = mainMenuUI.transform.Find("Language").GetComponent<Button>();
        buttonLanguage.onClick.AddListener(LanguageButton);
        var buttonSettings = mainMenuUI.transform.Find("Settings").GetComponent<Button>();
        buttonSettings.onClick.AddListener(SettingsButton);
        var buttonUpgrades = mainMenuUI.transform.Find("Upgrades").GetComponent<Button>();
        buttonUpgrades.onClick.AddListener(UpgradesButton);
        var buttonStats = mainMenuUI.transform.Find("Stats").GetComponent<Button>();
        buttonStats.onClick.AddListener(StatsButton);
    }
    public void ExitButton() => UnityEditor.EditorApplication.isPlaying = false;
    public void StartButton()
    {
        difficulty.SetActive();
        SetActive();
    }
    public void LanguageButton()
    {
        languageUI.SetActive();
        SetActive();
    }
    public void SettingsButton()
    {
        settingsUI.SetActive();
        SetActive();
    }
    public void UpgradesButton()
    {
        upgradesUI.SetActive();
        SetActive();
    }
    public void StatsButton()
    {
        statsUI.SetActive();
        SetActive();
    }
    public void SetActive() => mainMenuUI.SetActive(!mainMenuUI.activeInHierarchy);
}
