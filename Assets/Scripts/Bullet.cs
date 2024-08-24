using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float bulletSpeed = 1.0f;
    //PlayerMovement player;
    float direction = 1.0f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        //player = FindObjectOfType<PlayerMovement>();
        direction = FindObjectOfType<PlayerMovement>().transform.localScale.x;
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(direction * bulletSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
