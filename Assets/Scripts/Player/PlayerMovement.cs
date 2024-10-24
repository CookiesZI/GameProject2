using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ab;

    private bool facingRight = true;

    public Vector2 moveDirection;

    [HideInInspector]
    public float lastHorizontal;
    [HideInInspector]
    public float lastVertical;
    [HideInInspector]
    public Vector2 lastMove;

    public CharacterScriptableObject characterData;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ab = GetComponent<Animator>();
        lastMove = new Vector2 (1, 0f);
    }

    private void Update()
    {
        InputManagement();
        FlipController();

        if(moveDirection.x != 0 || moveDirection.y != 0)
        {
            ab.SetBool("Move", true);
        }
        else
        {
            ab.SetBool("Move", false);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if(moveDirection.x != 0)
        {
            lastHorizontal = moveDirection.x;
            lastMove = new Vector2(lastHorizontal, 0f);
        }
        if (moveDirection.y != 0)
        {
            lastVertical = moveDirection.y;
            lastMove = new Vector2(0f, lastVertical);
        }
        if(moveDirection.x !=0 &&  moveDirection.y != 0)
        {
            lastMove = new Vector2(lastHorizontal, lastVertical);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * characterData.MoveSpeed, moveDirection.y * characterData.MoveSpeed);
    }

    private void FlipController()
    {
        if (rb.velocity.x < 0 && facingRight)
            Flip();
        else if (rb.velocity.x > 0 && !facingRight)
            Flip();
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
