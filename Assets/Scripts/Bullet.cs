using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float bulletSpeed = 1.0f;
    [SerializeField] static int bulletDamage = 1;
    [SerializeField] int ballisticDistance = 150;
    float direction = 1.0f;
    int distanceTravelled = 0;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        direction = FindObjectOfType<PlayerMovement>().transform.localScale.x;
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(direction * bulletSpeed, 0f);
        distanceTravelled++;
        if (distanceTravelled > ballisticDistance)
            Destroy(this.gameObject);
    }

    public static int GetDamage() {return bulletDamage; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
