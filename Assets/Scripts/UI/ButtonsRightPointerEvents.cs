using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Zenject;
public class ButtonsRightPointerEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed;
    [SerializeField] Slider slider;
    private ISettingsUI settingsUI;

    [Inject]
    public void Setup(ISettingsUI settingsUI)
    {
        this.settingsUI = settingsUI;
    }


    public void OnPointerDown(PointerEventData eventData) 
    {
        isPressed = true;
        StartCoroutine(IncreaseValue());
    }
    public void OnPointerUp(PointerEventData eventData) 
    {
        isPressed = false;
    }

    IEnumerator IncreaseValue()
    {
        while (isPressed)
        {
            settingsUI.AddSliderValue(slider);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
