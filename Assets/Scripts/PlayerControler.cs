using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public interface IPlayerControler
{
    public void PlayerUpdateTouch(GameObject player);
    public void GetGameBoardPositions();
    public void EatingProcess(Vector3 food);
    public void GetPlayerStartingSize(float playerSize);

    public float GetLeftGameBoard();
    public float GetRightGameBoard();
    public void SetPlayerSpeedUpSize(float speed);
    public void SetPlayerSpeedUpSizeBackToNormal();
}

public class PlayerControler : IPlayerControler
{
    GameObject gameBoard = GameObject.Find("GameBoard").gameObject;
    GameObject player = GameObject.FindGameObjectWithTag("Player").transform.Find("Body").gameObject;
    Vector3 touchPosition;
    private Camera mainCamera = Camera.main;

    private float leftGameBoardBoxCollider;
    private float rightGameBoardBoxCollider;

    int easingID = -1;
    int easingScaleID = -1;
    int easingPlayerScaleID = -1;
    //private float timeSpeed;

    //PlayerColliderBechaviour

    private float transformedFood;
    private float efficiencyScale = 0.4f;
    private float playerNormalSize;
    private float playerSpeedUpSize = 0;

    public float GetLeftGameBoard() => leftGameBoardBoxCollider;
    public float GetRightGameBoard() => rightGameBoardBoxCollider;
    public void GetPlayerStartingSize(float playerSize) => playerNormalSize = playerSize;
    public void SetPlayerSpeedUpSize(float speed)
    {
        if (playerSpeedUpSize < playerNormalSize - playerSpeedUpSize) playerSpeedUpSize += playerNormalSize*speed;
    }

    public void SetPlayerSpeedUpSizeBackToNormal() => playerSpeedUpSize = 0;
    public void GetGameBoardPositions()
    {
        var gameBoardBoxCollider = gameBoard.GetComponent<BoxCollider2D>();
        leftGameBoardBoxCollider = (gameBoardBoxCollider.transform.localPosition.x - gameBoardBoxCollider.size.x / 2) * gameBoardBoxCollider.transform.localScale.x;
        rightGameBoardBoxCollider = (gameBoardBoxCollider.transform.localPosition.x + gameBoardBoxCollider.size.x / 2) * gameBoardBoxCollider.transform.localScale.x;
    }

    public void PlayerUpdateTouch(GameObject player)
    {
        if (Touchscreen.current.primaryTouch.press.IsActuated())
        {

            touchPosition = mainCamera.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue());

            if (touchPosition.x > leftGameBoardBoxCollider && touchPosition.x < rightGameBoardBoxCollider)
            {
                if (LeanTween.isTweening(easingID))
                {
                    LeanTween.cancel(easingID);
                    LeanTween.cancel(easingScaleID);
                }

                float timeSpeed = Mathf.Abs(player.transform.position.x - touchPosition.x) / 100;
                easingID = LeanTween.moveX(player, touchPosition.x, timeSpeed).setOnStart(
                    delegate { easingScaleID = LeanTween.scale(player, player.transform.localScale / (timeSpeed + 1), timeSpeed).uniqueId; }).uniqueId;
                LeanTween.cancel(easingPlayerScaleID);
            }
        }

        if (!LeanTween.isTweening(easingID))
        {
            float timeSpeed = Mathf.Abs(player.transform.localScale.x - playerNormalSize + playerSpeedUpSize) / playerNormalSize;
            if (LeanTween.isTweening(easingPlayerScaleID)) LeanTween.cancel(easingPlayerScaleID);

            easingPlayerScaleID = LeanTween.scale(player, new Vector3(Mathf.Sqrt(playerNormalSize - playerSpeedUpSize), Mathf.Sqrt(playerNormalSize - playerSpeedUpSize)), timeSpeed).uniqueId;
        }
    }

    public void EatingProcess(Vector3 food)
    {

        transformedFood = food.x * food.y;
        if (food.x > player.transform.localScale.x) ;
        else if (transformedFood < (playerNormalSize - playerSpeedUpSize) * 0.2f) efficiencyScale = 1f;
        else if (transformedFood < (playerNormalSize - playerSpeedUpSize) * 0.4f) efficiencyScale = 0.9f;
        else if (transformedFood < (playerNormalSize - playerSpeedUpSize) * 0.6f) efficiencyScale = 0.8f;
        else efficiencyScale = 0.7f;


        playerNormalSize += transformedFood * efficiencyScale;
    }
}
