using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody2D))]
public class PlayerJetpack : MonoBehaviour
{

    public float jetpackForce;
    public GameObject bulletPrefab;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 dir = new Vector2(0.8f, 2);
            rb.velocity = new Vector2 (0.8f,2) * jetpackForce;
            Bullet bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity).GetComponent<Bullet>();
            bullet.Inicializar(dir);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2 dir = new Vector2(-0.8f, 2);
            rb.velocity = /*rb.velocity +*/ new Vector2(-0.8f, 2) * jetpackForce;
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.Inicializar(dir);
        }
    }
}
