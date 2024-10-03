using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalBehaviour : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBehaviour colliderPlayer = collision.gameObject.GetComponent<PlayerBehaviour>();
        if(colliderPlayer != null)
        {
            colliderPlayer.canMove = false;
            FindObjectOfType<YouWinUIBehaviour>().RunWinRoutine();
        }
    }
}
