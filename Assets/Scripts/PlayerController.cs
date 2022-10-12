using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;

    public Transform chechGround;
    public bool isGrounded = false;
    public LayerMask groundLayer;

    public Transform shootPoint;
    public GameObject proyectil;
    public float shotDelay;
    float delayShot;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        delayShot = shotDelay;
    }

    void Update()
    {

        if(shotDelay > 0)
        {
            shotDelay-= Time.deltaTime;
        }

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

        if(Input.GetKeyDown(KeyCode.Z) && shotDelay < 0)
        {
            Disparar();
        }

    }

    void Disparar()
    {
        int multiplicador = 1;
        if (GetComponent<SpriteRenderer>().flipX)
        {
            multiplicador = -1;
            shootPoint.transform.localPosition = new Vector3(Mathf.Abs(shootPoint.transform.localPosition.x) * -1, shootPoint.transform.localPosition.y);

        }
        else
        {
            shootPoint.transform.localPosition = new Vector3(Mathf.Abs(shootPoint.transform.localPosition.x), shootPoint.transform.localPosition.y);
        }
        GameObject shoot = Instantiate(proyectil, shootPoint.position, Quaternion.identity);
        shoot.transform.localScale = new Vector2(proyectil.transform.localScale.x * multiplicador, proyectil.transform.localScale.y);
        shotDelay = delayShot;
    }
}
