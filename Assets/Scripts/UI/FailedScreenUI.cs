using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFailedScreen
{
    public void SetActive();
}
public class FailedScreenUI : IFailedScreen
{
    GameObject failedScreenUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("FailedScreen").gameObject;

    public void SetActive() => failedScreenUI.SetActive(!failedScreenUI.activeInHierarchy);

}
