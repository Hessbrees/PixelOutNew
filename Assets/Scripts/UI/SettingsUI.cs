using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public interface ISettingsUI
{
    public void SetActive();
    public void ButtonsListener();
    public void AddSliderValue(Slider slider);
    public void DecSliderValue(Slider slider);
}
public class SettingsUI : ISettingsUI
{
    GameObject settingsUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Settings").gameObject;

    
    private IMainMenuUI mainMenuUI;

    [Inject]
    public void Setup(IMainMenuUI mainMenuUI)
    {
        this.mainMenuUI = mainMenuUI;
    }

    public void SetActive() => settingsUI.SetActive(!settingsUI.activeInHierarchy);

    public void ButtonsListener()
    {
        var buttonDone = settingsUI.transform.Find("Back").GetComponent<Button>();
        buttonDone.onClick.AddListener(DoneButton);

        var musicSlider = settingsUI.transform.Find("Music").Find("Slider").GetComponent<Slider>();
        var soundSlider = settingsUI.transform.Find("Sound").Find("Slider").GetComponent<Slider>();

        var buttonLeftMusic = settingsUI.transform.Find("Music").Find("Left").GetComponent<Button>();
        buttonLeftMusic.onClick.AddListener(delegate { DecSliderValue(musicSlider); });
        var buttonRightMusic = settingsUI.transform.Find("Music").Find("Right").GetComponent<Button>();
        buttonRightMusic.onClick.AddListener(delegate { AddSliderValue(musicSlider); });

        var buttonLeftSound= settingsUI.transform.Find("Sound").Find("Left").GetComponent<Button>();
        buttonLeftSound.onClick.AddListener(delegate { DecSliderValue(soundSlider); });
        var buttonRightSound= settingsUI.transform.Find("Sound").Find("Right").GetComponent<Button>();
        buttonRightSound.onClick.AddListener(delegate { AddSliderValue(soundSlider); });
    }
    public void DoneButton()
    {
        mainMenuUI.SetActive();
        SetActive();
    }

    public void AddSliderValue(Slider slider) => slider.value += 0.1f;
    public void DecSliderValue(Slider slider) => slider.value -= 0.1f;

    public void OnUpdateChangeValue()
    {
        
    }

}
