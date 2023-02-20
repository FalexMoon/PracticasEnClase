using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRun : MonoBehaviour
{

    public float jumpForce;
    public Transform chechGround;
    public bool isGrounded = false;
    public LayerMask groundLayer;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(chechGround.transform.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce*100));
        }
    }
}
