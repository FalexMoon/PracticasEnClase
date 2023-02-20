using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    public Transform chechGround;
    public bool isGrounded = false;
    public LayerMask groundLayer;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(chechGround.transform.position, 0.2f, groundLayer);
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
        anim.SetFloat("Vel", Mathf.Abs(rb.velocity.x));
        if(rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sr.flipX=false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }
}
