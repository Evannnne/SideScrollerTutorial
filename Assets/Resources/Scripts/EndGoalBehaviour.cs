using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalBehaviour : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour collidedPlayer = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (collidedPlayer != null)
        {
            collidedPlayer.canMove = false;
            FindObjectOfType<YouWinUIBehaviour>().RunWinRoutine();
        }
    }
}
