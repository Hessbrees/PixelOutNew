using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerMovementImput : MonoBehaviour
{
    [SerializeField] GameObject gameBoard;

    private IPlayerControler playerControler;

    [Inject]
    public void Setup(IPlayerControler playerControler)
    {
        this.playerControler = playerControler;
    }
    private void Awake()
    {
        playerControler.GetGameBoardPositions();
        playerControler.GetPlayerStartingSize(transform.localScale.x * transform.localScale.y);
    }
    void Update()
    {
        playerControler.PlayerUpdateTouch(gameObject);
    }
}
