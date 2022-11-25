using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPauseUI
{
    public void SetActive();
}

public class PauseUI : IPauseUI
{
    GameObject pauseUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("Pause").gameObject;

    public void SetActive() => pauseUI.SetActive(!pauseUI.activeInHierarchy);
}
