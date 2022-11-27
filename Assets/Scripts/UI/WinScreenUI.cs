using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWinScreenUI
{
    public void SetActive();
}
public class WinScreenUI : IWinScreenUI
{
    GameObject winScreenUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("WinScreen").gameObject;

    public void SetActive() => winScreenUI.SetActive(!winScreenUI.activeInHierarchy);

}
