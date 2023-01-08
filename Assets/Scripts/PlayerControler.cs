using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
public interface IPlayerControler
{
    public void PlayerUpdateTouch(GameObject player);
    public void GetGameBoardPositions();
    public void EatingProcess(Vector3 food);
    public void GetPlayerStartingSize(float playerSize);
    public Vector3 GetPlayerNormalSize();

    public float GetLeftGameBoard();
    public float GetRightGameBoard();
    public void SetPlayerSpeedUpSize(float speed);
    public void SetPlayerSpeedUpSizeBackToNormal();
    public int GetPlayerNormalSizeValue();
    public void SetActive();
    public void ResetBody();
}

public class PlayerControler : IPlayerControler
{
    GameObject player = GameObject.FindGameObjectWithTag("GameManager").transform.Find("Player").gameObject;
    Vector3 touchPosition;
    private Camera mainCamera = Camera.main;

    private float leftGameBoardBoxCollider;
    private float rightGameBoardBoxCollider;

    int easingID = -1;
    int easingScaleID = -1;
    int easingPlayerScaleID = -1;

    private float transformedFood;
    private float efficiencyScale = 0.4f;
    private float playerNormalSize;
    private float playerSpeedUpSize = 0;

    private IGameManager gameManager;
    [Inject]
    public void Setup(IGameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public Vector3 GetPlayerNormalSize() => new Vector3(Mathf.Sqrt(playerNormalSize), Mathf.Sqrt(playerNormalSize));
    public void SetActive() => player.gameObject.SetActive(!player.gameObject.activeInHierarchy);
    public int GetPlayerNormalSizeValue() => (int)playerNormalSize;
    public float GetLeftGameBoard() => leftGameBoardBoxCollider;
    public float GetRightGameBoard() => rightGameBoardBoxCollider;
    public void GetPlayerStartingSize(float playerSize) => playerNormalSize = playerSize;
    public void SetPlayerSpeedUpSize(float speed)
    {
        if (playerNormalSize * speed > 10) playerNormalSize *= speed;
    }

    public void SetPlayerSpeedUpSizeBackToNormal() => playerSpeedUpSize = 0;
    public void GetGameBoardPositions()
    {
        GameObject gameBoard = GameObject.FindGameObjectWithTag("GameBoard").gameObject;

        var gameBoardBoxCollider = gameBoard.GetComponent<BoxCollider2D>();
        leftGameBoardBoxCollider = (gameBoardBoxCollider.transform.localPosition.x - gameBoardBoxCollider.size.x / 2) * gameBoardBoxCollider.transform.localScale.x;
        rightGameBoardBoxCollider = (gameBoardBoxCollider.transform.localPosition.x + gameBoardBoxCollider.size.x / 2) * gameBoardBoxCollider.transform.localScale.x;
    }

    public void PlayerUpdateTouch(GameObject player)
    {
        //if (Touchscreen.current.primaryTouch.press.IsActuated())
        if(Input.GetMouseButtonDown(0))
        {

            //touchPosition = mainCamera.ScreenToWorldPoint(Touchscreen.current.primaryTouch.position.ReadValue());
            touchPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

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
    public void ResetBody()
    {
        GameObject playerBody = GameObject.FindGameObjectWithTag("Player").transform.Find("Body").gameObject;
        playerBody.transform.localScale = new Vector3(10,10);
        playerBody.transform.position = new Vector3(0, -80);
    }
    public void EatingProcess(Vector3 food)
    {
        GameObject playerBody = GameObject.FindGameObjectWithTag("Player").transform.Find("Body").gameObject;

        transformedFood = food.x * food.y;
        if (food.x > playerBody.transform.localScale.x) efficiencyScale = -0.4f ; // zmienic wartosc na stal¹ lub okolo 0.3 
        else if (transformedFood < (playerNormalSize - playerSpeedUpSize) * 0.2f) efficiencyScale = 1f;
        else if (transformedFood < (playerNormalSize - playerSpeedUpSize) * 0.4f) efficiencyScale = 0.9f;
        else if (transformedFood < (playerNormalSize - playerSpeedUpSize) * 0.6f) efficiencyScale = 0.8f;
        else efficiencyScale = 0.7f;

        playerNormalSize += transformedFood * efficiencyScale;
        if(playerNormalSize <10)
        {
            gameManager.DisableAfterDeath();
            gameManager.ShowFailedScreen();
        }
        if(playerNormalSize >500) // zmienic wartosc na caly screen
        {
            gameManager.DisableAfterDeath();
            gameManager.ShowWinScreen();
        }
    }
}
