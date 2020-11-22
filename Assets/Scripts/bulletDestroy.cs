using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* PlayerMovement playermovement = collision.gameObject.GetComponentInParent<PlayerMovement>();
         playermovement.killYourSelf();*/
        GameObject playerHit = collision.gameObject;
        GameObject.Find("GameLogic").GetComponent<gameLogic>().spawnPlayer(playerHit);
            Destroy(gameObject);
        }
    /* {
             Debug.Log("1");
             PlayerMovement playermovement= hit.gameObject.GetComponentInParent<PlayerMovement>();
             playermovement.killYourSelf();
             Debug.Log("123");

         Destroy(gameObject);


     }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("2");
        Destroy(gameObject);
    }
    }
