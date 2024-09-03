using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBlade : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float verticalMovementSpeed = 0f;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(0f, verticalMovementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            verticalMovementSpeed *= -1;
            FlipEnemySprite();
        }
    }

    void FlipEnemySprite()
    {
        Vector3 vector3 = this.transform.localScale;
        vector3.x *= -1;
        transform.localScale = vector3;
    }
}
