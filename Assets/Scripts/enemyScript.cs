using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

   // public GameObject otherobj; //your other object 
  

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        (gameObject.GetComponent("AIPath") as MonoBehaviour).enabled = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Bullet(Clone)")
        Destroy(gameObject);
    }
    public void destoryEnemy()
    {
       
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
      //  checkIfPlayerInView();

    }

    private void checkIfPlayerInView()
    {
        /*   RaycastHit hit;
           var rayDirection = player.position - transform.position;
           if (Physics.Raycast(transform.position, rayDirection, out hit))
           {
               Debug.Log( hit.collider.name);
               if (hit.collider.name == "Player")
               {

                 gameObject
                  /*Vector3 direction = player.position - transform.position;
                   float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                   rb.rotation = angle;
                   direction.Normalize();
                   movement = direction;
                   moveCharacter(movement);
               }
               else
               {
                  (gameObject.GetComponent("AIPath") as MonoBehaviour).enabled = false;
              }
           }*/

        // Does the ray intersect any objects excluding the player layer



        var rayDirection = player.position - transform.position;
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection);

        Debug.DrawRay(transform.position, rayDirection * 1000, Color.white);
        if (hit.collider.name == "Player")
        {
            (gameObject.GetComponent("AIPath") as MonoBehaviour).enabled = true;
            /* Vector3 direction = player.position - transform.position;
                  float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                  rb.rotation = angle;
                  direction.Normalize();
                  movement = direction;
                  moveCharacter(movement);*/
        }

      //  else
       // {
       //     (gameObject.GetComponent("AIPath") as MonoBehaviour).enabled = false;
      //  }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
