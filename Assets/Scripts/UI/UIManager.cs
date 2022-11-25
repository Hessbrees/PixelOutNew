using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    private IMenuUI menuUI;
    private ILogoUI logoUI;
    private IMainMenuUI mainMenuUI;
    private ILanguageUI languageUI;
    private ISettingsUI settingsUI;
    private IStatsUI statsUI;
    private IUpgradesUI upgradesUI;
    private IDifficulty difficultyUI;

    [Inject]
    public void Setup(IMenuUI menuUI,ILogoUI logoUI, IMainMenuUI mainMenuUI, ILanguageUI languageUI, ISettingsUI settingsUI, IStatsUI statsUI, IUpgradesUI upgradesUI, IDifficulty difficultyUI)
    {
        this.menuUI = menuUI;
        this.logoUI = logoUI;
        this.mainMenuUI = mainMenuUI;
        this.languageUI = languageUI;
        this.settingsUI = settingsUI;
        this.statsUI = statsUI;
        this.upgradesUI = upgradesUI;
        this.difficultyUI = difficultyUI;
    }
    private void Awake()
    {
        logoUI.ButtonClick();
        mainMenuUI.ButtonsListener();
        languageUI.ButtonsListener();
        settingsUI.ButtonsListener();
        statsUI.ButtonsListener();
        upgradesUI.ButtonsListener();
        difficultyUI.ButtonsListener();
    }

}
