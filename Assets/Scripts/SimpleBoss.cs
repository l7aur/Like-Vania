using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class SimpleBoss : MonoBehaviour
{
    Animator animator;
    Rigidbody2D myRigidBody;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] int lives = 20;
    [SerializeField] int bossScoreMultiplier = 10;
    int maximumLives;

    void Start()
    {
        animator= GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        maximumLives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("seenPlayer"))
            myRigidBody.velocity = new Vector2(movementSpeed, 0f);
    }

    void FlipEnemySprite()
    {
        Vector3 vector3 = this.transform.localScale;
        vector3.x *= -1;
        transform.localScale = vector3;
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(Bullet.GetDamage());
            if (lives < 1)
            {
                FindObjectOfType<GameSession>().AddScore(maximumLives * bossScoreMultiplier);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            movementSpeed *= -1;
            FlipEnemySprite();
        }
    }
}
