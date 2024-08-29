using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D reversePeriscopeCollider;
    [SerializeField] float movementSpeed = 1.0f;
    [SerializeField] int lives = 1;
    int maximumLives;

    void Start()
    {
        maximumLives = lives;
        myRigidBody = GetComponent<Rigidbody2D>();
        reversePeriscopeCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(movementSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            movementSpeed *= -1;
            FlipEnemySprite();
        }
    }

    void FlipEnemySprite()
    {
        Vector3 vector3 = this.transform.localScale;
        vector3.x *= -1;
        transform.localScale = vector3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(Bullet.GetDamage());
            if (lives < 1)
            {
                FindObjectOfType<GameSession>().AddScore(maximumLives);
                Destroy(this.gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;
    }
}
