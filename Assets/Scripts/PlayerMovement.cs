using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] public Transform FirePoint;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject hitbox;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    [SerializeField] Animator animator;
    Coroutine firingCoroutine;
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 movement2;
    Vector2 shootDirection;
    Vector2 idleDirection;
    Quaternion playerRotation;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "Player1")
        {
            Move();
            checkMoveDirection();
            Shoot();
            
        }
        if (gameObject.tag == "Player2")
        {
            Move2();
            checkMoveDirection2();
            Shoot2();
            
        }

    }
    public void killYourSelf()
    {
        Destroy(gameObject);
    }
    


    private void checkMoveDirection()
    {
        

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            playerRotation = Quaternion.Euler(0, 0, 45);
            idleDirection = new Vector2(-1, -1);
        }

        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            playerRotation = Quaternion.Euler(0, 0, 135);
            idleDirection = new Vector2(-1, 1);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            playerRotation = Quaternion.Euler(0, 0, 225);
            idleDirection = new Vector2(1, -1);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            playerRotation = Quaternion.Euler(0, 0, 315);
            idleDirection = new Vector2(-1, 1);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            playerRotation = Quaternion.Euler(0, 0, 0);
            idleDirection = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRotation = Quaternion.Euler(0, 0, 90);
            idleDirection = new Vector2(-1, 0);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            playerRotation = Quaternion.Euler(0, 0, 180);
            idleDirection = new Vector2(0, -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRotation = Quaternion.Euler(0, 0, 270);
            idleDirection = new Vector2(1, 0);
        }
        else
        {
            playerRotation = Quaternion.Euler(0, 0, 180);
        }

      







    }

    private void checkMoveDirection2()
    {


        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 45);
            idleDirection = new Vector2(-1, -1);
        }

        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 135);
            idleDirection = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 225);
            idleDirection = new Vector2(1, -1);
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 315);
            idleDirection = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 0);
            idleDirection = new Vector2(0, 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 90);
            idleDirection = new Vector2(-1, 0);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 180);
            idleDirection = new Vector2(0, -1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRotation = Quaternion.Euler(0, 0, 270);
            idleDirection = new Vector2(1, 0);
        }
        else
        {
            playerRotation = Quaternion.Euler(0, 0, 180);
        }
        

    }



        private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(firingCoroutine);
        }

    }
    private void Shoot2()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            firingCoroutine = StartCoroutine(FireContinuously2());
        }
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            StopCoroutine(firingCoroutine);
        }

    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
             if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
             {
                 shootDirection = idleDirection;
             }
             else
             {
                 shootDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
             }

            GameObject bullet = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), hitbox.GetComponent<Collider2D>());
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
           rb.velocity=(shootDirection.normalized * projectileSpeed);
            bullet.transform.rotation=playerRotation;
            //Destroy(bullet, 2.0f);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
    IEnumerator FireContinuously2()
    {
        while (true)
        {
            if (Input.GetAxis("Horizontal2") == 0 && Input.GetAxis("Vertical2") == 0)
            {
                shootDirection = idleDirection;
            }
            else
            {
                shootDirection = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
            }
            GameObject bullet = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), hitbox.GetComponent<Collider2D>());
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = (shootDirection * projectileSpeed);
            bullet.transform.rotation = playerRotation;
            //Destroy(bullet, 2.0f);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }
  

    private void Move2()
    {


        movement2.x = Input.GetAxisRaw("Horizontal2");
        movement2.y = Input.GetAxisRaw("Vertical2");
        if (movement2.magnitude != 0)
        {
            animator.SetLayerWeight(1, 1f);
            animator.SetFloat("Horizontal", movement2.x);
            animator.SetFloat("Vertical", movement2.y);
            animator.SetFloat("Magnitude", movement2.magnitude);
        }
        else
        {
            animator.SetLayerWeight(1, 0f);
            animator.SetFloat("idleHorizontal", idleDirection.x);
            animator.SetFloat("idleVertical", idleDirection.y);
        }

        rb.MovePosition(rb.position + movement2.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    private void Move()
    {
        
        /* var deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
         var xPosition = transform.position.x + deltaX;
         var deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
         var yPosition = transform.position.y + deltaY;
         transform.position = new Vector2(xPosition, yPosition);*/
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.magnitude!= 0)
        {
            animator.SetLayerWeight(1, 1f);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);
        }
        else
        {
            animator.SetLayerWeight(1, 0f);
            animator.SetFloat("idleHorizontal",idleDirection.x);
            animator.SetFloat("idleVertical", idleDirection.y);
        }
       
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}