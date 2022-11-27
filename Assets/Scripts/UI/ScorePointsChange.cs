using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
public class ScorePointsChange : MonoBehaviour
{
    private TextMeshProUGUI text;
    private IScorePoints scorePoints;
    [Inject]
    public void Setup(IScorePoints scorePoints)
    {
        this.scorePoints = scorePoints;
    }
    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {
        text.text = scorePoints.ChangeScorePoints().ToString();
    }

}
