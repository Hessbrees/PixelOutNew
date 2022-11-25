using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public interface IMenuUI
{

}
public class MenuUI : IMenuUI
{
    //GameObject UIManager = GameObject.FindGameObjectWithTag("MenuUI").gameObject;



 
   

    GameObject FailedScreenUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("FailedScreen").gameObject;
    GameObject WinScreenUI = GameObject.FindGameObjectWithTag("MenuUI").transform.Find("WinScreen").gameObject;
    
    

}
