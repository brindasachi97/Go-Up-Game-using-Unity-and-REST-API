using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer; //for flipping the sprite left and right

    public Animator animator;
    public float jumpForceAccel = 1;
    public float maxJumpForce = 20f;
    public LayerMask groundLayer;

    private float jumpForce = 0f;

    bool isMoving()
    {
        return (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.touchCount > 0);
    }

    void jump(float force)
    {
        Vector2 dir = new Vector2(10f * force, Mathf.Abs(23f * force));
        GetComponent<Rigidbody2D>().AddForce(dir);
        jumpForce = 0;
    }

    bool isGrounded()
    {
        return Physics2D.OverlapArea(
            new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
            new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f),
            groundLayer
        );
    }

    bool touchReleased(bool isRight) {
        if (Input.touchCount <= 0) return false;
        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Ended) return false;
        return (isRight) ? touch.position.x >= Screen.width / 2f : touch.position.x < Screen.width / 2f;
    }

    void groundAnimation() //animations only available when grounded
    {
        animator.SetBool("grounded", true);
        animator.SetBool("isJumping", false);
        animator.SetBool("crouch", false);

        if (Input.GetKeyDown(KeyCode.RightArrow) || touchReleased(true))
        {
            animator.SetBool("crouch", true);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || touchReleased(false))
        {
            animator.SetBool("crouch", true);
            spriteRenderer.flipX = true;
        }
    }

    void jumpAnimation()
    {
        animator.SetBool("grounded", false);
        animator.SetBool("isJumping", true);
    }

    void readyJump()
    {
        jumpForce += (isMoving()) ? jumpForceAccel : 0;
        jumpForce = Mathf.Min(jumpForce, maxJumpForce);

        if (Input.GetKeyUp(KeyCode.RightArrow) || touchReleased(true))
            jump(jumpForce);
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || touchReleased(false))
            jump(-jumpForce);
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded())
        {
            groundAnimation();
            readyJump();
        }
        else
            jumpAnimation();
    }
}