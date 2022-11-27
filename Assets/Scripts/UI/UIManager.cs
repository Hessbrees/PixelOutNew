using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    
    private ILogoUI logoUI;
    private IMainMenuUI mainMenuUI;
    private ILanguageUI languageUI;
    private ISettingsUI settingsUI;
    private IStatsUI statsUI;
    private IUpgradesUI upgradesUI;
    private IDifficulty difficultyUI;
    private IGameManager gameManager;
    private IFailedScreen failedScreen;
    private IWinScreenUI winScreenUI;
    private IGameSceneUI gameSceneUI;
    [Inject]
    public void Setup(ILogoUI logoUI, IMainMenuUI mainMenuUI, ILanguageUI languageUI, ISettingsUI settingsUI, IStatsUI statsUI, IUpgradesUI upgradesUI, IDifficulty difficultyUI, IGameManager gameManager, IFailedScreen failedScreen, IWinScreenUI winScreenUI, IGameSceneUI gameSceneUI)
    { 
        this.logoUI = logoUI;
        this.mainMenuUI = mainMenuUI;
        this.languageUI = languageUI;
        this.settingsUI = settingsUI;
        this.statsUI = statsUI;
        this.upgradesUI = upgradesUI;
        this.difficultyUI = difficultyUI;
        this.gameManager = gameManager;
        this.failedScreen = failedScreen;
        this.winScreenUI = winScreenUI;
        this.gameSceneUI = gameSceneUI;
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
        failedScreen.ButtonsListener();
        winScreenUI.ButtonsListener();
        gameSceneUI.ButtonsListener();
     }

    

}
