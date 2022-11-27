using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerColliderBechaviour : MonoBehaviour
{

    private Vector3 foodForPlayer;
    private IPlayerControler playerControler;

    [Inject]
    public void Setup(IPlayerControler playerControler)
    {
        this.playerControler = playerControler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" )
        {
            foodForPlayer = collision.gameObject.transform.localScale;

            playerControler.EatingProcess(foodForPlayer);

            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }


}
