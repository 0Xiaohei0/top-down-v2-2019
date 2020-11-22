using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolShoot : MonoBehaviour
{
    [SerializeField] public Transform FirePoint;

    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }
    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
      


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

