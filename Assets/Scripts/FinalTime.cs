using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
public class FinalTime : MonoBehaviour
{
    private TextMeshProUGUI text;

    private IGameManager gameManager;
    [Inject]
    public void Setup(IGameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        text.text = gameManager.GetFinalTime();
    }
}
