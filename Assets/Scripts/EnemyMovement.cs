using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D reversePeriscopeCollider;
    [SerializeField] float movementSpeed = 1.0f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        reversePeriscopeCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(movementSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        movementSpeed *= -1;
        FlipEnemySprite();
    }

    void FlipEnemySprite()
    {
        this.transform.localScale = new Vector2(-Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
