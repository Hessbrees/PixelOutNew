using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Zenject;
public class ButtonsLeftPointerEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Slider slider;
    private ISettingsUI settingsUI;
    private bool isPressed;

    [Inject]
    public void Setup(ISettingsUI settingsUI)
    {
        this.settingsUI = settingsUI;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        StartCoroutine(DecraseValue());
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    IEnumerator DecraseValue()
    {
        while (isPressed)
        {
            settingsUI.DecSliderValue(slider);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
