using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D playerCollider;
    BoxCollider2D feetCollider;
    float gravityAtStart;
    bool isAlive = true;

    [SerializeField] float playerGameSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 2.5f;
    [SerializeField] Vector2 deathKick = new(10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();    
        myAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        gravityAtStart = myRigidBody.gravityScale;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            return;
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnMove(InputValue value)
    {
        if ((!isAlive))
            return;
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if (!isAlive)
            return;
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        if(value.isPressed)
        {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new(playerGameSpeed * moveInput.x, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        myAnimator.SetBool("isRunning", true);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        else 
            myAnimator.SetBool("isRunning", false);
    }

    void ClimbLadder()
    {
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidBody.gravityScale = gravityAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
        Vector2 climbVelocity = new(myRigidBody.velocity.x, climbSpeed * moveInput.y);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;
    }

    void Die()
    {
        if (myRigidBody.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("dying");
            myRigidBody.velocity = deathKick;
        }
    }

    void OnFire(InputValue value)
    {
        if (!isAlive)
            return;
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
