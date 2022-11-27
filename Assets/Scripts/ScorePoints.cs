using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public interface IScorePoints
{
    public int ChangeScorePoints();
}
public class ScorePoints : IScorePoints
{
    private IPlayerControler playerControler;
    [Inject]
    public void Setup(IPlayerControler playerControler)
    {
        this.playerControler = playerControler;
    }

    public int ChangeScorePoints() => playerControler.GetPlayerNormalSizeValue();

}
