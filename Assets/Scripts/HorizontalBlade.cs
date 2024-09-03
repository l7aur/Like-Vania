using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBlade : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] float horizontalMovementSpeed = 2f;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.velocity = new Vector2(horizontalMovementSpeed, 0f);
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
