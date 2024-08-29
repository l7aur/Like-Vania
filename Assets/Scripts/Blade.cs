using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    Rigidbody2D body;
    float verticalMovementSpeed = 0f;
    [SerializeField] float horizontalMovementSpeed = 2f;
    BoxCollider2D periscope;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        periscope = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(horizontalMovementSpeed, verticalMovementSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exited");
        if (!collision.CompareTag("Bullet"))
        {
            horizontalMovementSpeed *= -1;
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
