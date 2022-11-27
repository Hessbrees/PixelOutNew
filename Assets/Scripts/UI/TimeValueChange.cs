using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using Zenject;
public class TimeValueChange : MonoBehaviour
{
    private TextMeshProUGUI text;
    public Stopwatch timer;
    private IGameManager gameManager;
    [Inject]
    public void Setup(IGameManager gameManager)
    {
        this.gameManager = gameManager;
    }
    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        timer = new Stopwatch();
        
    }
    private void OnEnable()
    {
        timer.Start();
    }
    private void OnDisable()
    {
        timer.Stop();
        gameManager.SetFinalTime(timer.Elapsed.ToString("mm\\:ss\\.ff"));
    }
    public void Update()
    {
        text.text = timer.Elapsed.ToString("mm\\:ss\\.ff");
    }
}
